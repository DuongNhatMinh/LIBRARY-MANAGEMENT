   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      )    #Minh_C5_Assignment.ucViewParamenter   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������  � 	Resources  5      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Parameter��5      $
��Bold"�5      
����� �$��Center=�5      �� 5   
   $��1��6   .+�5      � $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6'   �� 5!      �� 5"      $
��auto �6'   .+�5%      � $��1��6    5&      �� 5'      $
��auto �6+   �� 5(      .+�5*      �� $��Search here...��6    $��5q�5+       �� Padding$ 5q�5,      $��Center=�5-      69   �� 5.      -   5        $��	txtSearch��51      $��5q�5.      $��1��6)   $��5q�5/      $��Center=�50      52   @   53      �� 56      -   5        $��btnAdd��59      $��5q�56      $��Add New Parameter��57      $��5q�58      $��2��5;      6(   5<      5>      �� 5@   
   -   5        $��
stackpanel��5@      $��2��5A      .+�5B      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgparamenter��5B      $	��500��5C      $��5q�5D      $	��Top=�5E         	RowHeight$ 30Q�5F         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5G         AutoGenerateColumns .     
IsReadOnly . ��5J      �� *	LstItem+	   Columns	 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5N   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   #   �� *Id+5N   #     5O      $

 Name��6)   $	 100 5Q   )    5P   #   �� *Name+5Q   )     5R      $
 Description��6)    5S   #   �� *Description+  5T      $
 Value��6)   $	 100 5V   )    5U   #   �� *Value+5V   )     5W      $
 Status ��6)    5X   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5Z      $
 	Activated��6-      
IsReadOnly . $ 60 5\   )      CellTemplate 5]      �� 5^      .R�5_   "   ��  ��Name$ 	btnUpdate��5a   %   -   5        $��	Activated��5_   )     BtnActivatedStyle#��[ 5`   )   5b   )   5c      5e        5g      $

 Edit��6-    . $ 50 5i   )    5j      �� 5k      .R�5l   "   �� $ btnEdit��5m   %   -   5        $
��Edit��5l   )     BtnEditStyle#��[ 5n   )   5o   )   5p      5r      5u      5v      #   Minh_C5_Assignment.Pagination  5x   
   -   5          Name$ 
pagination��5x      $
��5 10q�5y      $��45��5z      $��3��5{      5}      5~      