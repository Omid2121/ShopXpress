import 'product_model.dart';

class CategoryModel {
  final String? id;
  final String? name;
  final List<ProductModel>? products;

  CategoryModel({
    this.id,
    this.name,
    this.products,
  });

  CategoryModel.fromJson(Map<String, dynamic> json)
      : id = json['id'] ?? '',
        name = json['name'] ?? '',
        products = json['products'] != null ? (json['products'] as List).map((i) => ProductModel.fromJson(i)).toList() : [];

  Map<String, dynamic> toJson() => {
    'id': id,
    'name': name,
    'products': List<dynamic>.from(products!.map((x) => x.toJson())),
  };
}