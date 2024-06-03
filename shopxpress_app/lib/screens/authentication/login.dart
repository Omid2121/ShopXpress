import 'package:flutter/material.dart';

import '../../common/styles/spacing_styles.dart';
import '../../utils/constants/sizes.dart';
import 'widgets/login_form.dart';
import 'widgets/login_header.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: TSpacingStyle.paddingWithAppBarHeight,
          child: Column(
            children: [
              /// Logo, Title and subtitle
              const TLoginHeader(),
              /// Form
              //TLoginForm()
          Padding(
            padding: const EdgeInsets.symmetric(vertical: TSizes.spaceBtwSections),
            child: TLoginForm(),
          ),
            ],
          )
        )
      )
    );
  }
}



