import 'package:flutter/material.dart';
import 'package:iconsax/iconsax.dart';

import '../../../utils/constants/sizes.dart';

class TProfileMenu extends StatelessWidget {
  const TProfileMenu({
    super.key, required this.icon, required this.title, required this.press,
  });

  final IconData icon;
  final String title;
  final void Function() press;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: TSizes.defaultSpace, vertical: TSizes.spaceBtwItems),
      child: ElevatedButton(
        onPressed: press,
        child: SizedBox(
          height: 60,
          child: Row(
            mainAxisSize: MainAxisSize.max,
            children: [
              Icon(icon),
              const SizedBox(width: TSizes.spaceBtwItems),
              Expanded(child: Text(title)),
              const Icon(Iconsax.arrow_right_3),
            ],
          ),
        ),

      ),
    );
  }
}
