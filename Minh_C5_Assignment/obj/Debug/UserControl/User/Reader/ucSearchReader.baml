   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      '    !Minh_C5_Assignment.ucSearchReader   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Minh_C5_Assignment     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5	      0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter&   Minh_C5_Assignment.ConverterType  converterType��%:   &	        &	        5
   
   6(     5   
   6   5      .��5      � -   5        $
��grid��5      .+�5   
   � 
������� � RowDefinitions 5      �� 5      $��45 �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� -   5        $��lbTrang��5      $��0��5      $��25(�5      $��View Reader��5      $
��Bold"�5      
����� �$��Center=�5      � 5      $��1��6    � ColumnDefinitions 5       �� 5!      $
��auto �6'   �� 5"      �� 5#      $
��auto �6'   .+�5&      � $��1��6    5'      �� 5(      $
��auto �6+   �� 5)      .+�5+      �� $��Search here...��6    $��5q�5,       �� Padding$ 5q�5-      $��Center=�5.      69   �� 5/      -   5        $��	txtSearch��52      $��5q�5/      $��1��6)   $��5q�50      $��Center=�51      53   @   54      �� 57      -   5        $��btnAdd��5:      $��5q�57      $��Add New Reader��58      $��5q�59      $��2��5<      6(   5=      �� 5?      -   5        $��
stackpanel��5@      $��2��5?      .+�5A      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dtgReader��5A      $	��500��5B      $��5q�5C      $	��Top=�5D         	RowHeight$ 30Q�5E         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70 5F         AutoGenerateColumns .     
IsReadOnly . ��5I      �� *	LstItem+	   Columns	 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn
   Header$	
 Id ��6-      Width$ 50 5M   #   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5L   #   �� *Id+5M   #     5N      $
 LName��6-   $	 105 5P   )    5O   #   �� *LName+5P   )     5Q      $
 FName��6-    5R   #   �� *FName+  5S      $	
 BOF��6-    5T   #   �� *boF+ �� StringFormat$ {0:dd/MM/yyyy}��  5U      $
 Reader Type��6-   $ 80 5W   )    5V   #   �� *
ReaderType+ �� 	Converter# [ 5W   )     5X      $
 
Created At��6-    5Y   #   �� *	CreatedAt+$ {0:dd/MM/yyyy}��  5Z      $
 Modifited At��6-   $ 80 5\   )    5[   #   �� *
ModifiedAt+$ {0:dd/MM/yyyy}��5\   )     5]      $
 Status ��6-    5^   #   �� *Status+# [  4  .System.Windows.Controls.DataGridTemplateColumn  5`      $
 Detail��61      
IsReadOnly . $ 50 5b   )      CellTemplate 5c      �� 5d   "   .R�5e   &   �� $��	btnDetail��5g   %   -   5        $��Detail��5e   -     BtnDetailStyle#��[ 5f   -   
����� �5i   %   5j   #   5l        5n      $
 	Activated��61    . $ 50 5p   )    5q      �� 5r   "   .R�5s   &   �� $��	btnUpdate��5t   %   -   5        $��	Activated��5s   -     BtnActivatedStyle#��[ 5u   -   5v   %   5w   #   5y      5|      5}      #	   Minh_C5_Assignment.Pagination	  5      -	   5         	 Name$ 
pagination��5      $
��5 10q�5�      $��45��5�      $��3��5�      5�      5�      5�      