   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      #    Minh_C5_Assignment.ucViewUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��	View User��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       �� 5!      $
��auto �6#   .+�5$      � $��1��6    5%      �� 5&      $
��auto �6'   �� 5'      .+�5)      �� $��Search here...��6   $��5q�5*       �� Padding$ 5q�5+      $��Center=�5,      69   �� 5-      -   5        $��	txtSearch��50      $��5q�5-      $��1��6%   $��5q�5.      $��Center=�5/      51   @   52      �� 54      -   5        $��btnAdd��58      $��5q�54      $��2��55      $��Add New User��56      $��5q�57      59   ,   5:      �� 5=   
   -   5        $��
stackpanel��5=      $��2��5>      .+�5?      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgUser��5?      $	��500��5@      $��5q�5A      $	��Top=�5C         	RowHeight$ 30Q�5D         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5E         AutoGenerateColumns .     
IsReadOnly . ��5H      �� *	LstItem+	   Columns	 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5L   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5K   #   �� *Id+5L   #     5M      $
 UserName��6)    5N   #   �� *
Username+  5O      $
 Password��6)   $ 80 5Q   )    5P   #   �� *
Password+5Q   )     5R      $
 
Created At��6)    5S   #   �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  5T      $
 Modifited At��6)   $ 80 5V   )    5U   #   �� *
ModifiedAt+$ {0:dd/MM/yyyy}��5V   )     5W      $
 Status ��6)    5X   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5Z      $
 Detail��6-      
IsReadOnly . $ 50 5\   )      CellTemplate 5]      �� 5^      .R�5_   "   �� $��	btnDetail��5a   )   -   5          BtnDetailStyle#��[ 5_   )   $��Detail��5`   )   
����� �5c   )   5d      5f        5h      $
 	Activated��6-    . $ 50 5j   )    5k      �� 5l      .R�5m   "   �� $��	btnUpdate��5n   %   -   5        $��	Activated��5m   )     BtnActivatedStyle#��[ 5o   )   5p   )   5q      5s        5u      $

 Edit��6-    . $ 50 5w   )    5x      �� 5y      .R�5z   "   �� $��btnEdit��5{   %   -   5        $
��Edit��5z   )     BtnEditStyle#��[ 5|   )   5}   )   5~      5�      5�      5�      #   Minh_C5_Assignment.Pagination  5�   
   -	   5          Name$ 
pagination��5�      $
��5 10q�5�      $��45��5�      $��3��5�      5�      5�      