   M S B A M L   `   `   `  ����  HelpParebrise"    HelpParebrise.Views.Contacts   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��1.1* �6   �� 5      $
��0.5* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5   !   $��3��6   $y�Visible=�6;   $��3��6P   
������� K� ZIndex$ 1��6w   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��Center=�6&   ���	#FFE20013$��Center=�6Z      IsActive . $��80��6�   $��80��6�   ��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      � 5   
   $��0��6    � RowDefinitions 5      �� 5      $
��0.6* �6    �� 5      $
��0.4* �6    .+�5      � $��0��6   .+�5      �� $��	CONSULTER��6     Heading2#��[ 6-   $��0,0,0,15q�6O   &   System.Windows.Controls.DataGrid  5      -   5        $��suppliersDataGrid��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 64   $��Visible=�6D   "	   VerticalScrollBarVisibility$	 Visible=�6w   $��0,40,0,0q�6�   $	��300��6�   $	��Top=�6�   $
��Left=�6�   $	��680��6�   
   AutoGenerateColumns
 .     SelectionMode$ Single=�6     
IsReadOnly .    Columns 5      =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *nom+  5       $ Prenom��61    6A   �� *prenom+  5!      $ Fonction��61    6C   �� *
fonction+  5"      $ 	Num tel 1��61    6D   �� *numero_telephone1+  5#      $ Email��61    6@   �� *adresse_email+5%      5&      �� 5(      -   5         ��Name$ UpdateStackPanel��5(      $��1��63   $��0,20,0,0q�6@   $y�	Collapsed=�6R    �� Orientation$ Vertical=�6i    � 	Resources 5)       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5*      " ��6   .�5+      ��  �@��Orientation$ 
Horizontal=�68   �� 5,       � ��$ 0,0,0,5q�63   5-      �� 5/      " ��6   8   .�50      ��  � ��$	 100��62   �� 51       � ��$ Center=�6>   52      53      .+�55      �� $��MODIFICATION��6   #��[ 60   $��0,0,0,15q�6R   �� 57      $ 
Horizontal=�6   .+�58      �� $	��Nom��6   �� 59      -   5         ��Name$
 Name��59      $	��150��6A   ��6,   �� *nom+6A   �� 5;      $��Prenom��6   $��20,0,0,0q�6-   �� 5<      -   5        $ 	FirstName��5<      $	��150��6I   ��61   �� *prenom+6I   5=      �� 5?      $ 
Horizontal=�6   .+�5@      �� $��Numéro de tel 1��6   �� 5A      -   5        $ NumTel1��5A      $	��150��6R   ��6/   �� *numero_telephone1+6R   �� 5C      $��Numéro de tel 2��6   $��20,0,0,0q�66   �� 5D      -   5        $ NumTel2��5D      $	��150��6R   ��6/   �� *numero_telephone2+6R   5E      �� 5G      $ 
Horizontal=�6   .+�5H      �� $��Adresse email��6   �� 5I      -   5        $ 	AddrEmail��5I      $	��150��6P   ��61   �� *adresse_email+6P   �� 5K      $��
Numero fax��6   $��20,0,0,0q�61   �� 5L      -	   5        $ NumFax��5L      $	��150��6J   ��6.   �� *
numero_fax+6J   5M      �� 5O      $ 
Horizontal=�6   .+�5P      �� $��Fonction��6   �� 5Q      -
   5        $ Function��5Q      $	��150��6J   ��60   �� *
fonction+6J   5R      �� 5T      $ 
Horizontal=�6   .+�5U      �� -   5         ��Name$ Update��5U      $��Modifier��6-   $��0,5,0,0q�6@   6Q   �� 5V      -   5        $ Delete��5V      $��	Supprimer��6-   $��5,5,0,0q�6A   6R   5W      5X      5Y      � 5[   
   $��1��6   .+�5\      �� $��AJOUTER UN CONTACT��6   #��[ 62   $��0,0,0,15q�6T   �� 5^      -   5        $ AddStackPanel��5^      $��1��60   $��0,40,0,0q�6=   $y�Visible=�6O   $ Vertical=�6d    5_      ��%  '��       '�� �     7���� 5`      " ��6   .�5a      ��  �@��Orientation$ 
Horizontal=�68   �� 5b       � ��$ 0,0,0,5q�63   5c      �� 5e      " ��6   8   .�5f      ��  � ��$	 150��62   �� 5g       � ��$ Center=�6>   5h      5i      .+�5k      �� $ 
Horizontal=�6   .+�5l      �� $��Fonction��6   �� 5m      -   5        $ FunctionAdd��5m      $	��150��63   5n      �� 5p      $ 
Horizontal=�6   .+�5q      �� $	��Nom��6   �� 5r      -   5        $ NameAdd��5r      $	��150��6/   5s      �� 5u      $ 
Horizontal=�6   .+�5v      �� $��Prénom��6   �� 5w      -   5        $ FirstNameAdd��5w      $	��150��64   5x      �� 5z      $ 
Horizontal=�6   .+�5{      �� $��Adresse��6   �� 5|      -   5        $ AddrAdd��5|      $	��150��6/   5}      �� 5      $ 
Horizontal=�6   .+�5�      �� $��Numéro de téléphone 1��6   �� 5�      -   5        $ 
NumTelAdd1��5�      $	��150��62   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Numéro de téléphone 2��6   �� 5�      -   5        $ 
NumTelAdd2��5�      $	��150��62   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Adresse email��6   �� 5�      -   5        $ AddrEmailAdd��5�      $	��150��64   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Numéro de fax��6   �� 5�      -   5        $ 	NumFaxAdd��5�      $	��150��61   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� �� 5�      -   5        $	 Add��5�      $��Ajouter��6*   $��0,5,0,0q�6<   6M   5�      5�      5�      5�      5�      