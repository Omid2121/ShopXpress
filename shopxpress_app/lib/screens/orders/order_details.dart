import 'package:flutter/material.dart';
import 'package:get/get.dart';

import '../../controllers/order_controller.dart';
import '../../utils/constants/enums.dart';
import '../../utils/constants/sizes.dart';

class OrderDetailsScreen extends StatelessWidget {
  OrderDetailsScreen({Key? key}) : super(key: key);

  final orderController = Get.find<OrderController>();

  @override
  Widget build(BuildContext context) {
    var order = orderController.order.value;
    String formattedDate(DateTime? date) =>
        date != null ? '${date.day}/${date.month}/${date.year}' : '';

    return Scaffold(
      appBar: AppBar(
        title: const Text('Order Details'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(TSizes.defaultSpace),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Center(
              child: Column(
                children: [
                  const Text(
                    'Order Number',
                    style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                  ),
                  const SizedBox(height: TSizes.spaceBtwItems),
                  Text(
                    order.orderNumber ?? 'N/A',
                    style: const TextStyle(
                      fontSize: 17,
                      fontWeight: FontWeight.w500,
                      overflow: TextOverflow.ellipsis,
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: TSizes.spaceBtwItems),
            Text(
              'Status: ${order.status?.title ?? 'N/A'}',
              style: TextStyle(
                color: (order.status != null
                    ? OrderStatus.values[order.status!.index].color
                    : Colors.black), // Provide a default color or handle it accordingly
                fontWeight: FontWeight.bold,
              ),
            ),
            const SizedBox(height: TSizes.spaceBtwItems),
            Text('Creation Date: ${formattedDate(order.createdAt ?? DateTime.now())}'),
            const SizedBox(height: TSizes.spaceBtwItems),
            Text('Shipping Date: ${formattedDate(order.shippingDate ?? DateTime.now())}'),
            const SizedBox(height: TSizes.spaceBtwItems),
            Text('Address: ${order.address ?? 'N/A'}'),
            const SizedBox(height: TSizes.spaceBtwItems),
            Text('Total: ${order.total ?? 'N/A'} kr'),
            const SizedBox(height: TSizes.spaceBtwItems),
            // show order items
            Expanded(
              child: ListView.builder(
                itemCount: order.orderItems?.length ?? 0,
                itemBuilder: (context, index) {
                  return Card(
                    child: ListTile(
                      title: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Text(order.orderItems?[index].productTitle ?? 'N/A'),
                        ],
                      ),
                      trailing: Column(
                        children: [
                          Text('${order.orderItems?[index].total ?? 0.0} kr'),
                          const SizedBox(height: TSizes.spaceBtwItems),
                          Text(
                              'Amount ${order.orderItems?[index].quantity.toString() ?? 'N/A'}'),
                        ],
                      ),
                    ),
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
