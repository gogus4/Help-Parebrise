   M S B A M L   `   `   `  ����  HelpParebrise!    HelpParebrise.Views.Vehicle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��0.02* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��0.06* �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5   !   $��3��6   $y�Visible=�6;   $��3��6P   
������� K� ZIndex$ 1��6w   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing  $��Center=�6&   ���	#FFE20013$��Center=�6Z      IsActive . $��80��6�   $��80��6�   ��6�   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      �� 5   
   $��0��6   $��0��6%    �� Orientation$ 
Horizontal=�62   .+�5      �� -   5        	 ��Name$	 SearchVehicle��5      $	��182��6-   $��25��69   $��0��6E   6U   �� 5      $��50��6   $��25��6    $��1q�6,   $��-2,0,0,0q�6@   .��5      �� .+�5      �� $.��(/HelpParebrise;component/Assets/find.png��6   5       5!      5"      �� 5$   
   $��0��6   $��1��6%   $��Visible=�62   .+�5%      �� -   5        
 ��Name$
 listVehicles��5%      $	��500��6-   $	��500��6:    �� SelectedIndex$ 0��6J   $��Visible=�6�   ��5&      �� 5'      .R�5(      �� $ Vertical=�6%   .+�5)      �� $
��Bold"�6I   ��6(   �� *immatriculation+6I   5*      5+      5-      5.      �� 50   
   ���#cccccc$��2��6#   $��1��67   $��2��6A   $��1��6R   ���#cccccc6b   �� 52   
   -   5         ��Name$ DataStackPanel��52   3   $��0��6   $��2��6"   $��2��6K   $ Vertical=�6[   $��20,0,0,0q�6r    � 	Resources 53       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 54      " ��6   .�55      ��  �@��Orientation$ 
Horizontal=�64   �� 56       � ��$ 0,0,0,5q�6/   57      �� 59      " ��6   8   .�5:      ��  � ��$	 145��6.   �� 5;       � ��$ Center=�6:   5<      5=      .+�5?      �� $��DONNEES VEHICULE��6     Heading2#��[ 60   $��0,0,0,15q�6R   �� 5A      $ 
Horizontal=�6   .+�5B      �� $��Marque :��6   �� 5C      -   5        $	 Marque��5C      $	��150��6B   ��6*   �� *marque+6B   5D      �� 5F      $ 
Horizontal=�6   .+�5G      �� $��	Modèle :��6   �� 5H      -   5        $	 Modele��5H      $	��150��6B   ��6*   �� *modele+6B   5I      �� 5K      $ 
Horizontal=�6   .+�5L      �� $��Date de mise en service :��6   (  "System.Windows.Controls.DatePicker  5M      -   5          Name$ dateMES��5M      $	��150��6T      Text 6.   �� *date_mise_en_service+6T   5N      �� 5P      $ 
Horizontal=�6   .+�5Q      �� $��Immatriculation :��6   �� 5R      -   5        $	 Immatriculation��5R      $	��150��6T   ��63   �� *immatriculation+6T   5S      �� 5U      $ 
Horizontal=�6   .+�5V      �� $��Numéro de série :��6   �� 5W      -	   5        $	 numSerie��5W      $	��150��6J   ��6,   �� *numero_serie+6J   5X      �� 5Z      $ 
Horizontal=�6   .+�5[      �� $��Type de véhicule :��6   �� 5\      -
   5        $	 TypeVehicule��5\      $	��150��6O   ��60   �� *type_vehicule+6O   5]      �� 5_      $ 
Horizontal=�6   .+�5`      �� $��Kilométrage :��6   �� 5a      -   5        $	 kilometrage��5a      $	��150��6L   ��6/   �� *kilometrage+6L   5b      �� 5d      $ 
Horizontal=�6   .+�5e      �� $��Numéro de parc :��6   �� 5f      -   5        $	 NumParc��5f      $	��150��6H   ��6+   �� *numero_parc+6H   5g      �� 5i      -   5         ��Name$ Update��5i      $��Modifier��6%   $
��Left=�68   $��0,20,0,0q�6S   6e   5j      5k      5l      