   M S B A M L   `   `   `  ����  HelpParebrise$    HelpParebrise.Views.AddVehicle   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��0.3* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   $��20,0,0,0q�6<    � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5      " ��6   .�5      ��  �@��Orientation$ 
Horizontal=�64   �� 5       � ��$ 0,0,0,5q�6/   5      �� 5      " ��6   8   .�5      ��  � ��$	 145��6.   �� 5       � ��$ Center=�6:   5      5      .+�5      �� $��DONNEES VEHICULE��6     Heading2#��[ 60   $��0,0,0,15q�6R   �� 5      $ 
Horizontal=�6   .+�5       �� $��Marque��6   �� 5!      -   5        	 ��Name$	 Marque��5!      $	��150��6*   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��Modèle��6   �� 5&      -   5        $	 Modele��5&      $	��150��6*   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��Date de mise en service��6   (  "System.Windows.Controls.DatePicker  5+      -   5        
  Name$
 dateMES��5+      $	��150��6.   5,      �� 5.      $ 
Horizontal=�6   .+�5/      �� $��Immatriculation��6   �� 50      -   5        $	 Immatriculation��50      $	��150��63   51      �� 53      $ 
Horizontal=�6   .+�54      �� $��Numéro de série��6   �� 55      -   5        $	 numSerie��55      $	��150��6,   56      �� 58      $ 
Horizontal=�6   .+�59      �� $��Type de véhicule��6   �� 5:      -   5        $	 TypeVehicule��5:      $	��150��60   5;      �� 5=      $ 
Horizontal=�6   .+�5>      �� $��Kilométrage��6   �� 5?      -   5        $	 kilometrage��5?      $	��150��6/   5@      �� 5B      -   5         ��Name$	 Add��5B      $��Ajouter��6"   $
��Left=�64   $��0,20,0,0q�6O   6a   5C      5D      5E      