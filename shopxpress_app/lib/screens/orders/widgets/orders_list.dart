import 'package:flutter/material.dart';
import 'package:get/get.dart';

import '../../../controllers/order_controller.dart';
import '../../../models/order_model.dart';
import '../../../utils/constants/colors.dart';
import '../../../utils/constants/enums.dart';
import '../../../utils/constants/sizes.dart';
import '../order_details.dart';

class TOrdersList extends StatelessWidget {

  TOrdersList({Key? key, required this.orders}) : super(key: key);

  final List<OrderModel> orders;
  final orderController = Get.find<OrderController>();

  @override
  Widget build(BuildContext context) {
    String formattedDate(DateTime date) => '${date.day}/${date.month}/${date.year}';

    return Obx( () => orderController.isLoading.value
        ? const Center(child: CircularProgressIndicator())
        : orders.isEmpty
        ? const Center(child: Text('No orders'))
        :
      ListView.builder(
        itemCount: orders.length,
        itemBuilder: (context, index) {
          return Card(
            elevation: 4, // Add elevation for a shadow effect
            margin: const EdgeInsets.symmetric(vertical: TSizes.sm),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(TSizes.sm),
            ),
            child: ListTile(
              contentPadding: const EdgeInsets.all(TSizes.md),
              title: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    'Order number: ${orders[index].orderNumber}',
                    style: const TextStyle(
                      overflow: TextOverflow.ellipsis,
                      fontSize: TSizes.md,
                      fontWeight: FontWeight.w600,
                    ),
                  ),
                  const SizedBox(height: 8),
                  Text(
                    'Status: ${OrderStatus.values[orders[index].status!.index].title}',
                    style: TextStyle(
                      color: (OrderStatus.values[orders[index].status!.index].color),
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 8),
                  Text('Created at: ${formattedDate(orders[index].createdAt!)}',
                    style: const TextStyle(
                      fontStyle: FontStyle.italic,
                      fontSize: TSizes.fontSizeSm,
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text('Shipping date: ${formattedDate(orders[index].shippingDate!)}',
                        style: const TextStyle(
                          fontStyle: FontStyle.italic,
                          fontSize: TSizes.fontSizeSm,
                        ),
                      ),
                      Text(
                        'Total: ${orders[index].total}',
                        style: const TextStyle(
                          fontSize: 16,
                          fontWeight: FontWeight.w500,
                          color: TColors.primary,
                        ),
                      ),
                    ],
                  ),
                ],
              ),
              onTap: () {
                orderController.getOrder(orders[index].id!);
                Get.to(() => OrderDetailsScreen());
              }
            ),
          );
        },
      ),
    );
  }
}


