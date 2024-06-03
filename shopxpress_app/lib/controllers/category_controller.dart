import 'dart:convert';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:get/get.dart';

import '../models/category_model.dart';
import 'package:http/http.dart' as http;
import '../utils/constants/api_constants.dart';

class CategoryController extends GetxController{
  var isLoading = false.obs;
  var categories = <CategoryModel>[].obs;
  var token = const FlutterSecureStorage().read(key: 'token');

  @override
  void onInit() {
    super.onInit();
    getCategories();
  }

  Future<void> getCategories() async {
    try{
     isLoading(true);
     var response = await http.get(Uri.parse(TAPIConstants.categoriesUrl),
         headers: {'Content-type': 'application/json', 'Authorization': 'Bearer ${await token}'});
      if(response.statusCode == 200){
        var result = jsonDecode(response.body);
        //categories.clear();
        for(var item in result){
          categories.add(CategoryModel.fromJson(item));
        }
      }
    }
    finally{
      isLoading(false);
    }
  }
}