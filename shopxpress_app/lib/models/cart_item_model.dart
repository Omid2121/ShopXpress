
class CartItemModel {
  final String? id;
  final double? total;
  final String? productTitle;
  final int? quantity;
  final String? productId;

  CartItemModel({
    this.id,
    this.total,
    this.productTitle,
    this.quantity,
    this.productId,
  });

  CartItemModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        total = json['total'] ?? 0.0,
        productTitle = json['productTitle'] ?? '',
        quantity = json['quantity'] ?? 0,
        productId = json['productId'] ?? '';

  Map<String, dynamic> toJson() => {
    'id': id,
    'total': total,
    'productTitle': productTitle,
    'quantity': quantity,
    'productId': productId,
  };
}