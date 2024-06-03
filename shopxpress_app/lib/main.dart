import 'package:flutter/material.dart';
import 'package:get/get.dart';

import 'app.dart';
import 'controllers/authentication_controller.dart';
import 'controllers/cart_controller.dart';
import 'controllers/category_controller.dart';
import 'controllers/order_controller.dart';
import 'controllers/product_controller.dart';

void main() {
  Get.lazyPut(() => AuthenticationController());
  Get.lazyPut(() => CartController());
  Get.lazyPut(() => CategoryController());
  Get.lazyPut(() => OrderController());
  Get.lazyPut(() => ProductController());

  runApp(const GetMaterialApp(
    debugShowCheckedModeBanner: false,
    home: App(),
  ));
}