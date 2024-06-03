
import 'order_item_model.dart';

class CreateOrderModel {
  final double total;
  final String address;
  final String userId;
  final List<OrderItemModel> orderItems;

  CreateOrderModel({
    required this.total,
    required this.address,
    required this.userId,
    required this.orderItems,
  });

  CreateOrderModel.fromJson(Map<String, dynamic> json)
      : total = json['total'],
        address = json['address'],
        userId = json['userId'],
        orderItems = json['orderItems'];

  Map<String, dynamic> toJson() => {
    'total': total,
    'address': address,
    'userId': userId,
    'orderItems': orderItems,
  };

}