   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      "    Minh_C5_Assignment.ucAddBook   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      
�������.��5	      �   � RowDefinitions  5
   
   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   .+�5      � $��0��6     5      �� 5      $
��auto �6$   64   �� 5      6&   .+�5      �� $��0��6   
���   �$��2 2 2 2q�5      $��5 5 5 0q�5      $��Book Information��5      $��18(�5      $��SemiBold"�5       .��5!      ��  �� Orientation$ Vertical=�6!   $��5q�5"   !   .+�5#      �� $��
BookISBN: ��6    $��14(�5$       $��SemiBold"�6.   �� 5%      -   5        $��
cbBookISBN��5%   #   �� 5'      $��Publisher: ��6    $��14(�5(       $��SemiBold"�6.   �� 5)      -   5        $��cbPublisher��5)   #   �� 5+      $ 
Horizontal=�6%   .+�5,      �� $��Publish Date: ��6$   $��14(�5-       $��SemiBold"�6.   �� 5/      -   5        $
��lbPD��5/   $   $��14(�50       $��SemiBold"�6.   52      (  "System.Windows.Controls.DatePicker  53      -   5        $
��dpPD��53   %   $��14(�55   %   �� 57      $��Tranlator: ��6    $��14(�58       $��SemiBold"�6.   �� 59      -   5        $��cbTranlator��59   #   �� 5;      $��
Language: ��6    $��14(�5<       $��SemiBold"�6.   �� 5=      -   5        $��
cbLanguage��5=   #   �� 5?      $ 
Horizontal=�6%   .+�5@      �� $��Price of Book: ��6$   $��14(�5A       $��SemiBold"�6.   5C      �� 5D      -   5        $��txtPrice��5D   "   5E   Q   �� 5G      $ 
Horizontal=�6%   .+�5H      �� $��Quantity of Book: ��6$   $��14(�5I       $��SemiBold"�6.   5K      �� 5L      -   5        $��txtQuantity��5L   "   5M   T   5N      5O      5P      5Q      �� 5S   
   $��Center=�6   $ 
Horizontal=�5T      $��1��5U      .+�5V      �� -	   5        $��btnAdd��5W      $	��Add��5V      $	��350��6#   $��10q�6/   5X      5Y      5Z      5[      