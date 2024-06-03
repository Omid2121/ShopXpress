import 'dart:convert';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get/get.dart';

import '../models/product_model.dart';
import '../models/requestparams_model.dart';
import 'package:http/http.dart' as http;

import '../utils/constants/api_constants.dart';

class ProductController extends GetxController{
  var isLoading = false.obs;
  RxList<ProductModel> products = <ProductModel>[].obs;
  Rx<ProductModel> product = ProductModel().obs;
  var requestParamsModel = RequestParamsModel().obs;
  var token = const FlutterSecureStorage().read(key: 'token');

  @override
  void onInit() {
    super.onInit();
    getProducts(requestParamsModel.value);
  }

  Future<void> getProducts(RequestParamsModel requestParamsModel) async {
    try {
      isLoading(true);
      var response = await http.get(Uri.parse('${TAPIConstants.productsUrl}?PageNumber=${requestParamsModel.pageNumber}&PageSize=${requestParamsModel.pageSize}'),
          headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
      if (response.statusCode == 200) {
        var result = jsonDecode(response.body);
        for (var item in result) {
          products.add(ProductModel.fromJson(item));
        }
      }
    }
    finally {
     isLoading(false);
    }
  }

  Future<void> getProduct(String productId) async {
    var response = await http.get(Uri.parse('${TAPIConstants.productsUrl}/$productId'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 200) {
      var result = jsonDecode(response.body);
      product.value = ProductModel.fromJson(result);
    }
  }

  Future<void> searchProducts(String searchString) async {
    var response = await http.get(Uri.parse('${TAPIConstants.productsUrl}/Search?searchString=$searchString'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
    if (response.statusCode == 200) {
      var result = jsonDecode(response.body);
      products.clear();
      for (var item in result) {
        products.add(ProductModel.fromJson(item));
      }
    }
  }

  Future<void> getProductsByCategory(String categoryId) async {
    try {
      isLoading(true);
      var response = await http.get(Uri.parse('${TAPIConstants.categoriesUrl}/$categoryId/products'),
          headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
      if (response.statusCode == 200) {
        var result = jsonDecode(response.body);
        products.clear();
        for (var item in result) {
          products.add(ProductModel.fromJson(item));
        }
      }
    }
    finally {
      isLoading(false);
    }
  }

}