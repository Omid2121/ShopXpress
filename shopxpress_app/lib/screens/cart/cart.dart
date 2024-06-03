import 'package:flutter/material.dart';
import 'package:get/get.dart';

import '../../controllers/cart_controller.dart';
import '../../controllers/order_controller.dart';
import '../../models/cart_item_model.dart';
import '../../utils/constants/sizes.dart';

class CartScreen extends StatelessWidget {
  CartScreen({Key? key}) : super(key: key);

  final cartController = Get.find<CartController>();
  final orderController = Get.find<OrderController>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: const Text('Cart'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            /// Expanded widget is used to make the listview scrollable
            Expanded(
              child: Obx(() => cartController.isLoading.value
                  ? const Center(child: CircularProgressIndicator())
                  : cartController.cartItems.isEmpty
                      ? const Center(child: Text('No items in cart'))
                      :
                ListView.builder(
                  itemCount: cartController.cartItems.length,
                  itemBuilder: (context, index) {
                    return Padding(
                      padding: const EdgeInsets.all(6.0),
                      child: Card(
                        child: Dismissible(
                          key: Key(cartController.cartItems[index].id!),
                          onDismissed: (direction) {
                            cartController.deleteCartItem(cartController.cartItems[index].id!);
                          },
                          direction: DismissDirection.endToStart,
                          background: Container(
                            color: Colors.red,
                            child: const Icon(Icons.delete, color: Colors.white),
                          ),
                          child: Padding(
                            padding: const EdgeInsets.symmetric(vertical: 10.0),
                            child: ListTile(
                              title: Column(
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Text(cartController.cartItems[index].productTitle!,
                                    style: const TextStyle(
                                      fontSize: 16,
                                      overflow: TextOverflow.ellipsis,
                                      fontWeight: FontWeight.w600,
                                    ),
                                  ),
                                  const SizedBox(height: TSizes.sm),
                                  Text('Quantity ${cartController.cartItems[index].quantity.toString()}',
                                    style: const TextStyle(
                                      color: Colors.blueGrey,
                                      fontSize: 16,
                                    ),
                                  ),
                                  const SizedBox(height: TSizes.sm),
                                ],
                              ),
                              trailing: Column(
                                children: [
                                  Text('${cartController.cartItems[index].total.toString()} kr',
                                    style: const TextStyle(
                                      color: Colors.blueGrey,
                                      fontSize: 14,
                                      fontWeight: FontWeight.w600,
                                    ),
                                  ),
                                  const SizedBox(height: TSizes.sm),
                                  SizedBox(
                                    height: 30,
                                    width: 60,
                                    child: TextFormField(
                                      // if cartController.quantityController value changes, update cartItem quantity
                                      controller: cartController.quantityController,
                                      onFieldSubmitted: (value) {
                                        if (value == '' || value == '0') {
                                          return;
                                        }
                                        print('Text submitted$value');
                                        cartController.updateCartItem(cartController.cartItems[index].id!);
                                      },
                                      decoration: const InputDecoration(
                                        border: OutlineInputBorder(),
                                      ),
                                    ),
                                  ),
                                ],
                              )
                            ),
                          ),
                        ),
                      ),
                    );
                  },
                ),
              ),
            ),
            /// Expanded widget is used to show the total price at the bottom of the screen
            Expanded(
              flex: 0,
              child: SizedBox(
                width: double.infinity,
                height: 30,
                child: Center(
                  child: Text(
                    'Total: ${cartController.cart.value.total.toString()} kr',
                    style: const TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.w600,
                    ),
                  ),
                ),
              ),
            ),
            const SizedBox(height: TSizes.spaceBtwSections),
            /// TextFormField widget is used to get the address from the user
            TextFormField(
              controller: orderController.addressController,
              decoration: const InputDecoration(
                labelText: 'Address',
                border: OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: TSizes.spaceBtwInputFields),
            /// ElevatedButton widget is used to place the order
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () => orderController.placeOrder(),
                child: const Text('Purchase'),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
