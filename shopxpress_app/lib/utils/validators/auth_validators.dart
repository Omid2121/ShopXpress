import 'package:get/get.dart';

class TAuthValidators {
  static SnackbarController? loginValidator(String email, String password) {
    if (email.isEmpty) {
      return Get.snackbar('Error', 'Email is required');
    }
    if (password.isEmpty) {
      return Get.snackbar('Error', 'Password is required');
    }
    if (password.length < 6) {
      return Get.snackbar('Error', 'Password must be at least 6 characters');
    }
  }

  static SnackbarController? registerValidator(String firstName, String lastName, String address, String phoneNumber, String email, String password) {
    if (firstName.isEmpty) {
      return Get.snackbar('Error', 'First name is required');
    }
    if (lastName.isEmpty) {
      return Get.snackbar('Error', 'Last name is required');
    }
    if (address.isEmpty) {
      return Get.snackbar('Error', 'Address is required');
    }
    if (phoneNumber.isEmpty) {
      return Get.snackbar('Error', 'Phone number is required');
    }
    if (email.isEmpty) {
      Get.snackbar('Error', 'Email is required');
    }
    if (password.isEmpty) {
      return Get.snackbar('Error', 'Password is required');
    }
    if (password.length < 8) {
      return Get.snackbar('Error', 'Password must be at least 8 characters');
    }
  }
}