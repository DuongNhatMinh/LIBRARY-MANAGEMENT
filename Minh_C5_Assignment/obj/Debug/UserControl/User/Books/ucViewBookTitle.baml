   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      (    "Minh_C5_Assignment.ucViewBookTitle   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View BookTitles��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      �� 5      $
��auto �6#   .+�5!      � $��1��6    5"      �� 5#      $
��auto �6'   �� 5$      .+�5&      �� $��Search here...��6   $��5q�5'       �� Padding$ 5q�5(      $��Center=�5)      69   �� 5*      -   5        $��	txtSearch��5-      $��5q�5*      $��1��6%   $��5q�5+      $��Center=�5,      5.   @   5/      �� 52      -   5        $��btnAdd��55      $��5q�52      $��Add New User��53      $��5q�54      $��2��57      6(   58      �� 5:   
   -   5        $��
stackpanel��5:      $��2��5;      .+�5<      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgBookTitle��5<      $	��500��5=      $��5q�5>      $	��Top=�5?         	RowHeight$ 30Q�5@         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5A         AutoGenerateColumns .     
IsReadOnly . ��5D      �� *	LstItem+   Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width$
 50 5H   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5G   #   �� *Id+5H   #     5I      $	 Category��6)   $	
 100 5K   )    5J   #   �� *CategoryDTO+5K   )     5L      $
	 Name��6)   $	
 150 5N   )    5M   #   �� *Name+5N   )     5O      $	 Summary��6)   $
 80 5Q   )    5P   #   �� *	Summary+5Q   )   5S      5T      #   Minh_C5_Assignment.Pagination  5V   
   -   5          Name$ 
pagination��5V      $
��5 10q�5W      $��45��5X      $��3��5Y      5[      5\      