   M S B A M L   `   `   `  ����N  JWPFPersonalTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPersonalTrackingWPFPersonalTracking  5   	   #    WPFPersonalTracking.LoginPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFPersonalTracking     5   	   -   5          � Title$  Personal Tracking Login��5   	   $	��200��6)   $	��350��66    � WindowStartupLocation$ CenterScreen=�6B   ���	#FF8EAFF7 � Icon$ 	/Logo.png��6~   $��18(�6�   $
��Bold"�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��156* �6   �� 5      $	��19* �6   �� 5      $
��175* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��UserNo��6   $
��Left=�6!   $��Center=�6<   $��51,0,0,0q�6W   �� 5   
   -   5         ��Name$ 	txtUserNo��5      $��2��6%   $	��150��65   $
��Left=�6A   $��Center=�6\   6w   �� 5   
   $��Password��6   $
��Left=�6#   $��Center=�6>   $��1��6Y   $��43,0,0,0q�6f   �� 5   
   -   5        $ txtPassword��5      $��1��6'   $��2��64   $	��150��6D   $
��Left=�6P   $��Center=�6k   �� 5   
   -   5         ��Name$ btnLogin��5      $��Login��6#   $��2��63   $��62,0,0,0q�6@   $	��100��6R   $
��Left=�6^   $��Center=�6y   $��2��6�   �� 5   
   -   5        $ btnExit��5      $
��Exit��6"   $��2��61   $��2��6>   $��50,0,0,0q�6N   $	��100��6`   $
��Left=�6l   $��Center=�6�   6�   5      5      