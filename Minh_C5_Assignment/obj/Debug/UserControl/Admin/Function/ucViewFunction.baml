   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      '    !Minh_C5_Assignment.ucViewFunction   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Function��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $
��auto �6#   �� 5!      �� 5"      $
��auto �6#   .+�5%      � $��1��6    5&      �� 5'      $
��auto �6'   �� 5(      .+�5*      �� $��Search here...��6   $��5q�5+       �� Padding$ 5q�5,      $��Center=�5-      69   �� 5.      -   5        $��	txtSearch��51      $��5q�5.      $��1��6%   $��5q�5/      $��Center=�50      52   @   53      54      �� 55   
   -   5        $��
stackpanel��55      $��2��56      .+�57      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgFunction��57      $	��500��58      $��5q�59      $	��Top=�5:         	RowHeight$ 30Q�5;         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5<         AutoGenerateColumns .     
IsReadOnly . ��5?      �� *	LstItem+	   Columns	 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5C   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5B   #   �� *Id+5C   #     5D      $

 Name��6)   $	 100 5F   )    5E   #   �� *Name+5F   )     5G      $
 Description��6)    5H   #   �� *Description+  5I      $
 IdParent��6)   $	 100 5K   )    5J   #   �� *
IdParent+5K   )     5L      $
 Status ��6)    5M   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5O      $
 	Activated��6-      
IsReadOnly . $ 60 5Q   )      CellTemplate 5R      �� 5S      .R�5T   "   �� $��	btnUpdate��5U   %   -   5        $��	Activated��5T   )     BtnActivatedStyle#��[ 5V   )   5W   )   5X      5Z        5\      $

 Edit��6-    . $ 50 5^   )    5_      �� 5`      .R�5a   "   �� $��btnEdit��5b   %   -   5        $
��Edit��5a   )     BtnEditStyle#��[ 5c   )   5d   )   5e      5g      5j      5k      #   Minh_C5_Assignment.Pagination  5m   
   -   5          Name$ 
pagination��5m      $
��5 10q�5n      $��45��5o      $��3��5p      5q      5r      