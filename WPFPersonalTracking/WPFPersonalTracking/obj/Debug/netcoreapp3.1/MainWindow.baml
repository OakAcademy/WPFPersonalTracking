   M S B A M L   `   `   `  ����N  JWPFPersonalTracking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFPersonalTrackingWPFPersonalTracking  5   	   E'clr-namespace:WPFPersonalTracking.ViewsWPFPersonalTracking.Views  5   	   O,clr-namespace:WPFPersonalTracking.ViewModelsWPFPersonalTracking.ViewModels  5   	   $    WPFPersonalTracking.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFPersonalTracking     5   	   9views'clr-namespace:WPFPersonalTracking.Views     5   	   C
viewmodels,clr-namespace:WPFPersonalTracking.ViewModels     5   	   -   5        $��PersonalMainWindow��5
   '     � Title$  WPF Personal Tracking��6	   $	��540��6A   $
��1200��6N    � WindowStartupLocation$ CenterScreen=�6[   $��24(�6�   $
��Bold"�6�   ���	#FF8EAFF7 � Icon$ 	/Logo.png��6�    � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��	/Logo.png��6   �� 5   
   $��1��6-   $��1��6=   $��8��6J   $
��Auto��6[   $��Normal"�6i   $
��Auto��6}   ��6   �� 6}   �� 5   
   -   5         ��Name$ lblWindowName��5      $��Windows Name��6'   $��1��6>   $��Center=�6N   $��
212,10,0,0q�6k   $	��Top=�6   $��24(�6�   �� 5   
   $��1��6   $��0,2,0,0q�6"   .+�5      �� -   5        $��btnEmployee��5   "   $��1��6   $��60��65   $	��250��6A   $
��Left=�6M   .��5       � $	��230��6    5!      �� 5"      $
��auto �6+   �� 5#      $
��auto �6+   .+�5%      �� -   5         ��Name$ EmployeeImage��5%      $
��Left=�63   $
��auto��6N   $��73��6\   $��0,0,0,0q�6g   $��/Employee.png��6x   �� 5&      $��Employee��6    $��1��60   $
��Left=�6@   $��Center=�6[   5'      5)      5+      �� 5,   
   $��2��6   $��0,2,0,0q�6"   .+�5-      �� -   5        $��btnTask��5-   "   $��2��6   $��60��61   $	��250��6=   $
��Left=�6I   .��5.      � $	��230��6    5/      �� 50      $
��auto �6+   �� 51      $
��auto �6+   .+�53      �� -   5        $ 	TaskImage��53      $
��Left=�6/   $
��auto��6J   $��73��6X   $��0,0,0,0q�6c   $��	/Task.png��6t   �� 54      $
��Task��6    $��1��6,   $
��Left=�6<   $��Center=�6W   55      56      57      �� 58   
   $��3��6   $��0,2,0,0q�6"   .+�59      �� -   5        $��	btnSalary��59   "   $��3��6   $��60��63   $	��250��6?   $
��Left=�6K   .��5:      � $	��230��6    5;      �� 5<      $
��auto �6+   �� 5=      $
��auto �6+   .+�5?      �� -   5        $ SalaryImage��5?      $
��Left=�61   $
��auto��6L   $��73��6Z   $��0,0,0,0q�6e   $��/Salary.png��6v   �� 5@      $��Salary��6    $��1��6.   $
��Left=�6>   $��Center=�6Y   5A      5B      5C      �� 5D   
   $��4��6   $��0,2,0,0q�6"   .+�5E      �� -	   5        $��btnPermission��5E   "   $��4��6   $��60��67   $	��250��6C   $
��Left=�6O   .��5F      � $	��230��6    5G      �� 5H      $
��auto �6+   �� 5I      $
��auto �6+   .+�5K      �� -
   5        $ PermissionImage��5K      $
��Left=�65   $
��auto��6P   $��73��6^   $��0,0,0,0q�6i   $��/Permission.png��6z   �� 5L      $��
Permission��6    $��1��62   $
��Left=�6B   $��Center=�6]   5M      5N      5O      �� 5P   
   -   5         ��Name$ stackDepartment��5P      $��5��6.   $��0,2,0,0q�6;   .+�5Q      �� -   5        $��btnDepartment��5Q   "   $��5��6   $��60��67   $	��250��6C   $
��Left=�6O   .��5R      � $	��230��6    5S      �� 5T      $
��auto �6+   �� 5U      $
��auto �6+   .+�5W      �� -   5        $ DpImage��5W      $
��Left=�6-   $
��auto��6H   $��73��6V   $��0,0,0,0q�6a   $��/Department.png��6r   �� 5X      $��
Department��6    $��1��62   $
��Left=�6B   $��Center=�6]   5Y      5Z      5[      �� 5\   
   -   5        $ stackPosition��5\      $��6��6,   $��0,2,0,0q�69   .+�5]      �� -   5        $��btnPosition��5]   "   $��6��6   $��60��65   $	��250��6A   $
��Left=�6M   .��5^      � $	��230��6    5_      �� 5`      $
��auto �6+   �� 5a      $
��auto �6+   .+�5c      �� -   5        $ PositionImage��5c      $
��Left=�63   $
��auto��6N   $��73��6\   $��0,0,0,0q�6g   $��/Position.png��6x   �� 5d      $��Position��6    $��1��60   $
��Left=�6@   $��Center=�6[   5e      5f      5g      �� 5h   
   -   5        $ stacklogoff��5h      $��7��6*   $��0,2,0,0q�67   .+�5i      �� -   5        $��	btnLogOut��5i   "   $��7��6   $��60��63   $	��250��6?   $
��Left=�6K   .��5j      � $	��230��6    5k      �� 5l      $
��auto �6+   �� 5m      $
��auto �6+   .+�5o      �� -   5        $ LogoutImage��5o      $
��Left=�61   $
��auto��6L   $��73��6Z   $��0,0,0,0q�6e   $��/Logout.png��6v   �� 5p      $��Log Out��6    $��1��6/   $
��Left=�6?   $��Center=�6Z   5q      5r      5s      �� 5t   
   -   5        $ 	stackexit��5t      $��8��6(   $��0,2,0,0q�65   .+�5u      �� -   5        $��btnExit��5u   "   $��8��6   $��60��61   $	��250��6=   $
��Left=�6I   .��5v      � $	��230��6    5w      �� 5x      $
��auto �6+   �� 5y      $
��auto �6+   .+�5{      �� -   5        $ 	ExitImage��5{      $
��Left=�6/   $
��auto��6J   $��73��6X   $��0,0,0,0q�6c   $��	/Exit.png��6t   �� 5|      $
��Exit��6    $��1��6,   $
��Left=�6<   $��Center=�6W   5}      5~      5      5�      	 � 	Resources	 5�      
 �� DataType8   2WPFPersonalTracking.ViewModels.DepartmentViewModel.   (WPFPersonalTracking.Views.DepartmentList6   0WPFPersonalTracking.ViewModels.PositionViewModel,   &WPFPersonalTracking.Views.PositionList6   0WPFPersonalTracking.ViewModels.EmployeeViewModel0   *WPFPersonalTracking.Views.EmployeeListView2   ,WPFPersonalTracking.ViewModels.TaskViewModel(   "WPFPersonalTracking.Views.TaskList4	   .WPFPersonalTracking.ViewModels.SalaryViewModel*
   $WPFPersonalTracking.Views.SalaryList8   2WPFPersonalTracking.ViewModels.PermissionViewModel.   (WPFPersonalTracking.Views.PermissionList��%t  (��       5�   3   *, +)(�� R     5�   1   *, +)(�� �     5�   1   *, +)(�� �     5�   -   *, +)(�� >    5�   /   *,	 +)(�� �    5�   3   *, +)�� 5�   
   DepartmentTemplate��"
  63   .R�5�        5�      5�      �� 5�   
   PositionTemplate��"
  61   .R�5�        5�      5�      �� 5�   
   Employeetemplate��"
  61   .R�5�        5�      5�      �� 5�   
   TaskTemplate��"
  6-   .R�5�        5�      5�      �� 5�   
   salarytemplate��"
 	 6/   .R�5�      
  5�      5�      �� 5�   
   Permissiontemplate��"
  63   .R�5�        5�      5�      5�      5�      