   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      '    !Minh_C5_Assignment.ucViewBookISBN   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View BookISBNs��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       �� 5!      $
��auto �6#   .+�5$      � $��1��6    5%      �� 5&      $
��auto �6'   �� 5'      .+�5)      �� $��Search here...��6   $��5q�5*       �� Padding$ 5q�5+      $��Center=�5,      69   �� 5-      -   5        $��	txtSearch��50      $��5q�5-      $��1��6%   $��5q�5.      $��Center=�5/      51   @   52      �� 55      -   5        $��btnAdd��58      $��5q�55      $��Add New Book ISBN��56      $��5q�57      $��2��5:      6(   5;      �� 5=   
   -   5        $��
stackpanel��5=      $��1��5>      $��0,45.4,30,0q�6"   $��2��67   .+�5?      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgBookISBN��5?      $	��500��5@      $��5q�5A      $	��Top=�5B         	RowHeight$ 30Q�5C         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5D         AutoGenerateColumns .     
IsReadOnly . ��5G      �� *	LstItem+	   Columns	 5H      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn
   Header$

 ISBN��6)      Width$ 50 5K   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5J   #   �� *ISBN+5K   #     5L      $
 Title��6)   $	 100 5N   )    5M   #   �� *BookTitleDTO+5N   )     5O      $
 Author��6)    5P   #   �� *	AuthorDTO+  5Q      $
 Language��6)   $ 80 5S   )    5R   #   �� *
Language+5S   )     5T      $
 Quantity��6)   $ 80 5V   )    5U   #   �� *
Quantity+5V   )     5W      $
 Status ��6)    5X   #   �� *Status+ �� 	Converter# [  5[      5\      #   Minh_C5_Assignment.Pagination  5^   
   -   5          Name$ 
pagination��5^      $
��5 10q�5_      $��45��5`      $��3��5a      5b      5c      