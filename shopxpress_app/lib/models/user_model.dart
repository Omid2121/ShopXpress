import 'cart_model.dart';
import 'order_model.dart';

class UserModel {
  final String? id;
  final String? firstName;
  final String? lastName;
  final String? email;
  final String? password;
  final String? phoneNumber;
  final String? cartId;
  final CartModel? cart;
  final String? address;
  final List<OrderModel>? orders;

  UserModel({
    this.id,
    this.firstName,
    this.lastName,
    this.email,
    this.password,
    this.phoneNumber,
    this.cartId,
    this.cart,
    this.address,
    this.orders,
  });

  UserModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        firstName = json['firstName'] ?? '',
        lastName = json['lastName'] ?? '',
        email = json['email'] ?? '',
        password = json['password'] ?? '',
        phoneNumber = json['phoneNumber'] ?? '',
        cartId = json['cartId'] ?? '',
        cart = json['cart'] != null ? CartModel.fromJson(json['cart']) : null,
        address = json['address'] ?? '',
        orders = json['orders'] != null ? (json['orders'] as List).map((i) => OrderModel.fromJson(i)).toList() : [];

  Map<String, dynamic> toJson() => {
    'id': id,
    'firstName': firstName,
    'lastName': lastName,
    'email': email,
    'password': password,
    'phoneNumber': phoneNumber,
    'cartId': cartId,
    'cart': cart!.toJson(),
    'address': address,
    'orders': List<dynamic>.from(orders!.map((x) => x.toJson())),
  };
}