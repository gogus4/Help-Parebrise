   M S B A M L   `   `   `  ����  HelpParebrise#    HelpParebrise.Views.Suppliers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��0.7* �6   �� 5      $
��0.5* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5   !   $��3��6   $y�Visible=�6;   $��3��6P   
������� K� ZIndex$ 1��6w   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��Center=�6&   ���	#FFE20013$��Center=�6Z      IsActive . $��80��6�   $��80��6�   ��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      � 5   
   $��0��6    � RowDefinitions 5      �� 5      $
��0.6* �6    �� 5      $
��0.4* �6    .+�5      � $��0��6   .+�5      �� $��	CONSULTER��6     Heading2#��[ 6-   $��0,0,0,15q�6O   &   System.Windows.Controls.DataGrid  5      -   5        $��suppliersDataGrid��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 64   $��0,40,0,0q�6D   $	��300��6V   $	��Top=�6c   $
��Left=�6{   $	��500��6�   "	   VerticalScrollBarVisibility$	 Visible=�6�   
   AutoGenerateColumns
 .     SelectionMode$ Single=�6�      
IsReadOnly .    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *nom+  5       $ Adresse��61    6B   �� *	adresse+  5!      $ Numéro de téléphone��61    6N   �� *numero_telephone+  5"      $ En cours��61    6C   �� *
en_cours+5$      5%      �� 5'      -   5         ��Name$ UpdateStackPanel��5'      $��1��63   $��0,20,0,0q�6@   $y�	Collapsed=�6R    �� Orientation$ Vertical=�6i    � 	Resources 5(       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5)      " ��6   .�5*      ��  �@��Orientation$ 
Horizontal=�68   �� 5+       � ��$ 0,0,0,5q�63   5,      �� 5.      " ��6   8   .�5/      ��  � ��$ 90��62   �� 50       � ��$ Center=�6>   51      52      .+�54      �� $��Modification��6   #��[ 60   $��0,0,0,15q�6R   �� 56      $ 
Horizontal=�6   .+�57      �� $	��Nom��6   �� 58      -   5         ��Name$
 Name��58      $	��150��6A   ��6,   �� *nom+6A   �� 5:      $��Adresse��6   $��20,0,0,0q�6.   �� 5;      -   5        $ Address��5;      $	��150��6H   ��6/   �� *	adresse+6H   5<      �� 5>      $ 
Horizontal=�6   .+�5?      �� $��Numéro de tel��6   �� 5@      -   5        $ NumTel��5@      $	��150��6P   ��6.   �� *numero_telephone+6P   �� 5B      $��Adresse email��6   $��20,0,0,0q�64   �� 5C      -   5        $ 	AddrEmail��5C      $	��150��6P   ��61   �� *adresse_email+6P   5D      �� 5F      $ 
Horizontal=�6   .+�5G      �� $��
Numero fax��6   �� 5H      -   5        $ NumFax��5H      $	��150��6J   ��6.   �� *
numero_fax+6J   �� 5J      $��En cours��6   $��20,0,0,0q�6/   �� 5K      -	   5        $ EnCours��5K      $	��150��6I   ��6/   �� *
en_cours+6I   5L      �� 5M      $ 
Horizontal=�6   .+�5N      �� -
   5         ��Name$ Update��5N      $��Modifier��6-   $��0,5,0,0q�6@   6Q   �� 5O      -   5        $ Delete��5O      $��	Supprimer��6-   $��5,5,0,0q�6A   6R   5P      5Q      5R      � 5T   
   $��1��6   .+�5U      �� $��AJOUTER UN FOURNISSEUR��6   #��[ 66   $��0,0,0,15q�6X   �� 5W      -   5        $ AddStackPanel��5W      $��1��60   $��0,40,0,0q�6=   $y�Visible=�6O   $ Vertical=�6d    5X      ��%  '��       '�� �     7���� 5Y      " ��6   .�5Z      ��  �@��Orientation$ 
Horizontal=�68   �� 5[       � ��$ 0,0,0,5q�63   5\      �� 5^      " ��6   8   .�5_      ��  � ��$	 150��62   �� 5`       � ��$ Center=�6>   5a      5b      .+�5d      �� $ 
Horizontal=�6   .+�5e      �� $	��Nom��6   �� 5f      -   5        $ NameAdd��5f      $	��150��6/   5g      �� 5i      $ 
Horizontal=�6   .+�5j      �� $��Adresse��6   �� 5k      -   5        $ AddrAdd��5k      $	��150��6/   5l      �� 5n      $ 
Horizontal=�6   .+�5o      �� $��Numéro de téléphone��6   �� 5p      -   5        $ 	NumTelAdd��5p      $	��150��61   5q      �� 5s      $ 
Horizontal=�6   .+�5t      �� $��Adresse email��6   �� 5u      -   5        $ AddrEmailAdd��5u      $	��150��64   5v      �� 5x      $ 
Horizontal=�6   .+�5y      �� $��Numéro de fax��6   �� 5z      -   5        $ 	NumFaxAdd��5z      $	��150��61   5{      �� 5}      $ 
Horizontal=�6   .+�5~      �� $��En cours��6   �� 5      -   5        $ 
EnCoursAdd��5      $	��150��62   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� �� 5�      -   5        $	 Add��5�      $��Ajouter��6*   $��0,5,0,0q�6<   6M   5�      5�      5�      5�      5�      