   M S B A M L   `   `   `  ����J  FPairTradingView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PairTradingView.WpfAppPairTradingView.WpfApp  5   	   '    !PairTradingView.WpfApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:PairTradingView.WpfApp     5   	     � Title$  Pair Trading View��5   	   $	��750��5	   	   $
��1000��5
   	   ���#202020 � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��186* �6   �� 5      $
��133* �6    � ColumnDefinitions 5   
   �� 5      $
��344* �6   �� 5      $
��173* �6   .+�5   
   +   %PairTradingView.WpfApp.MyChartControl  -   5          Name$ chartControl��5      $��0��5      $��0��5      (   "PairTradingView.WpfApp.InfoControl  5   
   -   5          Name$ infoControl��5      $��1��5      $��0��5      ,   &PairTradingView.WpfApp.DataGridControl  5   
   -   5          Name$ dataGridControl��5       
���iii�
�������$��0��5"       $��2��5#       $��1��5$       5&      5'      