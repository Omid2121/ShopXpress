import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:iconsax/iconsax.dart';

import '../../../controllers/authentication_controller.dart';
import '../../../utils/constants/sizes.dart';
import '../signup.dart';

class TLoginForm extends StatelessWidget {
  TLoginForm({Key? key}) : super(key: key);

  final authController = Get.find<AuthenticationController>();

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: TSizes.spaceBtwSections),
      child: Form(child: Column(
        children: [
          /// Email
          TextFormField(
            controller: authController.emailController,
            decoration: const InputDecoration(
              prefixIcon: Icon(Iconsax.direct_right),
              labelText: "Email",
            ),
          ),
          const SizedBox(height: TSizes.spaceBtwInputFields),
          /// Password
          TextFormField(
            controller: authController.passwordController,
            obscureText: true,
            decoration: const InputDecoration(
              prefixIcon: Icon(Iconsax.lock),
              labelText: "Password",
              suffixIcon: Icon(Iconsax.eye_slash),
            ),
          ),
          const SizedBox(height: TSizes.spaceBtwSections),
          /// Login button
          SizedBox(width: double.infinity, child: ElevatedButton(onPressed: () => authController.login(), child: const Text("Login"))),
          const SizedBox(height: TSizes.spaceBtwItems),
          /// Create account button
          SizedBox(width: double.infinity, child: ElevatedButton(onPressed: () => Get.to(() => const SignupScreen()), child: const Text("Create account"))),
        ],
      )),
    );
  }
}
