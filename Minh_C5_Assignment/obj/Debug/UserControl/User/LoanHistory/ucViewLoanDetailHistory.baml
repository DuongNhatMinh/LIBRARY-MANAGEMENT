   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      0    *Minh_C5_Assignment.ucViewLoanDetailHistory   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      
�������.��5	      � $��10q�6     � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��Loan History Infomation��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6     5      �� 5      �� 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      �� 5$       � ColumnDefinitions 5'      �� 5(      .+�5+      �� -   5        $��tbluser��5/      $��0��5+      $��0��5,      $��Center=�5-      $��
User Name:��5.      $��SemiBold"�50      $��14(�51      �� 53      -   5        $��	tblreader��57      $��1��53      $��0��54      $��Center=�55      $��Reader Name:��56      $��SemiBold"�58      $��14(�59      �� 5;      -   5        $��tblloanpaid��5>      $��3��5;      $��0��5<      $��Center=�5=      $��
Loan Paid:��5?      $��SemiBold"�5@      $��14(�5A      �� 5C      -   5        $��
tbldeposit��5F      $��2��5C      $��0��5D      $��Center=�5E      $��Deposit:��5G      $��SemiBold"�5H      $��14(�5I      �� 5K      -   5        $��tblfinemoney��5N      $��4��5K      $��0��5L      $��Center=�5M      $��
FineMoney:��5O      $��SemiBold"�5P      $��14(�5Q      �� 5S      -   5        $��tbltotal��5V      $��5��5S      $��0��5T      $��Center=�5U      $��	PayMoney:��5W      $��SemiBold"�5X      $��14(�5Y      �� 5[      -   5        $��tblloandate��5^      $��6��5[      $��0��5\      $��Center=�5]      $��
Loan Date:��5_      $��SemiBold"�5`      $��14(�5a      �� 5c      -	   5        $��
tblexpdate��5f      $��7��5c      $��0��5d      $��Center=�5e      $��	Exp Date:��5g      $��14(�5h      $��SemiBold"�5i      �� 5k      -
   5        $��tblquantity��5n      $��8��5k      $��0��5l      $��Center=�5m      $��	Quantity:��5o      $��14(�5p      $��SemiBold"�5q      5r      �� 5u   
   $��25(�6   $��2��5v      $%��Loan Detail History Information��5w      $
��Bold"�5x      
����� �$��Center=�5z      �� 5|   
   $��3��6   $��List Book Loan��6    .��5}      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgBook��5}      $	��200��5~      $��10q�5      $	��Top=�5�         	RowHeight$ 30Q�5�         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5�         AutoGenerateColumns .     
IsReadOnly .    Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6)   	   Width$		 100 5�   )   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5�   #   �� *	NameDTO+5�   )     5�      $ Author��6)   
 5�   #   �� *	AuthorDTO+  5�      $ 
Translator��6)   
 5�   #   �� *TranlatorDTO+  5�      $ Language��6)   $	 65 5�   )   
 5�   #   �� *LanguageDTO+5�   )     5�      $ 	Publisher��6)   $	 80 5�   )   
 5�   #   �� *	Publisher+5�   )   5�      5�      5�      5�      