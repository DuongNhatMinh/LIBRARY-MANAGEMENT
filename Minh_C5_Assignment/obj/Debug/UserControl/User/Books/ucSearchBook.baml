   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      %    Minh_C5_Assignment.ucSearchBook   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5	      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5
   
   6(   5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��	View Book��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5       �� 5!      $
��auto �6#   .+�5$      � $��1��6    5%      �� 5&      $
��auto �6'   �� 5'      .+�5)      �� $��Search here...��6   $��5q�5*       �� Padding$ 5q�5+      $��Center=�5,      69   �� 5-      -   5        $��	txtSearch��50      $��5q�5-      $��1��6%   $��5q�5.      $��Center=�5/      51   @   52      �� 55      -   5        $��btnAdd��58      $��5q�55      $��Add New Book��56      $��5q�57      $��2��5:      6(   5;      �� 5>   
   -   5        $��
stackpanel��5>      $��2��5?      .+�5@      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgBook��5@      $	��500��5A      $��5q�5B      $	��Top=�5C         	RowHeight$ 30Q�5D         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5E         AutoGenerateColumns .     
IsReadOnly . ��5H      �� *	LstItem+	   Columns	 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5L   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5K   #   �� *Id+5L   #     5M      $

 ISBN��6)   $ 50 5O   #    5N   #   �� *ISBN+5O   #     5P      $
 Title��6)   $	 100 5R   )    5Q   #   �� *	NameDTO+5R   )     5S      $
 
Translator��6)    5T   #   �� *	AuthorDTO+  5U      $
 Language��6)   $ 80 5W   )    5V   #   �� *LanguageDTO+5W   )     5X      $
 	Publisher��6)   $ 80 5Z   )    5Y   #   �� *	Publisher+5Z   )     5[      $
 Price��6)   $ 80 5]   )    5\   #   �� *Price+5]   )     5^      $
 PriceCurrent��6)   $ 80 5`   )    5_   #   �� *PriceCurrent+5`   )     5a      $
 PublishDate��6)   $ 80 5c   )    5b   #   �� *PublishDate+5c   )     5d      $
 
Created At��6)    5e   #   �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  5f      $
 Modifited At��6)   $ 80 5h   )    5g   #   �� *ModifitedAt+$ {0:dd/MM/yyyy}��5h   )     5i      $
 Status ��6)    5j   #   �� *Status+ �� 	Converter# [  5l      5m      #   Minh_C5_Assignment.Pagination  5o   
   -   5          Name$ 
pagination��5o      $
��5 10q�5p      $��45��5q      $��3��5r      5t      5u      