   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      #    Minh_C5_Assignment.ucEditUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   .+�5      � $��0��6     5      �� 5      $
��auto �6$   64   �� 5      6&   .+�5      �� $��0��6   
���   �$��2q�5      $��5 5 5 0q�5      $��18(�5      $��SemiBold"�5      $��User Information��5      .��5      ��  �� Orientation$ Vertical=�6!   $��5q�5   !   .+�5      �� -   5        $��
lbUserName��5        $��User Name: ��5       $��14(�5!       $��SemiBold"�6.   �� 5#      -   5        $��txtUserName��5#   "    �� 	MaxLength$	 100��5$   "   .��5%   P   5&      �� 5(      -   5        $��
lbPassword��5)       $��
Password: ��5(       $��14(�5*       $��SemiBold"�6.   �� 5,      -   5        $��txtPassword��5,   "   $ 20��5-   !   5.   "   �� 50      -   5        $��lbLName��51       $��Last Name: ��50       $��14(�52       $��SemiBold"�6.   �� 54      -   5        $��txtLName��54   "   $	 100��55   "   .��56   P   57      �� 59      -   5        $��lbFName��5:       $��First Name: ��59       $��14(�5;       $��SemiBold"�6.   �� 5=      -   5        $��txtFName��5=   "   $ 20��5>   !   5?   "   �� 5A      $��	Address: ��6    $��14(�5B       $��SemiBold"�6.   �� 5D      -	   5        $��
txtAddress��5D   "   �� 5F      -
   5        $��lbPhone��5G       $��Phone: ��5F       $��14(�5H       $��SemiBold"�6.   �� 5J      -   5        $��txtPhone��5J   "   $ 10��5K   "   5L   "   5M      5N      5O      5P      �� 5R   
   $��Center=�6   $ 
Horizontal=�5S      $��1��5T      .+�5U      �� -   5        $��btnEdit��5V      $
��Edit��5U      $	��320��6$   $��10q�60      BtnEditStyle#��[  5W      5X      5Y      5Z      5[      