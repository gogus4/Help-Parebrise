   M S B A M L   `   `   `  ����  HelpParebrise4    .HelpParebrise.Views.UpdateInterventionCustomer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5   	     � Title$  Modifier une intervention��5   	   $
��Auto��6+    � SizeToContent$ Height=�69   .��5      � -   5         �Name$ DataInterventionGrid��5       � ColumnDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��0.02* �6   �� 5      $��* �6   .+�5   
   � -   5        $ PicturesIntervention��5      $��0��6   $y�	Collapsed=�6:   $��0��6Q   $��3��6a   $��	5,-30,0,0q�6u   .+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $!��Photos de l'interventions :��6   $��12(�6?   �� 5      -   5         ��Name$  listviewImagesIntervention��5      $
��1000��6?   $
��Left=�6L   $��Stretch=�6g   $��0q�6�   $��Disabled=�6�    �� SelectionMode$ Single=�6�    �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5      	   Panel	 5      �� 5   "   .R�5   &   �� $ 
Horizontal=�61   5   #   
   ContainerStyle
 5       �� 5!   "    �� 
TargetType" ��6(   .�5"   &   ��  �� Property � �� �� Value 5#   *   �� 5$   .    �� 
TargetType" ��6>   .R�5%   2   �� $ 
Horizontal=�6=   .+�5&   6   �� $��0,0,0,0q�6G   $��Center=�6X   �� 5'   6   $��0,0,0,0q�6E   $��Center=�6V   5(   3   5)   /   5+   '   5,   #   5.      ��50      �� 51      .R�52      �� $ 
Horizontal=�6)   $��Stretch=�6B   $��Stretch=�6`   $��Disabled=�6|   53      ��55      �� 56      .R�57      �� $ 
Horizontal=�6)   $
��Left=�6B   $	��100��6]   $	��100��6i   $��Center=�6v   .+�58   "   �� $	��100��6@   $	��100��6L   $
��Fill=�6Y   ��6(   �� *lien+6Y   59      5:      5<      5=      5>      � 5A   
   -   5        $ GridProgressRing��5A      $��3��6)   $y�	Collapsed=�6=   
������� K� ZIndex$ 1��6g   $��Center=�6x   $��Center=�6�   .+�5B      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing     IsActive . $��80��66   ���	#FFE20013$��80��6X   ��6d   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5C      �� 5E   
   $��0��6   $��2��6%   $ Vertical=�62   $��20,0,0,0q�6I    � 	Resources 5F       �� BasedOn��%  '��       '�� �     7���� 5G      " ��6   .�5H      ��  �@��Orientation$ 
