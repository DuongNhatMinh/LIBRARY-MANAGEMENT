   M S B A M L   `   `   `  ���� M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  '    !Minh_C5_Assignment.ucViewFunction   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     2local clr-namespace:Minh_C5_Assignment       � 	Resources  0   *Minh_C5_Assignment.StatusToStringConverter   statusToStringConverter��%   &	          .���  � RowDefinitions �� $��45 ��� $��45 ��� $	��280 � � ColumnDefinitions �� $	��720 �.+��� -   $��lbTrang��$��0��$��25(�$��View Function��$
��Bold"�
����� �$��Center=�� $��1��.+��� $��Selected Found Name:��$	��190��$��25��$��
-450,0,0,0q�$��Center=��� -   $��txtFind��$	��150��$��25��$��	-80,0,0,0q����� *Find+�� -   $��
stackpanel��$��2��.+�&   System.Windows.Controls.DataGrid  -     Name$ dtgFunction��$	��260��$��10q�$	��Top=�   	RowHeight$ 20Q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ 70    AutoGenerateColumns .     
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��
   Width$
 50 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $
	 Name��$	
 100  �� *Name+  $	 Description�� �� *Description+  $	 IdParent��$	
 100  �� *
IdParent+  $	 Status �� �� *Status+ �� 	Converter# [  4  .System.Windows.Controls.DataGridTemplateColumn  $	 	Activated��   
IsReadOnly . $
 60    CellTemplate �� .R��� $��	btnUpdate��-   $��	Activated��
����� �  $
	 Edit�� . $
 50  �� .R��� $��btnEdit��-   $
��Edit��
����� �