   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      )    #Minh_C5_Assignment.ucViewLoanDetail   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      
�������.��5	      � $��10q�6     � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��25(�6   $��Loan Slip Information��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6     5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5"      �� 5#      .+�5&      �� -   5        $��tbluser��5*      $��0��5&      $��Center=�5'      $��0��5(      $��
User Name:��5)      $��SemiBold"�5+      $��14(�5,      �� 5.      -   5        $��	tblreader��52      $��1��5.      $��Center=�5/      $��0��50      $��Reader Name:��51      $��SemiBold"�53      $��14(�54      �� 56      -   5        $��tblloanpaid��59      $��3��56      $��0��57      $��Center=�58      $��
Loan Paid:��5:      $��SemiBold"�5;      $��14(�5<      �� 5>      -   5        $��
tbldeposit��5A      $��2��5>      $��0��5?      $��Center=�5@      $��Deposit:��5B      $��SemiBold"�5C      $��14(�5D      �� 5F      -   5        $��tblloandate��5I      $��4��5F      $��0��5G      $��Center=�5H      $��
Loan Date:��5J      $��SemiBold"�5K      $��14(�5L      �� 5N      -   5        $��
tblexpdate��5Q      $��5��5N      $��0��5O      $��Center=�5P      $��	Exp Date:��5R      $��14(�5S      $��SemiBold"�5T      �� 5V      -   5        $��tblquantity��5Y      $��6��5V      $��0��5W      $��Center=�5X      $��	Quantity:��5Z      $��14(�5[      $��SemiBold"�5\      5]      �� 5a   
   $��25(�6   $��Loan Detail Information��5b      $
��Bold"�5c      $��2��5d      
����� �$��Center=�5f      �� 5h   
   $��3��6   $��List Book Loan��6    .��5i      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgBook��5i      $	��200��5j      $��10q�5k      $	��Top=�5l         	RowHeight$ 30Q�5m         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5n         AutoGenerateColumns .     
IsReadOnly .    Columns 5q      0  *System.Windows.Controls.DataGridTextColumn  5r      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6)   	   Width$		 100 5t   )   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5s   #   �� *	NameDTO+5t   )     5u      $ Author��6)   
 5v   #   �� *	AuthorDTO+  5w      $ 
Translator��6)   
 5x   #   �� *TranlatorDTO+  5y      $ Language��6)   $	 65 5{   )   
 5z   #   �� *LanguageDTO+5{   )     5|      $ 	Publisher��6)   $	 80 5~   )   
 5}   #   �� *	Publisher+5~   )   5�      5�      5�      5�      