   M S B A M L   `   `   `  ����  HelpParebrise"    HelpParebrise.Views.AddStock   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6   .+�5   
   � -   5         �Name$ GridProgressRing��5      $y�Visible=�6*   
������� K� ZIndex$ 1��6R   $��Center=�6c   $��Center=�6�   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing     IsActive . $��80��66   ���	#FFE20013$��80��6X   ��6d   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      �� 5   
    �� Orientation$ Vertical=�6   $��20,0,0,0q�6,    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value �� BasedOn��%  '��       '�� �     7���� 5      " ��6   .�5      �� 	 �@��Orientation$
 
Horizontal=�64   �� 5      	 � ��$
 0,0,0,5q�6/   5      �� 5      " ��6   8   .�5      �� 	 � ��$	
 145��6.   �� 5      	 � ��$
 Center=�6:   5      5      .+�5      �� $��Ajouter une pièce��6     Heading2#��[ 61   $��0,0,0,15q�6S   �� 5      $ 
Horizontal=�6   .+�5       �� $��Liste des pièces ��6   �� 5!      -   5         ��Name$ ComboListPiece��5!      $	��200��63   ��5"      �� 5#      .R�5$      �� $��12(�6(   �� 5%   "   �6&   �� *	reference+ �� 5&   "   $�-��6&    �� 5'   "   �6&   �� *designation+5(      5)      5+      5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� $��Quantite��6   �� 50      -   5         ��Name$ Quantity��50      $	��200��6,   51      �� 53      -   5         ��Name$	 Add��53      $��Ajouter��6"   $
��Left=�64   $��0,20,0,0q�6O   6a   54      55      56      