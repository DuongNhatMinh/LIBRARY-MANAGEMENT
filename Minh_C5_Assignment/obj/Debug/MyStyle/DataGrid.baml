   M S B A M L   `   `   `  ����M  IMinh_C5_Assignment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Minh_C5_AssignmentMinh_C5_Assignment  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089&    System.Windows.Controls.DataGrid  �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value)  #System.Windows.Controls.DataGridRow*  $System.Windows.Controls.DataGridCell=  7System.Windows.Controls.Primitives.DataGridColumnHeader   Sort.Up.Icon.MouseOver �� Color  Sort.Up.Icon.Active % !DataGrid.Header.Static.Background + 'DataGrid.Headers.Icon.Static.Background  DataGrid.Static.BorderBrush + 'DataGrid.Row.Details.Static.BorderBrush + 'DataGrid.Header.Title.Static.Foreground , (DataGrid.Column.Header.Static.Foreground ; 7DataGrid.Header.SearchBox.PlaceHolder.Static.Foreground 0	 ,DataGrid.Header.SearchBox.Static.BorderBrush &
 "DataGrid.Column.Header.Icon.Static  Sort.Down.Icon.MouseOver  Sort.Down.Icon.Active % !DataGrid.Column.Header.Background / +DataGrid.Footer.Separator.Background.Static % !DataGrid.Footer.Background.Static ? ;DataGrid.Footer.Pagination.GoToRow.Button.Background.Static @ <DataGrid.Footer.Pagination.GoToRow.Button.BorderBrush.Static 8 4DataGrid.Footer.Pagination.Button.BorderBrush.Static 9 5DataGrid.Footer.Pagination.Button.Foreground.Disabled 7 3DataGrid.Footer.Pagination.Button.Background.Static 8 4DataGrid.Footer.Pagination.Button.Background.Checked 9 5DataGrid.Footer.Pagination.Button.BorderBrush.Checked 7 3DataGrid.Footer.Pagination.Button.Foreground.Static 8 4DataGrid.Footer.Pagination.Button.Foreground.Checked 1 -DataGrid.Column.Icon.Filter.Static.Background A =DataGrid.Column.Icon.                      .Active.Background + 'DataGrid.Column.Icon.Filter.Active.Fill 1 -DataGrid.Column.Icon.Filter.Active.Background 2 .DataGrid.Column.Icon.Filter.Static.BorderBrush 2 .DataGrid.Column.Icon.Filter.Active.BorderBrush + 'DataGrid.AlternateRow.Static.Background %  !DataGrid.Grid.HorizontalLineBrush #! DataGrid.Cell.Static.Foreground %" !DataGrid.Cell.Selected.Foreground '# #DataGrid.Cell.Static.CompletedBrush $$  DataGrid.Cell.Static.FailedBrush (% $DataGrid.Cell.Static.InProgressBrush (& $DataGrid.Cell.Static.NotStartedBrush ' Icon.View.Static.Fill ( Icon.Edit.Static.Fill ) Icon.Trash.Static.Fill  * Icon.View.Static.BorderBrush  + Icon.Edit.Static.BorderBrush !, Icon.Trash.Static.BorderBrush - Icon.MouseOver.Background . ProgressBar.Background #/ ProgressBar.Fill.CompletedBrush  0 ProgressBar.Fill.FailedBrush $1  ProgressBar.Fill.InProgressBrush 2 ComboBox.Static.Background 3 ComboBox.Static.Border 4 ComboBox.Static.Foreground 5 ComboBox.Static.Glyph 6 ComboBox.MouseOver.Glyph !7 ComboBox.MouseOver.Background 8 ComboBox.MouseOver.Border 9 ComboBox.Pressed.Glyph : ComboBox.Disabled.Glyph  ; ComboBox.Disabled.Background < ComboBox.Disabled.Border "= ComboBoxItem.Static.Background %> !ComboBoxItem.MouseOver.Background ? Popup.Static.Background @ Popup.Static.Shadow.Color 'A #Popup.TextBox.MouseOver.BorderBrush +B 'Popup.TextBox.MouseCaptured.BorderBrush 0C ,Popup.TextBox.Parent.Panel.Static.Background D CheckBox.Glyph.Checked.Fill E CheckBox.Static.BorderBrush F CheckBox.Static.Background G CheckBox.Checked.Background  H CheckBox.Checked.BorderBrush (I $Button.Default.MouseOver.OpacityMask $J  Button.Default.Static.Background $K  Button.Primary.Static.Background #L Button.Cancel.Static.Background $M  Button.Default.Static.Foreground $N  Button.Primary.Static.Foreground #O Button.Cancel.Static.Foreground "P FilterButton.Static.Background %Q !Button.ClearAll.Static.Background�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      *local clr-namespace:Minh_C5_Assignment  5      %>  '         '  �    '  A    '  �    &	      &	 +    &	 P    &	 u    &	 �    &	 �    &	 �    &	 	    &	 .    &		 S    &	
 x    &	 �    &	 �    &	 �    &	     &	 1    &	 V    &	 {    &	 �    &	 �    &	 �    &	 	    &	 4	    &	 Y	    &	 ~	    &	 �	    &	 �	    &	 �	    &	 
    &	 ;
    &	 `
    &	 �
    &	  �
    &	! �
    &	" �
    &	#     &	$ >    &	% c    &	& �    &	' �    &	( �    &	) �    &	*     &	+ A    &	, f    &	- �    &	. �    &	/ �    &	0 �    &	1     &	2 D    &	3 i    &	4 �    &	5 �    &	6 �    &	7 �    &	8 "    &	9 G    &	: l    &	; �    &	< �    &	= �    &	>      &	? %    &	@ J    &	A m    &	B �    &	C �    &	D �    &	E     &	F &    &	G K    &	H p    &	I �    &	J �    &	K �    &	L     &	M )    &	N N    &	O s    &	P �    &	Q �    �� 5      "    6   .�5   
   ��  � �� �#EAEAEA6'   �� 5   
    �@  	RowHeight$ 30Q�6&   �� 5   
    � �� �#BDBDBD6(   �� 5   
    � ��$ 1q�6,   �� 5   
    �@  RowHeaderWidth$ 0Q�6+   �� 5   
    �@  GridLinesVisibility$
 None=�60   �� 5   
   % �@  HorizontalScrollBarVisibility$
 Auto=�6:   �� 5   
   # �@  VerticalScrollBarVisibility$
 Auto=�68   �� 5    
    � ��
 �   �6'   �� 5!   
    �@  SelectionMode$ Single=�6*   �� 5"   
    � ��$ Center=�65   �� 5#   
    � ��$
 Left=�67    5%   
   P� 5&       �@��
