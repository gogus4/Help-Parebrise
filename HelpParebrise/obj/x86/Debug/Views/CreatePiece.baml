   M S B A M L   `   `   `  ����  HelpParebrise%    HelpParebrise.Views.CreatePiece   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��0.3* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   $��20,0,0,0q�6<    � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5      " ��6   .�5      ��  �@��Orientation$ 
Horizontal=�64   �� 5       � ��$ 0,0,0,5q�6/   5      �� 5      " ��6   8   .�5      ��  � ��$	 145��6.   �� 5       � ��$ Center=�6:   5      5      .+�5      �� $��CREER UNE PIECE��6     Heading1#��[ 6/   $��0,0,0,15q�6Q   �� 5      $ 
Horizontal=�6   .+�5       �� $��Référence��6   �� 5!      -   5        	 ��Name$	 	Reference��5!      $	��150��6-   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��Désignation��6   �� 5&      -   5        $	 Designation��5&      $	��150��6/   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� $
��Prix��6   �� 5+      -   5        $
	 Prix��5+      $	��150��6(   5,      �� 5.      -   5        
 ��Name$	
 Add��5.      $��Ajouter��6"   $
��Left=�64   $��0,20,0,0q�6O   6a   5/      50      51      