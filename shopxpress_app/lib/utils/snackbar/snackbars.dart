import 'package:get/get.dart';

import '../constants/colors.dart';

class TSnackBar {
  static SnackbarController success(String title, String message) {
    return Get.snackbar(title, message,
        snackPosition: SnackPosition.TOP,
        colorText: TColors.light,
        backgroundColor: TColors.success);
  }

  static SnackbarController error(String title, String message) {
    return Get.snackbar(title, message,
        snackPosition: SnackPosition.TOP,
        colorText: TColors.light,
        backgroundColor: TColors.error);
  }

  static SnackbarController info(String title, String message) {
    return Get.snackbar(title, message,
        snackPosition: SnackPosition.TOP,
        colorText: TColors.light,
        backgroundColor: TColors.info);
  }

}