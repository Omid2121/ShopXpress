import 'package:flutter/material.dart';
import 'package:shopxpress_app/utils/constants/colors.dart';
import 'package:shopxpress_app/utils/constants/sizes.dart';

class TCategoryList extends StatelessWidget {
  const TCategoryList({
    super.key, required this.title, this.textColor = TColors.primary, this.backgroundColor = TColors.light, this.onTap,
  });

  final String title;
  final Color? textColor;
  final Color? backgroundColor;
  final void Function()? onTap;

  @override
  Widget build(BuildContext context) {

    return GestureDetector(
      onTap: onTap,
      child: Padding(
        padding: const EdgeInsets.only(right: TSizes.spaceBtwItems),
        child: Container(
          width: 100,
          height: 50,
          padding: const EdgeInsets.all(TSizes.sm),
          decoration: BoxDecoration(
            color: backgroundColor ?? (Colors.white),
            borderRadius: BorderRadius.circular(100),
          ),
          child: SizedBox(
            width: 20,
            child: Center(
              child: Text(
                title,
                style: Theme.of(context).textTheme.bodyMedium!.apply(color: textColor ?? (TColors.textPrimary)).copyWith(fontSize: TSizes.md, fontWeight: FontWeight.w500),
                maxLines: 1,
                overflow: TextOverflow.ellipsis,
              ),
            ),
          ),
        ),
      ),
    );
  }
}