Horizontal=�64   �� 5I       � ��$ 0,0,0,5q�6/   5J      �� 5L      " ��6   8   .�5M      ��  � ��$	 145��6.   �� 5N       � ��$ Center=�6:   5O      5P      .+�5R      �� $��DONNEES INTERVENTION��6      Heading2#��[  64   $��0,0,0,15q�6V   �� 5T      $ 
Horizontal=�6   .+�5U      �� $��Numero��6   �� 5V      -   5         ��Name$ NumIntervention��5V       �� 
IsReadOnly . $	��150��6j   ��63   �� *indice_intervention+6j   5W      �� 5Y      $ 
Horizontal=�6   .+�5Z      �� $��Bon de commande��6   �� 5[      -   5        $ NumBonCommande��5[      $	��150��6S   ��62   �� *bon_de_commande+6S   5\      �� 5_      $ 
Horizontal=�6   .+�5`      �� $��Date de l'intervention��6   (  "System.Windows.Controls.DatePicker  5a      -   5          Name$ DateIntervention��5a      $	��150��67      Text 6C   �� *date_intervention+5b      �� 5d      $ 
Horizontal=�6   .+�5e      �� $��Date facture��6     5f      -   5        $ DateFacture��5f      $	��150��62    6>   �� *date_facture+5g      �� 5i      $ 
Horizontal=�6   .+�5j      �� $��Adresse de l'intervention��6   �� 5k      -	   5        $ AdresseIntervention��5k      $	��150��67   ��6C   �� *adresse_intervention+5l      �� 5n      $ 
Horizontal=�6   .+�5o      �� $��Numéro de la facture��6   �� 5p      -
   5        $ 
NumFacture��5p      $	��150��6.   ��6:   �� *numero_facture+5q      �� 5s      $ 
Horizontal=�6   .+�5t      �� $��Prix HT��6   �� 5u      -   5        $ PriceHT��5u      $	��150��6+   ��67   �� *	prix_HT+5v      �� 5x      $ 
Horizontal=�6   .+�5y      �� $��Prix TTC��6   �� 5z      -   5        $ PriceTTC��5z      $	��150��6,   ��68   �� *
prix_TTC+5{      �� 5}      $ 
Horizontal=�6   .+�5~      �� $	��TVA��6   �� 5      -   5         ��Name$ ComboListTauxTva��5      $	��150��65   ��5�      �� 5�      .R�5�      �� $��12(�6(   �� 5�   "   �6&   �� *
valeur_tva+5�      5�      5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Acompte��6   �� 5�      -   5        $ acompte��5�      $	��150��6+   ��67   �� *	acompte+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Remise��6   �� 5�      -   5        $ remise��5�      $	��150��6*   ��66   �� *remise+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��	Franchise��6   �� 5�      -   5        $ 	franchise��5�      $	��150��6-   ��69   �� *	franchise+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��
Prestation��6   �� 5�      -   5        $ ComboListTypePrestation��5�      $	��150��6<   ��5�      �� 5�      .R�5�      �� $��12(�6(   �� 5�   "   �6&   �� *designation+5�      5�      5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Mode de paiement��6   �� 5�      -   5        $ ComboListModesPaiement��5�      $	��150��6;   ��5�      �� 5�      .R�5�      �� $��12(�6(   �� 5�   "   �6&   �� *designation+5�      5�      5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Date du sinistre��6     5�      -   5        $ DateSinistre��5�      $	��150��63    6?   �� *date_sinistre+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Cause du sinistre��6   �� 5�      -   5        $ CauseSinistre��5�      $	��150��61   ��6=   �� *cause_sinistre+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Date échéance��6     5�      -   5        $ date_echeance��5�      $	��150��64    6@   �� *date_echeance+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Imprimer l'assurance :��6   �� 5�      -   5         ��Name$ AssuranceImpression��5�      $	��150��68   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� -   5         ��Name$ Update��5�      $��Modifier��6)   $
��Left=�6<   $��0,3,0,0q�6W   6h   �� 5�      -   5        $ 
AddPicture��5�      $��Ajouter une photo��6-   $
��Left=�6I   $��5,3,0,0q�6d   6u   5�      5�      �� 5�   
   $��1��6   $��2��6%   $ Vertical=�62   .+�5�      �� -   5         ��Name$ VehiculeDataContext��5�   B   $ Vertical=�6   $��20,0,0,0q�60    5�      ��%  '��       '�� �     7���� 5�      " ��6   .�5�      ��  �@��Orientation$ 
Horizontal=�68   �� 5�       � ��$ 0,0,0,5q�63   5�      �� 5�      " ��6   8   .�5�      ��  � ��$	 145��62   �� 5�       � ��$ Center=�6>   5�      5�      .+�5�      �� $��DONNEES VEHICULE��6   #��[  64   $��0,0,0,15q�6V   �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Marque��6   �� 5�      -   5        $ marqueVehicule��5�      $	��150��66    . ��6T   �� *marque+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Modèle��6   �� 5�      -   5        $ modeleVehicule��5�      $	��150��66    . ��6T   �� *modele+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Date mise en service��6   �� 5�      -   5        $ dateMESVehicule��5�      $	��150��67    . ��6U   �� *date_mise_en_service+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Immatriculation��6   �� 5�      -   5        $ immatriculationVehicule��5�       . $	��150��6Q   ��6]   �� *immatriculation+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Numéro de série��6   �� 5�      -   5        $ numSerieVehicule��5�       . $	��150��6J   ��6V   �� *numero_serie+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Type de véhicule��6   �� 5�      -   5        $ TypeVehicule��5�       . $	��150��6F   ��6R   �� *type_vehicule+5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Kilométrage��6   �� 5�      -    5        $ 
kmVehicule��5�       . $	��150��6D   ��6P   �� *kilometrage+5�      5�      �� 5     -!   5        $ DataContact��5     $��1��6.   $ Vertical=�6>   $��	20,20,0,0q�6U    5     ��%  '��       '�� �     7���� 5     " ��6   .�5     ��  �@��Orientation$ 
Horizontal=�68   �� 5      � ��$ 0,0,0,5q�63   5     �� 5     " ��6   8   .�5	     ��  � ��$	 145��62   �� 5
      � ��$ Center=�6>   5     5     .+�5     �� $��DONNEES CONTACT��6   #��[  63   $��0,0,0,15q�6U   �� 5     $ 
Horizontal=�6   .+�5     �� $��Liste des contacts ��6   �� 5     -"   5        $ ComboListContact��5     $	��150��69   ��5     �� 5     .R�5  "   �� $��12(�6,   �� 5  "   �6&   �� *prenom+ �� 5  "   $� ��6&    �� 5  "   �6&   �� *nom+5  #   5     5     5     �� 5     $ 
Horizontal=�6   .+�5     �� $	��Nom��6   �� 5      -#   5        $ LastNameClient��5      $	��150��6K    . ��66   �� *nom+6W   5!     �� 5#     $ 
Horizontal=�6   .+�5$     �� $��Prénom��6   �� 5%     -$   5        $ FirstNameClient��5%     $	��150��6O    . ��67   �� *prenom+6[   5&     �� 5(     $ 
Horizontal=�6   .+�5)     �� $��Fonction��6   �� 5*     -%   5        $ FunctionClient��5*     $	��150��6P    . ��66   �� *
fonction+6\   5+     �� 5-     $ 
Horizontal=�6   .+�5.     �� $��Numéro de téléphone 1��6   �� 5/     -&   5        $ NumTel1Client��5/     $	��150��6Y    . ��65   �� *numero_telephone_1+6e   50     �� 52     $ 
Horizontal=�6   .+�53     �� $��Numéro de téléphone 2��6   �� 54     -'   5        $ NumTel2Client��54     $	��150��6Y    . ��65   �� *numero_telephone_2+6e   55     �� 57     $ 
Horizontal=�6   .+�58     �� $��Adresse email��6   �� 59     -(   5        $ EmailClient��59     $	��150��6R    . ��63   �� *adresse_email+6^   5:     �� 5<     $ 
Horizontal=�6   .+�5=     �� $��Numéro de fax��6   �� 5>     -)   5        $ NumFaxClient��5>     $	��150��6P    . ��64   �� *
numero_fax+6\   5?     5@     5A     �� 5C  
   $��2��6   $��2��6%   $ Vertical=�62   $��20,0,0,0q�6I    5D     ��%  '��       '�� �     7���� 5E     " ��6   .�5F     ��  �@��Orientation$ 
Horizontal=�64   �� 5G      � ��$ 0,0,0,5q�6/   5H     �� 5J     " ��6   8   .�5K     ��  � ��$	 145��6.   �� 5L      � ��$ Center=�6:   5M     5N     .+�5P     �� $��Ajouter une pièce��6   #��[  61   $��0,0,0,15q�6S   �� 5R     $ 
Horizontal=�6   .+�5S     �� $��Liste des pièces��6   �� 5T     -*   5        $ ComboListPieces��5T     $	��150��64   ��5U     �� 5V     .R�5W     �� $��12(�6(   �� 5X  "   �6&   �� *	reference+ �� 5Y  "   $	� : ��6&    �� 5Z  "   �6&   �� *designation+5[     5\     5^     5_     �� 5a     $ 
Horizontal=�6   .+�5b     �� $��Quantite��6   �� 5c     -+   5        $ QuantitePieceIntervention��5c     $	��150��6=   5d     �� 5f     $ 
Horizontal=�6   .+�5g     �� $��Remise��6   �� 5h     -,   5        $ RemisePieceIntervention��5h     $	��150��6;   5i     �� 5k     $ 
Horizontal=�6   .+�5l     �� --   5        $ CreatePiece��5l     $��Créer une pièce��6.   $
��Left=�6H   $��0,20,0,0q�6c   6u   �� 5m     -.   5        $ AddPiece��5m     $��Ajouter la pièce��6+   $
��Left=�6F   $��	10,20,0,0q�6a   6t   5n     �� 5p     $"��Liste des pièces utilisées��6   #��[  6:   $��	0,10,0,15q�6\   &   System.Windows.Controls.DataGrid  5r     -/   5        $��pieceInterventionDataGrid��5r     $	��150��68   $��0��6E   "   VerticalScrollBarVisibility$ Visible=�6R      AutoGenerateColumns .     SelectionMode$ Single=�6�      
IsReadOnly .     Columns  5s     =  7FirstFloor.ModernUI.Windows.Controls.DataGridTextColumn  5t     ,  &System.Windows.Controls.DataGridColumn!   Header$! Référence��6-   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 6A   �� *	reference+  5u     $! Remise��6-   " 6=   �� *remise+  5v     $! Quantite��6-   " 6?   �� *
quantite+5x     �� 5z     -0   5        $! PieceInterventionStackPanel��5z     $y�	Collapsed=�6>   $ Vertical=�6U   .+�5{     �� $ 
Horizontal=�6   .+�5|     �� $��Référence��6   �� 5}     -1   5        $ refPieceInter��5}     {�.  $	��150��6b   ��6G   �� *	reference+6b   5~     �� 5�     $ 
Horizontal=�6   .+�5�     �� $��Remise��6   �� 5�     -2   5        $ RemisePieceInter��5�     $	��150��6P   ��68   �� *remise+6P   5�     �� 5�     $ 
Horizontal=�6   .+�5�     �� $��Quantite��6   �� 5�     -3   5        $ quantitePieceInter��5�     $	��150��6T   ��6:   �� *
quantite+6T   5�     �� 5�     $ 
Horizontal=�6   .+�5�     �� -4   5        $ UpdatePieceIntervention��5�     $��Modifier��6>   $
��Left=�6Q   $��0,20,0,0q�6l   6~   �� 5�     -5   5        $ DeletePieceIntervention��5�     $��	Supprimer��6>   $
��Left=�6R   $��	10,20,0,0q�6m   6�   5�     5�     5�     � 5�  
   -6   5        $ popup��5�     $	 100��6   $��3��61   $y�	Collapsed=�6B   $��0��6Y   $��0��6f   $��Center=�6v   $��Center=�6�   $��3��6�    5�     �� 5�     $
��0.9* �6    �� 5�     $��* �6    .+�5�     �� -7   5        # ��Name$# 
imagePopup��5�     $��0��6(   �� 5�     -8   5        $ 
ClosePopup��5�  "   $��1��6   $��Fermer��66   
���   �$��14(�6Z   6h   5�     5�     5�     