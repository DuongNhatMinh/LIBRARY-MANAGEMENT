   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      %    Minh_C5_Assignment.ucSwitchRole   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��	View Role��5      $
��Bold"�5      
����� �$��Center=�5      �� 5   
   $��1��6   .+�5      � $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6'   �� 5!      �� 5"      $
��auto �6'   .+�5%      � $��1��6    5&      �� 5'      $
��auto �6+   �� 5(      .+�5*      �� $��Search here...��6    $��5q�5+       �� Padding$ 5q�5,      $��Center=�5-      69   �� 5.      -   5        $��	txtSearch��51      $��5q�5.      $��1��6)   $��5q�5/      $��Center=�50      52   @   53      �� 56      -   5        $��btnAdd��59      $��5q�56      $��Add New Role��57      $��5q�58      $��2��5;      6(   5<      5=      �� 5?   
   -   5        $��
stackpanel��5?      $��2��5@      .+�5A      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgUser��5A      $	��500��5B      $��5q�5C      $	��Top=�5D         	RowHeight$ 30Q�5E         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5F         AutoGenerateColumns .     
IsReadOnly . ��5I      �� *	LstItem+	   Columns	 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5M   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   #   �� *Id+5M   #     5N      $
 UserName��6)    5O   #   �� *
UserName+  5P      $
 Password��6)   $ 80 5R   )    5Q   #   �� *
Password+5R   )     5S      $
 RoleName��6)   $ 80 5U   )    5T   #   �� *
RoleName+5U   )     5V      $
 
Created At��6)    5W   #   �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  5X      $
 Modifited At��6)   $ 80 5Z   )    5Y   #   �� *ModifitedAt+$ {0:dd/MM/yyyy}��5Z   )     5[      $
 Status ��6)    5\   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5^      $
 SetRole��6-      
IsReadOnly . $ 60 5`   )      CellTemplate 5a      �� 5b      .R�5c   "   �� $��btnSet��5d   %   -   5        $��SetRole��5c   )   
����� �5f   )   5g      5i      5l      5m      #   Minh_C5_Assignment.Pagination  5n   
   -   5          Name$ 
pagination��5n      $
��5 10q�5o      $��45��5p      $��3��5q      5s      5t      