IsSelected . . �5'      ��  � ��
 ��ح�6/   5(      5*      �� 5,      "   6   .�5-   
   ��  � ��
 �����6'   �� 5.   
    � �� �#D3D3D36(   �� 5/   
    � ��$ 0,0,0,1q�6,   �� 50   
    � ��$ 30��6#   �� 51   
    � ��$ Normal"�6'   �� 52   
    � ��$ 12(�6%    53   
   P� 54       �@J�IsMouseOver . . �55      ��  � ��
 ��ح�6/   56      58      �� 5:      "   6   .�5;   
   ��  � ��$ 8q�6$   �� 5<   
    � ��
 �   �6'   5=      �� 5?      "   6   .�5@   
   ��  � �� �#EAEAEA6'   �� 5A   
    � �� �#BDBDBD6(   �� 5B   
    � ��$ 0,0,0,1q�6,   �� 5C   
    � ��$ 8q�6$   �� 5D   
    � ��$ 30��6#   �� 5E   
    � ��$
 Bold"�6'   �� 5F   
    � ��$ 12(�6%   �� 5G   
    � ��$
 Left=�67   5H      �� 5J      $ #FFFFFF��5K      �� 5M      $ #FFFFFF��5N      �� 5P      $ #F7F7F7��5Q      �� 5S      $ #828283��5T      �� 5V      $ #4683DE��5W      �� 5Y      $ #4683DE��5Z      �� 5\      $ #828283��5]      �� 5_      $ #FFFFFF��5`      �� 5b      $ #ECECEC��5c      �� 5e      $ #ECECEC��5f      �� 5h      $ #B4CDF3��5i      �� 5k      $ #FFFFFF��5l      �� 5n      $ #FFFFFF��5o      �� 5q      $ #4683DE��5r      �� 5t      $ #4683DE��5u      �� 5w      $ #F7F7F7��5x      �� 5z      $ #4683DE��5{      �� 5}      $ #4683DE��5~      �� 5�      $ #ECECEC��5�      �� 5�      $ #CECECE��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #4683DE��5�      �� 5�      $ #4683DE��5�      �� 5�      $ #000000��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ Transparent��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #828283��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #B4CDF3��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #FAFAFA��5�      �� 5�      $ #ECECEC��5�      �� 5�      $ #000000��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #18BD11��5�      �� 5�      $ #EA5C5C��5�      �� 5�      $ #D4A746��5�      �� 5�      $ #4683DE��5�      �� 5�      $ #929DE7��5�      �� 5�      $ #18BD11��5�      �� 5�      $ #EA5C5C��5�      �� 5�      $ #929DE7��5�      �� 5�      $ #18BD11��5�      �� 5�      $ #EA5C5C��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #D3D3D3��5�      �� 5�      $ #18BD11��5�      �� 5�      $ #EA5C5C��5�      �� 5�      $ #D4A746��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #ECECEC��5�      �� 5�      $ #000000��5�      �� 5�      $ #ECECEC��5�      �� 5�      $ #CECECE��5�      �� 5�      $ #FFFFFF��5�      �� 5�      $ #CECECE��5�      �� 5�      $ #CECECE��5�      �� 5�      $ #CECECE��5�      �� 5�      $ #FFFFFF��5�      �� 5     $ #CECECE��5     �� 5     $ #FFFFFF��5     �� 5     $ #ECECEC��5     �� 5
     $ #FFFFFF��5     ��5     #FFFFFF��5     �� 5     $ #CECECE��5     �� 5     $ #CECECE��5     �� 5     $ #F7F7F7��5     �� 5     $ #FFFFFF��5     �� 5     $ #CECECE��5     �� 5!     $ #FFFFFF��5"     �� 5$     $ #4683DE��5%     �� 5'     $ #4683DE��5(     �� 5*     $ #FFFFFF��5+     �� 5-     $ #FFFFFF��5.     �� 50     $ #4683DE��51     �� 53     $ #828283��54     �� 56     $ #FFFFFF��57     �� 59     $ #FFFFFF��5:     �� 5<     $ #FFFFFF��5=     �� 5?     $ #828283��5@     �� 5B     $ #D4AA4B��5C     5E     