import 'package:flutter/material.dart';
import 'package:shopxpress_app/utils/theme/theme.dart';

import 'screens/authentication/login.dart';

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      themeMode: ThemeMode.system,
      theme: TAppTheme.lightTheme,
      home: LoginScreen(),
    );
  }
}