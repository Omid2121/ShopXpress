import 'cart_item_model.dart';
import 'order_item_model.dart';

class ProductModel {
  final String? id;
  final String? title;
  final String? description;
  final String? manufacturer;
  final double? unitPrice;
  final int? stockQuantity;
  final DateTime? createdAt;
  final DateTime? modifiedAt;
  final String? categoryId;
  final String? categoryName;
  final List<CartItemModel>? cartItems;
  final List<OrderItemModel>? orderItems;

  ProductModel({
    this.id,
    this.title,
    this.description,
    this.manufacturer,
    this.unitPrice,
    this.stockQuantity,
    this.createdAt,
    this.modifiedAt,
    this.categoryId,
    this.categoryName,
    this.cartItems,
    this.orderItems,
  });

  ProductModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        title = json['title'] ?? '',
        description = json['description'] ?? '',
        manufacturer = json['manufacturer'] ?? '',
        unitPrice = json['unitPrice'] ?? 0.0,
        stockQuantity = json['stockQuantity'] ?? 0,
        createdAt = DateTime.parse(json['createdAt']),
        modifiedAt = DateTime.parse(json['modifiedAt']),
        categoryId = json['categoryId'] ?? '',
        categoryName = json['categoryName'] ?? '',
        cartItems = json['cartItems'] != null ? (json['cartItems'] as List).map((i) => CartItemModel.fromJson(i)).toList() : [],
        orderItems = json['orderItems'] != null ? (json['orderItems'] as List).map((i) => OrderItemModel.fromJson(i)).toList() : [];

  Map<String, dynamic> toJson() => {
    'id': id,
    'title': title,
    'description': description,
    'manufacturer': manufacturer,
    'unitPrice': unitPrice,
    'stockQuantity': stockQuantity,
    'createdAt': createdAt!.toIso8601String(),
    'modifiedAt': modifiedAt!.toIso8601String(),
    'categoryId': categoryId,
    'categoryName': categoryName,
    'cartItems': List<dynamic>.from(cartItems!.map((x) => x.toJson())),
    'orderItems': List<dynamic>.from(orderItems!.map((x) => x.toJson())),
  };
}