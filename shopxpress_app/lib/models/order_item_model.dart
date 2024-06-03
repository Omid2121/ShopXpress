
class OrderItemModel {
  final String? id;
  final int? quantity;
  final double? total;
  final String? productId;
  final String? productTitle;

  OrderItemModel({
    this.id,
    this.quantity,
    this.total,
    this.productId,
    this.productTitle,
  });

  OrderItemModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        quantity = json['quantity'] ?? 0,
        total = json['total'] ?? 0.0,
        productId = json['productId'] ?? '',
        productTitle = json['productTitle'] ?? '';

  Map<String, dynamic> toJson() => {
    'id': id ?? '',
    'quantity': quantity ?? 0,
    'total': total ?? 0,
    'productId': productId ?? '',
    'productTitle': productTitle ?? '',
  };

}