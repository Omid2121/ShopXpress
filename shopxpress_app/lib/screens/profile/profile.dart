import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:iconsax/iconsax.dart';

import '../../controllers/authentication_controller.dart';
import '../../utils/constants/colors.dart';
import '../../utils/constants/sizes.dart';
import '../account/account.dart';
import 'support.dart';
import 'widgets/profile_menu.dart';

class ProfileScreen extends StatelessWidget {
  ProfileScreen({super.key});

  var authController = Get.put(AuthenticationController());

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        leading: const SizedBox(),
        title: const Text('Profile'),
      ),
      body: Column(
        children: [
          const Padding(
            padding: EdgeInsets.symmetric(vertical: TSizes.spaceBtwSections),
            child: Icon(Iconsax.user, size: 100, color: TColors.borderPrimary),
          ),
          TProfileMenu(title: 'My Account', icon: Iconsax.user, press: () => Get.to(() => AccountScreen())),
          TProfileMenu(title: 'Support', icon: Iconsax.message_question, press: () => Get.to(() => const SupportScreen())),
          TProfileMenu(title: 'Delete Account', icon: Iconsax.trash, press: () => authController.deleteAccount()),
          TProfileMenu(title: 'Log out', icon: Iconsax.logout, press: () => authController.logout()),
        ],
      )
    );
  }
}

