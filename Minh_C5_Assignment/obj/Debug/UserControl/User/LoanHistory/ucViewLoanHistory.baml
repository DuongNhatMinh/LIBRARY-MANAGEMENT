   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      *    $Minh_C5_Assignment.ucViewLoanHistory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      
�������.��5
      � -   5        $
��grid��5
      .+�5   
   �   � RowDefinitions  5      �� 5      $��45 �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��Loan History Management��5      $
��Bold"�5      
����� �$��Center=�5      � 5      $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      �� 5      $
��auto �6'   .+�5"      � $��1��6    5#      �� 5$      $
��auto �6+   �� 5%      .+�5'      �� $��Search here...��6    $��5q�5(       �� Padding$ 5q�5)      $��Center=�5*      69   �� 5+      -   5        $��	txtSearch��5.      $��5q�5+      $��1��6)   $��5q�5,      $��Center=�5-      5/   @   50      �� 53      -   5        $��btnAdd��56      $��5q�53      $��Add New Loan History��54      $��5q�55      $��2��58      6(   59      �� 5;      $��2��6   $��Loan History��5<      .��5=      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgloan��5=      $��1��5>      $	��500��5?      $	��Top=�5@         	RowHeight$ 30Q�5A         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5B         AutoGenerateColumns .     
IsReadOnly . ��5E      �� *	LstItem+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6-   
   Width$
 50 5I   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5H   #   �� *Id+5I   #     5J      $
	 User��6-   $
 70 5L   #    5K   #   �� *User+5L   #     5M      $	 Reader��6-   $
 80 5O   #    5N   #   �� *Reader+5O   #     5P      $	 LoanDate��6-   $
 70 5R   )    5Q   #   �� *
LoanDate+ �� StringFormat$ {0:dd.MM.yyyy}��5R   )     5S      $	 ExpDate��6-   $
 70 5U   -    5T   #   �� *	ExpDate+$ {0:dd.MM.yyyy}��5U   -     5V      $	 Quantity��6-   $
 60 5X   #    5W   #   �� *
Quantity+5X   #   4  .System.Windows.Controls.DataGridTemplateColumn  5Y      $	 Detail��61      
IsReadOnly . $
 50 5[   )      CellTemplate 5\      �� 5]   "   .R�5^   &   �� $��	btnSelect��5`   )   -   5           BtnDetailStyle#��[  5^   -   $��Detail��5_   -   
����� �5b   )   5c   #   5e      5g      5h      #   Minh_C5_Assignment.Pagination  5j      -   5          Name$ 
pagination��5j      $
��5 10q�5k      $��45��5l      $��3��5m      5n      5o      5p      