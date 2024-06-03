import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:shopxpress_app/models/cart_item_model.dart';

import '../../controllers/cart_controller.dart';
import '../../controllers/product_controller.dart';
import '../../utils/constants/sizes.dart';

class ProductDetailsDialog extends StatelessWidget {
  ProductDetailsDialog({Key? key}) : super(key: key);

  final productController = Get.find<ProductController>();
  final cartController = Get.find<CartController>();

  @override
  Widget build(BuildContext context) {
    return Obx(() =>
      Dialog(
        child: Container(
          padding: const EdgeInsets.all(TSizes.defaultSpace),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              Row(
                children: [
                  Expanded(
                    child: Text(
                      productController.product.value.title ?? '',
                      style: const TextStyle(
                          fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                  ),
                  IconButton(
                      onPressed: () {
                        Get.back();
                      },
                      icon: const Icon(Icons.close))
                ],
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              Row(
                children: [
                  Expanded(
                    child: Text(
                      productController.product.value.description ?? '',
                      maxLines: 4,
                      style: const TextStyle(fontSize: 16, overflow: TextOverflow.ellipsis),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              Row(
                children: [
                  Expanded(
                    child: Text(
                      productController.product.value.manufacturer ?? '',
                      style: const TextStyle(
                          fontSize: 16, fontWeight: FontWeight.w500,
                          color: Colors.blueGrey,
                      ),
                    ),
                  )
                ],
              ),
              const SizedBox(height: TSizes.xs),
              Row(
                children: [
                  Expanded(
                    child: Text(
                      'Product type: ${productController.product.value.categoryName ?? ''}',
                      style: const TextStyle(
                        fontSize: 14, fontWeight: FontWeight.w500,
                        color: Colors.grey,
                      ),
                    ),
                  )
                ],
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              Row(
                children: [
                  Expanded(
                    child: Text(
                      '\$${productController.product.value.unitPrice ?? 0.0}',
                      style: const TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Colors.green),
                    ),
                  ),
                  Expanded(
                    flex: 0,
                    child: Text(
                      '${productController.product.value.stockQuantity ?? 0} left in stock',
                      style: const TextStyle(fontSize: 16, color: Colors.orange),
                    ),
                  )
                ],
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              Row(
                children: [
                  Expanded(
                    child: TextField(
                      controller: cartController.quantityController,
                      keyboardType: TextInputType.number,
                      decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          hintText: 'Enter quantity'),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              Row(
                children: [
                  Expanded(
                    child: ElevatedButton(
                        onPressed: () {
                          cartController.addToCart(CartItemModel(
                              productId: productController.product.value.id,
                              quantity: int.parse(
                                  cartController.quantityController.text)));
                          Get.back();
                        },
                        child: const Text('Add to Cart')),
                  ),
                ],
              ),
            ],
          ),
        )
      ),
    );
  }
}
