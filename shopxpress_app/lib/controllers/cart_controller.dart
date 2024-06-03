import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get/get.dart';
import '../models/cart_model.dart';
import '../models/cart_item_model.dart';
import 'package:http/http.dart' as http;

import '../utils/constants/api_constants.dart';
import '../utils/snackbar/snackbars.dart';
import 'authentication_controller.dart';

class CartController extends GetxController {
  var isLoading = false.obs;
  var cart = CartModel().obs;
  RxList<CartItemModel> cartItems = <CartItemModel>[].obs;
  var authController = Get.find<AuthenticationController>();
  var token = const FlutterSecureStorage().read(key: 'token');
  var quantityController = TextEditingController();

  @override
  void onInit() {
    super.onInit();
    getCart();
  }

  @override
  void onClose() {
    super.onClose();
    quantityController.dispose();
  }

  Future<void> getCart() async {
    var response = await http.get(Uri.parse('${TAPIConstants.cartsUrl}/${authController.user.value.cartId}'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 200) {
      var result = jsonDecode(response.body);
      cart.value = CartModel.fromJson(result);
      cartItems.clear();
      for (var item in result['cartItems']) {
        cartItems.add(CartItemModel.fromJson(item));
      }
    }
  }

  Future<void> addToCart(CartItemModel cartItem) async {
    if (cartItem.quantity == null || cartItem.quantity == 0) {
      TSnackBar.error('Error', 'Please enter a quantity');
      return;
    }
    var response = await http.post(Uri.parse('${TAPIConstants.cartsUrl}/${authController.user.value.cartId}/cartItems'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'},
        body: json.encode(cartItem));
    if (response.statusCode == 201 || response.statusCode == 204) {
      await getCart();
      TSnackBar.success('Success', 'Item added to cart');
    }
  }

  Future<void> updateCartItem(String cartItemId) async {
    var quantity = {'quantity': quantityController.text};

    var response = await http.put(Uri.parse('${TAPIConstants.cartsUrl}/${authController.user.value.cartId}/cartItems/$cartItemId'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'},
        body: json.encode(quantity));
    if (response.statusCode == 204) {
      quantityController.clear();
      await getCart();
      TSnackBar.info('Info', 'Item quantity updated');
    }
  }

  Future<void> deleteCartItem(String cartItemId) async {
    var response = await http.delete(Uri.parse('${TAPIConstants.cartsUrl}/${authController.user.value.cartId}/cartItems/$cartItemId'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 204) {
      cartItems.removeWhere((element) => element.id == cartItemId);
      await getCart();
      TSnackBar.info('Info', 'Item removed from cart');
    }
  }

  Future<void> clearCart(String cartId) async {
    var response = await http.delete(Uri.parse('${TAPIConstants.cartsUrl}/$cartId/cartItems'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 204) {
      cartItems.clear();
    }
  }
}