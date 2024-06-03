import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get/get.dart';
import 'package:shopxpress_app/controllers/product_controller.dart';
import 'package:shopxpress_app/utils/snackbar/snackbars.dart';
import '../models/user_model.dart';
import 'package:http/http.dart' as http;

import '../navigation_menu.dart';
import '../screens/authentication/login.dart';
import '../utils/constants/api_constants.dart';
import '../utils/validators/auth_validators.dart';
import 'cart_controller.dart';
import 'category_controller.dart';
import 'order_controller.dart';

class AuthenticationController extends GetxController {
  var isLoggedIn = false.obs;
  var user = UserModel().obs;
  var storage = const FlutterSecureStorage();
  var token = const FlutterSecureStorage().read(key: 'token');
  var firstNameController = TextEditingController();
  var lastNameController = TextEditingController();
  var addressController = TextEditingController();
  var phoneNumberController = TextEditingController();
  var emailController = TextEditingController();
  var passwordController = TextEditingController();

  @override
  void onInit() {
    super.onInit();
    checkLogin();
  }

  @override
  void onClose() {
    super.onClose();
    firstNameController.dispose();
    lastNameController.dispose();
    addressController.dispose();
    phoneNumberController.dispose();
    emailController.dispose();
    passwordController.dispose();
  }

  void checkLogin() async {
    var token = await storage.read(key: 'token');
    if (token != null) {
      isLoggedIn.value = true;
      await getUser();
      Get.off(() => const NavigationMenu());
    } else {
      isLoggedIn.value = false;
      Get.off( () => const LoginScreen());
    }
  }

  Future<void> login() async {
    TAuthValidators.loginValidator(
        emailController.text,
        passwordController.text);

    var body = {
      'email': emailController.text,
      'password': passwordController.text,
    };
    final response = await http.post(Uri.parse(TAPIConstants.loginUrl),
        headers: {'Content-type': 'application/json'},
        body: json.encode(body));
    if (response.statusCode == 202) {
      var token = json.decode(response.body)['token'];
      await storage.write(key: 'token', value: token);
      isLoggedIn.value = true;
      initializeControllers();
      await getUser();
      Get.to(() => const NavigationMenu());
      TSnackBar.info('Success', 'Login successful');
    }
  }

  void initializeControllers() {
    Get.lazyPut(() => AuthenticationController());
    Get.lazyPut(() => CartController());
    Get.lazyPut(() => CategoryController());
    Get.lazyPut(() => OrderController());
    Get.lazyPut(() => ProductController());
  }

  Future<void> register() async {
    TAuthValidators.registerValidator(
        firstNameController.text,
        lastNameController.text,
        addressController.text,
        phoneNumberController.text,
        emailController.text,
        passwordController.text);

    var body = {
      'firstName': firstNameController.text,
      'lastName': lastNameController.text,
      'address': addressController.text,
      'phoneNumber': phoneNumberController.text,
      'email': emailController.text,
      'password': passwordController.text,
    };
    final response = await http.post(Uri.parse(TAPIConstants.registerUrl),
        headers: {'Content-type': 'application/json'},
        body: json.encode(body));
    if (response.statusCode == 202) {
      isLoggedIn.value = false;
      Get.to(() => const LoginScreen());
      TSnackBar.info('Success', 'Account created successfully');
    }
  }

  Future<void> updateUser() async {
    var body = {
      'firstName': firstNameController.text,
      'lastName': lastNameController.text,
      'address': addressController.text,
      'phoneNumber': phoneNumberController.text,
    };
    final response = await http.put(Uri.parse('${TAPIConstants.accountsUrl}/update/${user.value.id}'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'},
        body: json.encode(body));
    if (response.statusCode == 204) {
      var result = jsonDecode(response.body);
      user.value = UserModel.fromJson(result);
      Get.snackbar(
        'Success',
        'Account updated successfully',
        snackPosition: SnackPosition.BOTTOM,
        backgroundColor: Colors.green,
        colorText: Colors.white,
      );
    }
  }

  Future<void> deleteAccount() async {
    var body = {
      'email': emailController.text,
      'password': passwordController.text,
    };
    final response = await http.delete(Uri.parse('${TAPIConstants.accountsUrl}/delete'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'},
        body: json.encode(body));
    if (response.statusCode == 204) {
      logout();
      TSnackBar.info('Success', 'Account deleted successfully');
    }
  }

  void logout() async {
    await storage.delete(key: 'token');
    isLoggedIn.value = false;
    user.value = UserModel();
    Get.offAll(() => const LoginScreen());
  }

  Future<void> getUser() async {
    var response = await http.get(Uri.parse('${TAPIConstants.accountsUrl}/user'),
        headers: {'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 200) {
      var result = jsonDecode(response.body);
      user.value = UserModel.fromJson(result);
      firstNameController.text = user.value.firstName!;
      lastNameController.text = user.value.lastName!;
      addressController.text = user.value.address!;
      phoneNumberController.text = user.value.phoneNumber!;
      emailController.text = user.value.email!;
    }
  }
}