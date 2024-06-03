import 'package:flutter/material.dart';

import '../../utils/constants/sizes.dart';

class SupportScreen extends StatelessWidget {
  const SupportScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Support'),
      ),
      body: Center(
        child: Padding(
          padding: const EdgeInsets.all(TSizes.defaultSpace),
          child: Column(
            children: [
              // make this title bold
              const Text('Information', style: TextStyle(fontSize: TSizes.lg ,fontWeight: FontWeight.bold)),
              const SizedBox(height: TSizes.spaceBtwItems),
              const Text('My contact info. You can contact me if you have any questions about this app.'),
              const SizedBox(height: TSizes.spaceBtwSections),
              TextField(
                controller: TextEditingController(text: 'Omidreza Ahanginashroudkoli'),
                readOnly: true,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Full Name',
                ),
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              TextField(
                controller: TextEditingController(text: 'omid_ahangi2000@yahoo.com'),
                readOnly: true,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Email',
                ),
              ),
              const SizedBox(height: TSizes.spaceBtwItems),
              TextField(
                controller: TextEditingController(text: '27 15 94 27'),
                readOnly: true,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Phone Number',
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
