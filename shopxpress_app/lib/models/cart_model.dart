import 'cart_item_model.dart';
import 'user_model.dart';

class CartModel{
  final String? id;
  final double? total;
  final String? userId;
  final UserModel? user;
  final List<CartItemModel>? cartItems;

  CartModel({
    this.id,
    this.total,
    this.userId,
    this.user,
    this.cartItems,
  });

  CartModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        total = json['total'] ?? 0.0,
        userId = json['userId'] ?? '',
        user = json['user'] != null ? UserModel.fromJson(json['user']) : null,
        cartItems = json['cartItems'] != null ? (json['cartItems'] as List).map((i) => CartItemModel.fromJson(i)).toList() : [];

  Map<String, dynamic> toJson() => {
    'id': id,
    'total': total,
    'userId': userId,
    'user': user!.toJson(),
    'cartItems': List<dynamic>.from(cartItems!.map((x) => x.toJson())),
  };
}