   M S B A M L   `   `   `  ����  HelpParebrise&     HelpParebrise.Views.AddInsurance   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5        � DataContext  5      �� *DefaultViewModel+ �� RelativeSource �� *Self+.��5
      �    ContentRoot#��[  6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��0.3* �6   .+�5   
   � -   5         �Name$ GridProgressRing��5      $y�Visible=�6*   
������� K� ZIndex$ 1��6R   $��Center=�6c   $��Center=�6�   .+�5      =  7FirstFloor.ModernUI.Windows.Controls.ModernProgressRing     IsActive . $��80��66   ���	#FFE20013$��80��6X   ��6d   �� *SelectedItem.Tag+ �� ElementName$ CmbRingStyle��5      �� 5   
   $��0��6    �� Orientation$ Vertical=�6%   $��20,0,0,0q�6<    � 	Resources 5      	 �� 
TargetType
 �� Property �� Value �� BasedOn��%  '��       '�� �     7���� 5      "	 ��6   .�5      �� 
 �@��Orientation$ 
Horizontal=�64   �� 5      
 � ��$ 0,0,0,5q�6/   5      �� 5      "	 ��6   8   .�5      �� 
 � ��$	 145��6.   �� 5      
 � ��$ Center=�6:   5      5      .+�5!      �� $��DONNEES ASSURANCE��6     Heading2#��[ 61   $��0,0,0,15q�6S   �� 5#      $ 
Horizontal=�6   .+�5$      �� $	��Nom��6   �� 5%      -   5         ��Name$
 Name��5%      $	��150��6(   5&      �� 5(      $ 
Horizontal=�6   .+�5)      �� $��Adresse��6   �� 5*      -   5        $ Adresse��5*      $	��150��6+   5+      �� 5-      $ 
Horizontal=�6   .+�5.      �� $��Ville��6   �� 5/      -   5        $ Ville��5/      $	��150��6)   50      �� 52      $ 
Horizontal=�6   .+�53      �� $��Code postal��6   �� 54      -   5        $ 
CodePostal��54      $	��150��6/   55      �� 57      $ 
Horizontal=�6   .+�58      �� $��Numéro de téléphone��6   �� 59      -   5        $ NumTel��59      $	��150��6*   5:      �� 5<      $ 
Horizontal=�6   .+�5=      �� $��Numéro de fax��6   �� 5>      -   5        $ NumFax��5>      $	��150��6*   5?      �� 5A      $ 
Horizontal=�6   .+�5B      �� $��Adresse email��6   �� 5C      -   5        $ Email��5C      $	��150��6)   5D      �� 5F      $ 
Horizontal=�6   .+�5G      �� $��Numéro de contrat��6   �� 5H      -	   5        $ 
NumContrat��5H      $	��150��6.   5I      �� 5K      $ 
Horizontal=�6   .+�5L      �� -
   5         ��Name$	 Add��5L      $��Ajouter��6&   $
��Left=�68   $��0,20,0,0q�6S   6e   �� 5M      -   5        $ 
AddContact��5M      $��Ajouter un contact��6-   $
��Left=�6J   $��	10,20,0,0q�6e   6x   5O      5P      �� 5R   
   -   5         ��Name$ DataContact��5R      $��1��6*   $ Vertical=�6:   $��20,0,0,0q�6Q    5S      ��%  '��       '�� �     7���� 5T      "	 ��6   .�5U      �� 
 �@��Orientation$ 
Horizontal=�64   �� 5V      
 � ��$ 0,0,0,5q�6/   5W      �� 5Y      "	 ��6   8   .�5Z      �� 
 � ��$	 145��6.   �� 5[      
 � ��$ Center=�6:   5\      5]      .+�5^      �� $��DONNEES CONTACT��6   #��[ 6/   $��0,0,0,15q�6Q   �� 5`      $ 
Horizontal=�6   .+�5a      �� $��Liste des contacts ��6   �� 5b      -   5         ��Name$ ComboListContact��5b      $	��150��65   ��5c      �� 5d      .R�5e      �� $��12(�6(   �� 5f   "   �6&   �� *prenom+ �� 5g   "   $� ��6&    �� 5h   "   �6&   �� *nom+5i      5j      5l      5m      �� 5o      $ 
Horizontal=�6   .+�5p      �� $	��Nom��6   �� 5q      -   5        $ LastNameClient��5q      $	��150��6G    �� 
IsReadOnly . ��62   �� *nom+6S   5r      �� 5t      $ 
Horizontal=�6   .+�5u      �� $��Prénom��6   �� 5v      -   5        $ FirstNameClient��5v      $	��150��6K    . ��63   �� *prenom+6W   5w      �� 5y      $ 
Horizontal=�6   .+�5z      �� $��Fonction��6   �� 5{      -   5        $ FunctionClient��5{      $	��150��6L    . ��62   �� *
fonction+6X   5|      �� 5~      $ 
Horizontal=�6   .+�5      �� $��Numéro de téléphone 1��6   �� 5�      -   5        $ NumTel1Client��5�      $	��150��6T    . ��61   �� *numero_telephone1+6`   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Numéro de téléphone 2��6   �� 5�      -   5        $ NumTel2Client��5�      $	��150��6T    . ��61   �� *numero_telephone2+6`   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Adresse email��6   �� 5�      -   5        $ EmailClient��5�      $	��150��6N    . ��6/   �� *adresse_email+6Z   5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��Numéro de fax��6   �� 5�      -   5        $ NumFaxClient��5�      $	��150��6L    . ��60   �� *
numero_fax+6X   5�      5�      5�      5�      