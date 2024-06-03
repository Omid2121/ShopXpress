import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:iconsax/iconsax.dart';
import 'package:shopxpress_app/utils/constants/colors.dart';
import 'package:shopxpress_app/utils/constants/sizes.dart';

import '../../cart/cart.dart';

class TSearchContainer extends StatelessWidget {
  const TSearchContainer({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: TSizes.spaceBtwItems),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Container(
            width: MediaQuery.of(context).size.width * 0.7,
            height: 50,
            decoration: BoxDecoration(
              color: TColors.lightContainer,
              borderRadius: BorderRadius.circular(TSizes.md),
              border: Border.all(color: TColors.light),
            ),
            child: TextField(
              decoration: InputDecoration(
                hintText: 'Search',
                hintStyle: Theme.of(context).textTheme.bodyMedium!.apply(color: TColors.textSecondary),
                border: InputBorder.none,
                prefixIcon: const Icon(Iconsax.search_normal, color: TColors.textPrimary),
              ),
            ),
          ),
          Container(
              height: 50,
              width: MediaQuery.of(context).size.width * 0.2,
              decoration: BoxDecoration(
                color: TColors.lightContainer,
                shape: BoxShape.circle,
                border: Border.all(color: TColors.light),
              ),
              child: IconButton(
                onPressed: () => Get.to(() => CartScreen()),
                icon: const Icon(Iconsax.shopping_cart, color: TColors.textPrimary),
              )
          )
        ],
      ),
    );
  }
}
