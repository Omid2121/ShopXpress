import 'package:flutter/material.dart';

enum OrderStatus {
  processing(
    title: 'Processing',
    color: Colors.orange,
  ),
  inTransit(
    title: 'In transit',
    color: Colors.blue,
  ),
  delivered(
    title: 'Delivered',
    color: Colors.green,
  );


  final String title;
  final Color color;

  const OrderStatus({
    required this.title,
    required this.color,
  });
}