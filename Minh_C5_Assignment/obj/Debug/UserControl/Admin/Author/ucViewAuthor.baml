   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      %    Minh_C5_Assignment.ucViewAuthor   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������  � 	Resources  5
      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $
��Bold"�6   $��View Author��5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      �� 5       $
��auto �6#   .+�5#      � $��1��6    5$      �� 5%      $
��auto �6'   �� 5&      .+�5(      �� $��Search here...��6   $��5q�5)       �� Padding$ 5q�5*      $��Center=�5+      69   �� 5,      -   5        $��	txtSearch��5/      $��5q�5,      $��1��6%   $��5q�5-      $��Center=�5.      50   @   51      �� 54      -   5        $��btnAdd��57      $��5q�54      $��Add New Author��55      $��5q�56      $��2��59      6(   5:      �� 5<   
   -   5        $��
stackpanel��5<      $��2��5=      .+�5>      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dtgAuthor��5>      $	��500��5?      $��5q�5@      $	��Top=�5A         	RowHeight$ 30Q�5B         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5C         AutoGenerateColumns .     
IsReadOnly . ��5F      �� *	LstItem+	   Columns	 5G      0  *System.Windows.Controls.DataGridTextColumn  5H      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��6)      Width$ 50 5J   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5I   #   �� *Id+5J   #     5K      $

 Name��6)    5L   #   �� *Name+  5M      $
 Description��6)   $ 80 5O   )    5N   #   �� *Description+5O   )     5P      $	
 BoF��6)   $ 80 5R   )    5Q   #   �� *boF+5R   )     5S      $
 
Created At��6)    5T   #   �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  5U      $
 Modifited At��6)   $ 80 5W   )    5V   #   �� *
ModifiedAt+$ {0:dd/MM/yyyy}��5W   )     5X      $
 Status ��6)    5Y   #   �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  5h      $

 Edit��6-      
IsReadOnly . $ 50 5j   )      CellTemplate 5k      �� 5l      .R�5m   "   �� $��btnEdit��5n   %   -   5        $
��Edit��5m   )     BtnEditStyle#��[ 5o   )   5p   )   5q      5s      5v      5w      #   Minh_C5_Assignment.Pagination  5y   
   -   5          Name$ 
pagination��5y      $
��5 10q�5z      $��32��5{      $��3��5|      5~      5      