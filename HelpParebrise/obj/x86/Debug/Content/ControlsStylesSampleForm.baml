   M S B A M L   `   `   `  ����H  DHelpParebrise, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:FirstFloor.ModernUI.AppFirstFloor.ModernUI.App  5      >    8FirstFloor.ModernUI.App.Content.ControlsStylesSampleForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null0mui&http://firstfloorsoftware.com/ModernUI  5      /app%clr-namespace:FirstFloor.ModernUI.App  5      .��5
      �� .��5   
   �� $	��200��6   .+�5      �� $��SAMPLE FORM��6      Heading2#��[  6+   $��0,0,0,8q�6M   6  0FirstFloor.ModernUI.Windows.Controls.BBCodeBlock  5          BBCode$g  aA sample form demonstrating various controls with support for validation and focus visualization.��6   $��0,0,0,16q�6�   �� 5      -   5         ��Name$
 Form��5       �� Orientation$ Vertical=�6'    � DataContext 5      1   +FirstFloor.ModernUI.App.SampleFormViewModel  5       � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%�  '��       '�� �     7��'�� �     7��'	� I    7	��� 5      " ��6   .�5      ��  �@��Orientation$ 
Horizontal=�68   �� 5       � ��$ 0,0,0,4q�63   5      �� 5      " ��6   8   .�5      ��  � ��$	 100��62   �� 5        � ��$ Center=�6>   5!      �� 5"      " ��6   8   .�5#      ��  � ��$	 0,3q�64   5$      �� 5%      " 	�6   8   .�5&      ��  � ��$	 0,3q�64   5'      5(      .+�5*      �� .+�5+      �� $��
First name��6   	 �� Target	 61   �� 
 �� ElementName$
 TextFirstName���� 5,      -   5         ��Name$ TextFirstName��5,      $	��150��65   ��6A   �� *	FirstName+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5-      �� 5.      .+�5/      �� $��	Last name��6   	 60   �� $
 TextLastName���� 50      -   5        $ TextLastName��50      $	��150��64   ��6@   �� *
LastName+$ TwoWay=� . 51      �� 52      .+�53      �� $��Gender��6   	 6-   �� $
 RadioGendeMale��	� 54      -   5         	�Name$ RadioGendeMale��54   "   $
��Male��6:   	� 55      $��Female��6"   $��8,0,0,0q�63   56      �� 57      .+�58      �� $��
Birth date��6   	 61   �� $
 	DateBirth��(  "System.Windows.Controls.DatePicker  59      -   5          Name$ 	DateBirth��59   !   5:      �� 5;      .+�5<      �� $��Address��6   	 6.   �� $
 TextAddress���� 5=      -   5        $ TextAddress��5=      $	��150��63   5>      �� 5?      .+�5@      �� $
��City��6   	 6+   �� $
 TextCity���� 5A      -   5        $ TextCity��5A      $	��150��60   5B      �� 5C      .+�5D      �� $��State��6   	 6,   �� $
 
ComboState���� 5E      -   5         ��Name$ 
ComboState��5E      $	��150��63   .@�5F      �� .��6'   	Alabama60   �� 5G      .��6'   Alaska6/   �� 5H      .��6'   	Arizona60   �� 5I      .��6'   
Arkansas61   �� 5J      .��6'   
California63   �� 5K      .��6'   
Colorado61   �� 5L      .��6'   Connecticut64   �� 5M      .��6'   
Delaware61   �� 5N      .��6'   	Florida60   �� 5O      .��6'   	Georgia60   �� 5P      .��6'   Hawaii6/   �� 5Q      .��6'   Idaho6.   �� 5R      .��6'   
Illinois61   �� 5S      .��6'   	Indiana60   �� 5T      .��6'   Iowa6-   �� 5U      .��6'   Kansas6/   �� 5V      .��6'   
Kentucky61   �� 5W      .��6'   	Louisiana62   �� 5X      .��6'   Maine6.   �� 5Y      .��6'   
Maryland61   �� 5Z      .��6'   Massachusetts66   �� 5[      .��6'   
Michigan61   �� 5\      .��6'   	Minnesota62   �� 5]      .��6'   Mississippi64   �� 5^      .��6'   
Missouri61   �� 5_      .��6'   	Montana60   �� 5`      .��6'   
Nebraska61   �� 5a      .��6'   Nevada6/   �� 5b      .��6'   New Hampshire66   �� 5c      .��6'   
New Jersey63   �� 5d      .��6'   
New Mexico63   �� 5e      .��6'   
New York61   �� 5f      .��6'   North Carolina67   �� 5g      .��6'   North Dakota65   �� 5h      .��6'   Ohio6-   �� 5i      .��6'   
Oklahoma61   �� 5j      .��6'   Oregon6/   �� 5k      .��6'   Pennsylvania65   �� 5l      .��6'   Rhode Island65   �� 5m      .��6'   South Carolina67   �� 5n      .��6'   South Dakota65   �� 5o      .��6'   	Tennessee62   �� 5p      .��6'   Texas6.   �� 5q      .��6'   Utah6-   �� 5r      .��6'   	Vermont60   �� 5s      .��6'   
Virginia61   �� 5t      .��6'   
Washington63   �� 5u      .��6'   West Virginia66   �� 5v      .��6'   	Wisconsin62   �� 5w      .��6'   	Wyoming60   5x      5y      �� 5z      .+�5{      �� $��Zip code��6   	 6/   �� $
 TextZipCode���� 5|      -	   5        $ TextZipCode��5|      $	��150��63   5}      �� 5~      .+�5      �� �� 5�      $!��I agree to the terms of use��6   5�      �� 5�      $��Submit��6   $��
100,16,0,0q�6*   $
��Left=�6>   5�      5�      5�      5�      