import 'package:flutter/material.dart';

import '../../../utils/constants/image_strings.dart';
import '../../../utils/constants/sizes.dart';
import '../../../utils/constants/texts.dart';

class TLoginHeader extends StatelessWidget {
  const TLoginHeader({super.key,});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        const Image(
          height: 100,
          image: AssetImage(TImages.lightAppLogo),
        ),
        Text(TTexts.loginTitle, style: Theme.of(context).textTheme.headlineSmall),
        const SizedBox(height: TSizes.sm),
        Text(TTexts.loginSubTitle, style: Theme.of(context).textTheme.bodyLarge),
      ],
    );
  }
}
