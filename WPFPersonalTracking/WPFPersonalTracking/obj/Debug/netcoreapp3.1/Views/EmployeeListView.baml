   M S B A M L   `   `   `  ����N  JWPFPersonalTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:WPFPersonalTracking.ViewsWPFPersonalTracking.Views  5      0    *WPFPersonalTracking.Views.EmployeeListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:WPFPersonalTracking.Views     5      -   5        $��18(�5   #   $
��Bold"�61   .��5	      �   � RowDefinitions  5
   
   �� 5      $��3* �6   �� 5      $��6* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridEmployee��5      $��1��6)   $��5��66      AutoGenerateColumns$ False��6J      
IsReadOnly$
 True��6f      SelectionMode$ Single=�6x      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6!      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-   	   
Visibility$	 Hidden=�6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *Id+6N     5      $ UserNo��6!   $ * 61   
 6;   �� *UserNo+  5      $
 Name��6!   $ * 6/   
 69   �� *Name+  5      $ Surname��6!   $ * 62   
 6<   �� *	Surname+  5      $ Position Name��6!   $ * 68   
 6B   �� *PositionName+  5      $ Department Name��6!   $ * 6:   
 6D   �� *DepartmentName+  5      $ Salary��6!   $ * 61   
 6;   �� *Salary+  5      $ 
PositionId��6!   $ * 65   $	 Hidden=�6^   
 6?   �� *
PositionId+6^     5       $ DepartmentId��6!   $ * 67   $	 Hidden=�6b   
 6A   �� *DepartmentId+6b     5!      $ isAdmin��6!   $ * 62   $	 Hidden=�6X   
 6<   �� *	isAdmin+6X     5"      $ BirthDay��6!   $ * 63   $	 Hidden=�6Z   
 6=   �� *
BirthDay+6Z     5#      $ Adress��6!   $ * 61   $	 Hidden=�6V   
 6;   �� *Adress+6V     5$      $ Password��6!   $ * 63   $	 Hidden=�6Z   
 6=   �� *
Password+6Z     5%      $ 	ImagePath��6!   $ * 64   $	 Hidden=�6\   
 6>   �� *	ImagePath+6\   5'      � 5(   
   $��5��6     5)      �� 5*      �� 5+      �� 5,       5.      �� 5/      $	��60* �6#   �� 50      $
��100* �6#   �� 51      $	��60* �6#   �� 52      $
��100* �6#   �� 53      $	��80* �6#   .+�55      �� $��UserNo��6   $��34��6%   $��78��61   $
��Left=�6<   $��Center=�6W   �� 56      -   5         ��Name$ 	txtUserNo��56      $��1��6)    �� TextWrapping$
 Wrap=�69   $��0,0,0,0q�6M   $��26��6^   �� 57      $
��Name��6   $��1��6#   $��34��60   $��78��6<   $
��Left=�6G   $��Center=�6b   �� 58      -   5        $ txtName��58      $��1��6'   $��1��64   $
 Wrap=�6D   $��0,0,0,0q�6X   $��26��6i   �� 59      $��Surname��6   $��2��6&   $��34��63   $	��100��6?   $
��Left=�6K   $��Center=�6f   �� 5:      -   5        $ 
txtSurname��5:      $��2��6*   $��1��67   $
 Wrap=�6G   $��0,0,0,0q�6[   $��26��6l   �� 5;      $��
Department��6   $
��auto��6)   $
��Left=�66   $��Center=�6Q   $��34��6l   $��2��6x   �� 5<      -   5        $��cmbDepartment��5<      $��3��6,   $��Center=�6<   $��30��6W   $��0,0,0,0q�6c   6t   �� 5=      $��Position��6   $
��auto��6'   $��1��64   $
��Left=�6A   $��Center=�6\   $��34��6w   $��2��6�   �� 5>      -   5        $��cmbPosition��5>      $��3��6*   $��1��6:   $��Center=�6G   $��30��6b   $��0,0,0,0q�6n   �� 5?      -   5        $��	btnSearch��5?   6   $��4��6   $��Search��6%   $��	20,5,10,5q�6G   6Z   �� 5@      -	   5        $��btnClear��5@   B   $��4��6   $��1��6%   $��Clear��62   $��	20,5,10,5q�6R   6e   5A      �� 5B   
   -
   5         ��Name$ btnAdd��5B      $	��Add��6!   $��18(�6/   $
��Bold"�6=   $��1��6O   $��2��6_   $��	40,5,40,5q�6l   6   �� 5C   
   -   5        $ 	btnUpdate��5C      $��Update��6$   $��18(�65   $
��Bold"�6C   $��2��6U   $��2��6e   $��	40,5,40,5q�6r   6�   �� 5D   
   -   5        $ 	btnDelete��5D      $��Delete��6$   $��18(�65   $
��Bold"�6C   $��3��6U   $��2��6e   $��	40,5,40,5q�6r   6�   5E      5F      