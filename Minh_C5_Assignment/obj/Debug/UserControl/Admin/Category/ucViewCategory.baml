   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      '    !Minh_C5_Assignment.ucViewCategory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Category��5      $
��Bold"�5      
����� �$��Center=�5      �� 5   
   $��1��6   .+�5      � $��1��6    � ColumnDefinitions 5       �� 5!      $
��auto �6'   �� 5"      �� 5#      $
��auto �6'   .+�5&      � $��1��6    5'      �� 5(      $
��auto �6+   �� 5)      .+�5+      �� $��Search here...��6    $��5q�5,       �� Padding$ 5q�5-      $��Center=�5.      69   �� 5/      -   5        $��	txtSearch��52      $��5q�5/      $��1��6)   $��5q�50      $��Center=�51      53   @   54      �� 57      -   5        $��btnAdd��5:      $��5q�57      $��Add New Category��58      $��5q�59      $��2��5<      6(   5=      5?      �� 5A   
   -   5        $��
stackpanel��5A      $��2��5B      .+�5C      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgcategory��5C      $	��500��5D      $��5q�5E      $	��Top=�5F         	RowHeight$ 30Q�5G         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5H         AutoGenerateColumns .     
IsReadOnly . ��5K      �� *	LstItem+	   Columns	 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5O   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5N   #   �� *Id+5O   #     5P      $

 Name��6)   $	 100 5R   )    5Q   #   �� *Name+5R   )     5S      $
 Status ��6)    5T   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5c      $

 Edit��6-      
IsReadOnly . $ 50 5e   )      CellTemplate 5f      �� 5g      .R�5h   "   �� $��btnEdit��5i   %   -   5        $
��Edit��5h   )     BtnEditStyle#��[ 5j   )   5k   )   5l      5n      5p      5q      #   Minh_C5_Assignment.Pagination  5s   
   -   5          Name$ 
pagination��5s      $
��5 10q�5t      $��45��5u      $��3��5v      5x      5y      