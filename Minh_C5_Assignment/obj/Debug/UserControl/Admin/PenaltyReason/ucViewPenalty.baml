   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      &     Minh_C5_Assignment.ucViewPenalty   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      
�������.��5      �   � RowDefinitions  5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Penalty��5      $
��Bold"�5      
����� �$��Center=�5      �� 5   
   $��1��6   .+�5      � $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      �� 5      $
��auto �6'   .+�5"      � $��1��6    5#      �� 5$      $
��auto �6+   �� 5%      .+�5'      �� $��Search here...��6    $��5q�5(       �� Padding$ 5q�5)      $��Center=�5*      69   �� 5+      -   5        $��	txtSearch��5.      $��5q�5+      $��1��6)   $��5q�5,      $��Center=�5-      5/   @   50      �� 53      -   5        $��btnAdd��56      $��5q�53      $��Add New Penalty��54      $��5q�55      $��2��58      6(   59      5;      �� 5=   
   -   5        $��
stackpanel��5=      $��2��5>      .+�5@      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dtgpenalty��5@      $	��500��5A      $��5q�5B      $	��Top=�5C         	RowHeight$ 30Q�5D         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5E         AutoGenerateColumns .     
IsReadOnly . ��5H      �� *	LstItem+   Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width$
 50 5L   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5K   #   �� *Id+5L   #     5M      $
	 Name��6)   $	
 100 5O   )    5N   #   �� *Name+5O   )     5P      $	 Description��6)    5Q   #   �� *Description+  5R      $	 Price��6)   $	
 100 5T   )    5S   #   �� *Price+5T   )   4  .System.Windows.Controls.DataGridTemplateColumn  5V      $	 Delete��6-      
IsReadOnly . $
 50 5X   )      CellTemplate 5Y      �� 5Z      .R�5[   "   �� $��	btnDelete��5\   %   -   5        $��Delete��5[   )      BtnActivatedStyle#��[  5]   )   
���  ��5_   )   5`      5b        5d      $
	 Edit��6-    . $
 50 5f   )    5g      �� 5h      .R�5i   "   �� $��btnEdit��5j   %   -   5        $
��Edit��5i   )     BtnEditStyle#��[ 5k   )   5l   )   5m      5o      5q      5r      #   Minh_C5_Assignment.Pagination  5t   
   -   5          Name$ 
pagination��5t      $
��5 10q�5u      $��45��5v      $��3��5w      5y      5z      