import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:shopxpress_app/controllers/category_controller.dart';
import 'package:shopxpress_app/screens/home/product_details.dart';
import 'package:shopxpress_app/screens/home/widgets/category_list.dart';
import 'package:shopxpress_app/screens/home/widgets/product_card.dart';
import 'package:shopxpress_app/screens/home/widgets/search_container.dart';
import '../../common/widgets/section_heading.dart';
import '../../controllers/product_controller.dart';
import '../../utils/constants/colors.dart';
import '../../utils/constants/sizes.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen({Key? key}) : super(key: key);

  final productController = Get.find<ProductController>();
  final categoryController = Get.find<CategoryController>();

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: SingleChildScrollView(
        padding: const EdgeInsets.only(top: TSizes.defaultSpace),
        child: Column(
          children: [
            /// Search Bar
            const TSearchContainer(),
            const SizedBox(height: TSizes.spaceBtwSections),

            /// Heading and Categories
            Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: TSizes.defaultSpace),
                child: Column(
                  children: [
                    const TSectionHeading(
                        title: 'Categories', textColor: TColors.textPrimary),
                    const SizedBox(height: TSizes.spaceBtwItems),
                    SizedBox(
                      height: 40,
                      child: Obx(() => categoryController.isLoading.value
                          ? const Center(
                              child: CircularProgressIndicator(),
                            )
                          :
                        ListView.builder(
                          shrinkWrap: true,
                          scrollDirection: Axis.horizontal,
                          itemCount: categoryController.categories.length,
                          itemBuilder: (_, index) {
                            return TCategoryList(
                                title: categoryController.categories[index].name!,
                                onTap: () {
                                  productController.getProductsByCategory(
                                      categoryController.categories[index].id!);
                                });
                          },
                        ),
                      ),
                    )
                  ],
                )),
            const SizedBox(height: TSizes.spaceBtwSections),

            const Padding(
              padding: EdgeInsets.symmetric(horizontal: TSizes.defaultSpace),
              child: TSectionHeading(
                  title: 'Products', textColor: TColors.textPrimary),
            ),

            /// Products
            Obx(
              () => productController.isLoading.value
                  ? const Center(child: CircularProgressIndicator())
                  : GridView.builder(
                      shrinkWrap: true,
                      physics: const NeverScrollableScrollPhysics(),
                      itemCount: productController.products.length,
                      gridDelegate:
                          const SliverGridDelegateWithFixedCrossAxisCount(
                        crossAxisCount: 2,
                        childAspectRatio: 1.2,
                      ),
                      itemBuilder: (_, index) {
                        return TProductCard(
                            product: productController.products[index],
                            onTap: () {
                              productController.getProduct(
                                  productController.products[index].id!);
                              Get.to(() => ProductDetailsDialog());
                            }
                        );
                      },
                    ),
            ),
          ],
        ),
      ),
    );
  }
}
