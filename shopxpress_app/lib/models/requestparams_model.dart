
class RequestParamsModel {
  int? pageNumber;
  int? pageSize;

  RequestParamsModel({this.pageNumber, this.pageSize});

  RequestParamsModel.fromJson(Map<String, dynamic> json)
      : pageNumber = json['pageNumber'] ?? 1,
        pageSize = json['pageSize'] ?? 10;

  Map<String, dynamic> toJson() => {
    'pageNumber': pageNumber,
    'pageSize': pageSize,
  };
}