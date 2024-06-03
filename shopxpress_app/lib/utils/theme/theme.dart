import 'package:flutter/material.dart';
import 'package:shopxpress_app/utils/theme/custom_themes/appbar_theme.dart';
import 'package:shopxpress_app/utils/theme/custom_themes/bottom_sheet_theme.dart';
import 'package:shopxpress_app/utils/theme/custom_themes/chip_theme.dart';
import 'package:shopxpress_app/utils/theme/custom_themes/text_field_theme.dart';

import 'custom_themes/elevated_button_theme.dart';
import 'custom_themes/text_theme.dart';

class TAppTheme{
  TAppTheme._();

  static ThemeData lightTheme = ThemeData(
    useMaterial3: true,
    brightness: Brightness.light,
    primaryColor: Colors.blue,
    textTheme: TTextTheme.lightTextTheme,
    chipTheme: TChipTheme.lightChipTheme,
    scaffoldBackgroundColor: Colors.white,
    appBarTheme: TAppBarTheme.lightAppBarTheme,
    bottomSheetTheme: TBottomSheetTheme.lightBottomSheetTheme,
    elevatedButtonTheme: TElevatedButtonTheme.lightElevatedButtonTheme,
    inputDecorationTheme: TTextFormFieldTheme.lightInputDecorationTheme,
  );
}