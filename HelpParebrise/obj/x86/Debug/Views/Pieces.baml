   M S B A M L   `   `   `  ����  HelpParebrise     HelpParebrise.Views.Pieces   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��1.1* �6   �� 5      $
��0.5* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5   !   $��3��6   $y�Visible=�6;   $��3��6P   
������� K� ZIndex$ 1��6w   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��Center=�6&   ���	#FFE20013$��Center=�6Z      IsActive . $��80��6�   $��80��6�   ��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      � 5   
   $��0��6    � RowDefinitions 5      �� 5      $
��0.6* �6    �� 5      $
��0.4* �6    .+�5      � $��0��6   .+�5      �� $��	CONSULTER��6     Heading2#��[ 6-   $��0,0,0,15q�6O   &   System.Windows.Controls.DataGrid  5      -   5        $��piecesDataGrid��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 61   $��Visible=�6A   "	   VerticalScrollBarVisibility$	 Visible=�6t   $
   HorizontalScrollBarVisibility$
 Visible=�6�   $��0,40,0,0q�6�   $	��300��6�   $	��Top=�6�   $
��Left=�6�   $	��600��6     AutoGenerateColumns .     SelectionMode$ Single=�6<     
IsReadOnly .    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Référence��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	reference+  5       $ Désignation��61    6F   �� *designation+  5!      $
 Prix��61    6?   �� *prix+5#      5$      �� 5&      -   5         ��Name$ UpdateStackPanel��5&      $��1��63   $��0,20,0,0q�6@   $y�	Collapsed=�6R    �� Orientation$ Vertical=�6i    � 	Resources 5'       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5(      " ��6   .�5)      ��  �@��Orientation$ 
Horizontal=�68   �� 5*       � ��$ 0,0,0,5q�63   5+      �� 5-      " ��6   8   .�5.      ��  � ��$	 100��62   �� 5/       � ��$ Center=�6>   50      51      .+�53      �� $��MODIFICATION��6   #��[ 60   $��0,0,0,15q�6R   �� 55      $ 
Horizontal=�6   .+�56      �� $��Référence��6   �� 57      -   5         ��Name$ 	reference��57      $	��150��6L   ��61   �� *	reference+6L   �� 59      $��Désignation��6   $��20,0,0,0q�62   �� 5:      -   5        $ designation��5:      $	��150��6P   ��63   �� *designation+6P   5;      �� 5=      $ 
Horizontal=�6   .+�5>      �� $
��Prix��6   �� 5?      -   5        $ price��5?      $	��150��6C   ��6-   �� *prix+6C   5@      �� 5B      $ 
Horizontal=�6   .+�5C      �� -   5         ��Name$ Update��5C      $��Modifier��6-   $��0,5,0,0q�6@   6Q   �� 5D      -   5        $ Delete��5D      $��	Supprimer��6-   $��5,5,0,0q�6A   6R   5E      5F      5G      � 5I   
   $��1��6   .+�5J      �� $��AJOUTER UNE PIECE��6   #��[ 61   $��0,0,0,15q�6S   �� 5L      -	   5        $ AddStackPanel��5L      $��1��60   $��0,40,0,0q�6=   $y�Visible=�6O   $ Vertical=�6d    5M      ��%  '��       '�� �     7���� 5N      " ��6   .�5O      ��  �@��Orientation$ 
Horizontal=�68   �� 5P       � ��$ 0,0,0,5q�63   5Q      �� 5S      " ��6   8   .�5T      ��  � ��$	 150��62   �� 5U       � ��$ Center=�6>   5V      5W      .+�5Y      �� $ 
Horizontal=�6   .+�5Z      �� $��Référence��6   �� 5[      -
   5        $ RefAdd��5[      $	��150��6.   5\      �� 5^      $ 
Horizontal=�6   .+�5_      �� $��Désignation��6   �� 5`      -   5        $ DesignationAdd��5`      $	��150��66   5a      �� 5c      $ 
Horizontal=�6   .+�5d      �� $
��Prix��6   �� 5e      -   5        $ PriceAdd��5e      $	��150��60   5f      �� 5h      $ 
Horizontal=�6   .+�5i      �� �� 5j      -   5        $	 Add��5j      $��Ajouter��6*   $��0,5,0,0q�6<   6M   5k      5l      5m      5n      5o      