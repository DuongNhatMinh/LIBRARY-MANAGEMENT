   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      (    "Minh_C5_Assignment.ucViewPublisher   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5	      
�������.��5
      �   � RowDefinitions  5   
   �� 5      $��45 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Publisher��5      $
��Bold"�5      
����� �$��Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      �� 5      $
��auto �6#   .+�5       � $��1��6    5!      �� 5"      $
��auto �6'   �� 5#      .+�5%      �� $��Search here...��6   $��5q�5&       �� Padding$ 5q�5'      $��Center=�5(      69   �� 5)      -   5        $��	txtSearch��5,      $��5q�5)      $��1��6%   $��5q�5*      $��Center=�5+      5-   @   5.      �� 51      -   5        $��btnAdd��54      $��5q�51      $��Add New Publisher��52      $��5q�53      $��2��56      6(   57      �� 59   
   -   5        $��
stackpanel��59      $��2��5:      .+�5;      &   System.Windows.Controls.DataGrid  -   5          Name$ dtgpublisher��5;      $	��500��5<      $��5q�5=      $	��Top=�5>         	RowHeight$ 30Q�5?         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5@         AutoGenerateColumns .     
IsReadOnly . ��5C      �� *	LstItem+   Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width$
 50 5G   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5F   #   �� *Id+5G   #     5H      $
	 Name��6)   $	
 100 5J   )    5I   #   �� *Name+5J   )     5K      $	 Phone��6)    5L   #   �� *Phone+  5M      $	 Address��6)   $	
 100 5O   )    5N   #   �� *	Address+5O   )   4  .System.Windows.Controls.DataGridTemplateColumn  5^      $
	 Edit��6-      
IsReadOnly . $
 50 5`   )      CellTemplate 5a      �� 5b      .R�5c   "   �� $��btnEdit��5d   %   -   5        $
��Edit��5c   )      BtnEditStyle#��[  5e   )   5f   )   5g      5i      5k      5l      #   Minh_C5_Assignment.Pagination  5n   
   -   5          Name$ 
pagination��5n      $
��5 10q�5o      $��45��5p      $��3��5q      5s      5t      