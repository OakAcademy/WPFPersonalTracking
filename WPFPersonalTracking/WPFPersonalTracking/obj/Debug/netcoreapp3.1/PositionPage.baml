   M S B A M L   `   `   `  ����N  JWPFPersonalTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPersonalTrackingWPFPersonalTracking  5   	   &     WPFPersonalTracking.PositionPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFPersonalTracking     5   	   -   5          � Title$  Position Page��5   	   $	��200��6   $	��350��6,   ���	#FF8EAFF7 � Icon$ 	/Logo.png��6O   $��18(�6`   $
��Bold"�6n    � WindowStartupLocation$ CenterScreen=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��
Department��6   $��Center=�6%   $��Center=�6B   �� 5   
   $��Position Name��6   $��1��6(   $��Center=�65   $��Center=�6R   �� 5   
   -   5        $��cmbDepartment��5      $��1��6(   $	��150��68   $
��Left=�6D   $��Center=�6_   �� 5   
   -   5         ��Name$ txtPositionname��5      $��1��6+   $��1��68   $	��150��6H    �� TextWrapping$
 Wrap=�6T   $
��Left=�6h   $��Center=�6�   �� 5   
   -   5         ��Name$ btnSave��5      $
��Save��6"   $��2��61   $��50,0,0,0q�6>   $	��100��6P   $��Center=�6\   $��Center=�6y   6�   �� 5   
   -   5        $ btnClose��5      $��Close��6#   $��1��63   $��2��6C   $	��100��6P   $��0,0,50,0q�6\   $��Center=�6n   $��Center=�6�   6�   5      5      