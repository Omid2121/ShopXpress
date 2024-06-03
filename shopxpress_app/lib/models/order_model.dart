import '../utils/constants/enums.dart';
import 'order_item_model.dart';
import 'user_model.dart';

class OrderModel {
  final String? id;
  final String? orderNumber;
  final DateTime? createdAt;
  final DateTime? shippingDate;
  final OrderStatus? status;
  final double? total;
  final String? address;
  final String? userId;
  final UserModel? user;
  final List<OrderItemModel>? orderItems;

  OrderModel({
    this.id,
    this.orderNumber,
    this.createdAt,
    this.shippingDate,
    this.status,
    this.total,
    this.address,
    this.userId,
    this.user,
    this.orderItems,
  });

  OrderModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        orderNumber = json['orderNumber'] ?? '',
        createdAt = DateTime.parse(json['createdAt']),
        shippingDate = DateTime.parse(json['shippingDate']),
        status = OrderStatus.values[json['status'] ?? 0],
        total = json['total'] ?? 0.0,
        address = json['address'] ?? '',
        userId = json['userId'] ?? '',
        user = json['user'] != null ? UserModel.fromJson(json['user']) : null,
        orderItems = json['orderItems'] != null ? (json['orderItems'] as List).map((i) => OrderItemModel.fromJson(i)).toList() : [];

  Map<String, dynamic> toJson() => {
    'id': id,
    'orderNumber': orderNumber,
    'createdAt': createdAt?.toIso8601String(),
    'shippingDate': shippingDate?.toIso8601String(),
    'status': status?.index,
    'total': total,
    'address': address,
    'userId': userId,
    'user': user?.toJson(),
    'orderItems': List<dynamic>.from(orderItems?.map((x) => x.toJson()) ?? []),
  };
}