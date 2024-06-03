import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get/get.dart';
import 'package:shopxpress_app/models/create_order_model.dart';
import 'package:shopxpress_app/utils/snackbar/snackbars.dart';
import '../models/cart_model.dart';
import '../models/order_model.dart';
import 'package:http/http.dart' as http;

import '../models/order_item_model.dart';
import '../navigation_menu.dart';
import '../screens/orders/orders.dart';
import '../utils/constants/api_constants.dart';
import 'authentication_controller.dart';
import 'cart_controller.dart';

class OrderController extends GetxController {
  var isLoading = false.obs;
  RxList<OrderModel> orders = <OrderModel>[].obs;
  Rx<OrderModel> order = OrderModel().obs;
  var cartController = Get.find<CartController>();

  var token = const FlutterSecureStorage().read(key: 'token');

  var authController = Get.find<AuthenticationController>();
  var addressController = TextEditingController();

  @override
  void onInit() {
    super.onInit();
    getOrders();
  }

  @override
  void onClose() {
    super.onClose();
    addressController.dispose();
  }

  Future<void> getOrders() async {
    try {
      isLoading(true);
      var response = await http.get(Uri.parse(TAPIConstants.ordersUrl),
          headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
      if (response.statusCode == 200) {
        var result = jsonDecode(response.body);
        orders.clear();
        for (var item in result) {
          orders.add(OrderModel.fromJson(item));
        }
      }
    }
    finally {
      isLoading(false);
    }
  }
  
  Future<void> getOrder(String orderId) async {
    var response = await http.get(Uri.parse('${TAPIConstants.ordersUrl}/$orderId'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 200) {
      var result = jsonDecode(response.body);
      order.value = OrderModel.fromJson(result);
    }
  }

  Future<void> placeOrder() async {
    try {
      isLoading(true);
      var cart = cartController.cart;
      CreateOrderModel orderModel = (await mapCartToOrder(cart.value));
      var response = await http.post(Uri.parse(TAPIConstants.ordersUrl),
          headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'},
          body: jsonEncode(orderModel));
      if (response.statusCode == 201 || response.statusCode == 202) {
        await cartController.clearCart(cart.value.id!);
        await getOrders();
        Get.off(() => const NavigationMenu());
        TSnackBar.success('success', 'Order placed successfully');
      }
    }
    finally {
      isLoading(false);
    }
  }

  Future<CreateOrderModel> mapCartToOrder(CartModel cart) async => CreateOrderModel
    (
      total: cart.total ?? 0,
      address: addressController.text,
      userId: authController.user.value.id!,
      orderItems: cart.cartItems!.map((item) => OrderItemModel(
        id: item.id,
        productId: item.productId,
        quantity: item.quantity,
        total: item.total,
      )).toList(),
    );
}