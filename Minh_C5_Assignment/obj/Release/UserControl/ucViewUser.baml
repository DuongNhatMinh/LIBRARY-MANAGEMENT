   M S B A M L   `   `   `  ���� M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  #    Minh_C5_Assignment.ucViewUser   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Minh_C5_Assignment       � 	Resources  0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          .���  � RowDefinitions �� $��45 ��� $	��280 � � ColumnDefinitions �� $	��720 �.+��� -   $��lbTrang��$��0��$��25(�$��	View User��$
��Bold"�
����� �$��Center=��� -   $��
stackpanel��$��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ dtgUser��$	��260��$��10q�$	��Top=�   	RowHeight$ 20Q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70    AutoGenerateColumns .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��
   Width$
 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $	 UserName�� �� *
Username+  $	 Password��$
 80  �� *
Password+  $	 
Created At�� �� *	CreatedAt+ �� StringFormat$ {0:dd/MM/yyyy}��  $	 Modifited At��$
 80  �� *
ModifiedAt+$ {0:dd/MM/yyyy}��  $	 Status �� �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  $	 Detail��   
IsReadOnly . $
 50    CellTemplate �� .R��� $��	btnDetail��-   $��Detail��
����� �  $	 	Activated�� . $
 50  �� .R��� $��	btnUpdate��-   $��	Activated��
����� �  $
	 Edit�� . $
 50  �� .R��� $��btnEdit��-   $
��Edit��
����� �