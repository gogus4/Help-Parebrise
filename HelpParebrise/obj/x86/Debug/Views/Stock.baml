   M S B A M L   `   `   `  ����  HelpParebrise    HelpParebrise.Views.Stock   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � RowDefinitions 5   
   �� 5      $
��0.9* �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5   !   $��2��6   $y�Visible=�6;   
������� K� ZIndex$ 1��6c   $��
0,33,0,-33q�6t   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��Center=�6&   ���	#FFE20013$��Center=�6Z      IsActive . $��80��6�   $��80��6�   ��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      �� 5   
    �� Orientation$ Vertical=�6   $��0��6,   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��STOCK��6     Heading1#��[ 6)   $��0,0,0,15q�6K   5      &   System.Windows.Controls.DataGrid  5      -   5        $��stockDataGrid��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6,   $	��200��6<   $��0��6I   "	   VerticalScrollBarVisibility$	 Visible=�6V   
   AutoGenerateColumns
 .     SelectionMode$ Single=�6�      
IsReadOnly .    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Référence��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *	reference+  5      $ Désignation��6-    6B   �� *designation+  5       $
 Prix��6-    6;   �� *prix+  5!      $ Quantite��6-    6?   �� *
quantite+5#      5$      �� 5&   
   -   5         ��Name$ UpdateStackPanel��5&      $��1��6/   $y�	Collapsed=�6<   $ Vertical=�6S    � 	Resources 5'       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5(      " ��6   .�5)      ��  �@��Orientation$ 
Horizontal=�64   �� 5*       � ��$ 0,0,0,5q�6/   5+      �� 5-      " ��6   8   .�5.      ��  � ��$	 145��6.   �� 5/       � ��$ Center=�6:   50      51      .+�53      �� $��Modification��6     Heading2#��[ 6,   $��0,0,0,15q�6N   �� 55      $ 
Horizontal=�6   .+�56      �� $��	Reference��6   �� 57      -   5         ��Name$ 	Reference��57      {�.  $	��150��6Z    �� 
IsReadOnly . ��6-   �� *	reference+6f   58      �� 5:      $ 
Horizontal=�6   .+�5;      �� $��Designation��6   �� 5<      -   5        $ Designation��5<      {�.  $	��150��6^    . ��6/   �� *designation+6j   5=      �� 5?      $ 
Horizontal=�6   .+�5@      �� $��Quantite��6   �� 5A      -   5        $ Quantity��5A      $	��150��6F   ��6,   �� *
quantite+6F   5B      �� 5C      $ 
Horizontal=�6   .+�5D      �� �� 5E      -   5         ��Name$ Update��5E      $��Modifier la quantité��6)   $��0,5,0,0q�6H   6Y   5F      5G      5H      5I      