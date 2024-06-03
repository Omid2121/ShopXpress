
import 'package:flutter/material.dart';
import 'package:shopxpress_app/utils/constants/colors.dart';
import 'package:shopxpress_app/utils/constants/sizes.dart';

class TRoundedContainer extends StatelessWidget {
  const TRoundedContainer({super.key, this.height, this.width, this.radius = TSizes.md, this.child, this.showBorder = false, this.borderColor = TColors.borderPrimary, this.backgroundColor = TColors.light, this.padding, this.margin});

  final double? height;
  final double? width;
  final double radius;
  final Widget? child;
  final bool showBorder;
  final Color borderColor;
  final Color backgroundColor;
  final EdgeInsetsGeometry? padding;
  final EdgeInsetsGeometry? margin;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: width,
      height: height,
      padding: padding,
      margin: margin,
      decoration: BoxDecoration(
        color: backgroundColor,
        borderRadius: BorderRadius.circular(radius),
        border: showBorder ? Border.all(color: borderColor) : null,
      ),
    );
  }
}
