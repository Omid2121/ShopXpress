import 'dart:convert';

import 'package:flutter/foundation.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:http/http.dart' as http;

class THttpHelper {
  static const String _baseUrl = "https://shopxpressapi.azurewebsites.net/api";
  var storage = const FlutterSecureStorage();

  static Future<Map<String, dynamic>> getWithToken(String endpoint, String? token) async {
    final response = await http.get(
        Uri.parse('$_baseUrl/$endpoint'), headers: {'Content-type': 'application/json', 'Authorization': 'Bearer $token'});
    return _handleResponse(response);
  }

  static Future<Map<String, dynamic>> post(String endpoint, dynamic data) async {
    final response = await http.post(Uri.parse('$_baseUrl/$endpoint'),
        headers: {'Content-type': 'application/json'},
      body: json.encode(data)
    );
    return _handleResponse(response);
  }

  static Future<Map<String, dynamic>> postWithToken(String endpoint, String? token, dynamic data) async {
    final response = await http.post(Uri.parse('$_baseUrl/$endpoint'),
        headers: {'Content-type': 'application/json', 'Authorization': 'Bearer $token'},
        body: json.encode(data)
    );
    return _handleResponse(response);
  }

  static Future<Map<String, dynamic>> putWithToken(String endpoint, String? token, dynamic data) async {
    final response = await http.put(
        Uri.parse('$_baseUrl/$endpoint'),
        headers: {'Content-type': 'application/json'},
        body: json.encode(data)
    );
    return _handleResponse(response);
  }

  static Future<Map<String, dynamic>> deleteWithToken(String endpoint, String? token) async {
    final response = await http.delete(Uri.parse('$_baseUrl/$endpoint'));
    return _handleResponse(response);
  }

  static Future<Map<String, dynamic>> _handleResponse(http.Response response) {
    if (response.statusCode == 200 || response.statusCode == 201 || response.statusCode == 202 || response.statusCode == 204) {
      return json.decode(response.body);
    } else{
      if (kDebugMode) {
        print('Failed to load data. Status Code: ${response.statusCode}');
        print('Response Body: ${response.body}');
      }
      throw Exception('Failed to load data: ${response.statusCode}');
    }
  }

}