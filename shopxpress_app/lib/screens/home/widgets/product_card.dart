
import 'package:flutter/material.dart';

import '../../../models/product_model.dart';
import '../../../utils/constants/colors.dart';
import '../../../utils/constants/sizes.dart';

class TProductCard extends StatelessWidget {
  const TProductCard({
    super.key,
    this.width = 170,
    this.aspectRatio = 1.2,
    required this.product,
    required this.onTap,
  });

  final double width;
  final double aspectRatio;
  final ProductModel product;
  final VoidCallback onTap;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onTap,
      child: Column(
        children: [
          SizedBox(
            width: width,
            child: AspectRatio(
              aspectRatio: aspectRatio,
              child: Container(
                padding: const EdgeInsets.all(TSizes.sm),
                decoration: BoxDecoration(
                  color: TColors.lightContainer,
                  borderRadius: BorderRadius.circular(TSizes.md),
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Text(product.title!,
                        style: Theme.of(context)
                            .textTheme
                            .titleMedium!
                            .apply(color: TColors.textPrimary),
                        overflow: TextOverflow.ellipsis),
                    Text(product.description!,
                        style: Theme.of(context)
                            .textTheme
                            .labelLarge!
                            .apply(color: TColors.textPrimary),
                        overflow: TextOverflow.ellipsis),
                    Text(product.manufacturer!,
                        style: Theme.of(context)
                            .textTheme
                            .labelMedium!
                            .apply(color: TColors.textPrimary),
                        overflow: TextOverflow.ellipsis),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text('${product.unitPrice.toString()} kr',
                            style: Theme.of(context)
                                .textTheme
                                .labelLarge!
                                .apply(color: TColors.info),
                            overflow: TextOverflow.ellipsis),
                        Text('${product.stockQuantity} in stock',
                          style: Theme.of(context)
                              .textTheme
                              .labelLarge!
                              .apply(color: TColors.textPrimary).copyWith(color: Colors.red),
                          overflow: TextOverflow.ellipsis,
                          textAlign: TextAlign.right,
                        ),
                      ],
                    )
                  ],
                ),
              ),
            ),
          )
        ],
      ),
    );
  }
}
