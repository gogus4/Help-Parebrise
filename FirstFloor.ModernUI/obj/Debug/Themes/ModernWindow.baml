   M S B A M L   `   `   `  ����N  JFirstFloor.ModernUI, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FirstFloor.ModernUIFirstFloor.ModernUI  5      [2clr-namespace:FirstFloor.ModernUI.Windows.Controls$FirstFloor.ModernUI.Windows.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source7    1FirstFloor.ModernUI.Windows.Controls.ModernWindow �� 
TargetType �� Property   WindowBackgroundContent �� Value  DefaultFontFamily  DefaultFontSize  
WindowText&   System.Windows.Media.TextOptions �� 
TargetType ��Name%  System.Windows.SystemParameters$   WindowNonClientFrameThickness �� Source  WindowBackgroundColor	 �� Color
 � 	Resources  Key �� 
TargetName �� TargetProperty	 �� To g� Duration  WindowBorder �Name � RowDefinitions    BackgroundContent  ModernWindowTitle    IsTitleVisible � DataContext  ToUpperConverter �� 	Converter  	 BooleanToVisibilityConverter �� 	Converter � LayoutTransform �� Angle �� Orientation'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome#   FirstFloor.ModernUI.Resources   Minimize � ToolTip 
 SystemButton#  System.Windows.SystemCommands   MinimizeWindowCommand �� RelativeSource �� Mode �� AncestorType  ��Name!   Maximize"   MaximizeWindowCommand#   Restore$   RestoreWindowCommand% � UseLayoutRounding&   Close'   CloseWindowCommand(    
TitleLinks) ��Name	* �� X1	+ �� Y1	, �� X2	- �� Y2  SeparatorBackground  SystemButtonLink. �� ElementName/ �� Triggers0 �� Binding1 �� Value2 �� 
TargetName5   /FirstFloor.ModernUI.Windows.Controls.ModernMenu3    MenuLinkGroups4   
LinkGroups5   SelectedSource6 �� Mode7   1FirstFloor.ModernUI.Windows.Controls.ModernButton7   IconData6   0FirstFloor.ModernUI.Windows.Controls.ModernFrame8  Name9    ContentLoader:   ContentLoader;   Source< ��Name= F�Name> �� Stretch? �� Triggers@ P� PropertyA P� ValueB ]� 
ConditionsC �� PropertyD �� ValueE   CornerRadiusF   GlassFrameThicknessG   UseAeroCaptionButtonsH   NonClientFrameEdges�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .modernui!clr-namespace:FirstFloor.ModernUI  5      ?controls2clr-namespace:FirstFloor.ModernUI.Windows.Controls  5        5      �� 5   
   $7 1/FirstFloor.ModernUI;component/Assets/Button.xaml?�6   �� 5   
   $; 5/FirstFloor.ModernUI;component/Assets/Converters.xaml?�6   %�  '         7  7 	 7 
 7 
 7 
 7 
 7  7 	 �� 5      "   6   .�5   
   ��  �@  BackgroundContent# �   6.   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6%   �� 5   
    � ��# �  6'   �� 5   
    �@�
ResizeMode$ NoResize=�6'   �� 5   
    �@�UseLayoutRounding . 6.   �� 5   
    �@ TextFormattingMode$ Display=�6;   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ WindowBorder��6   ��63   �� # Z ��5      �� 5      WindowBorderBackground��#	 �  6N   
 5      ���� 5      BackgroundAnimation .��5   "   �� $ WindowBorderBackground��61   $ Color�6`   # �  6�   $ 0:0:.6D�6�   5      5      ._�5!      � .+�5"      �� #���  6%   $��1q�6R   ._�5#   "   �� .u�5$   &   � $ 
LayoutRoot��6+    5%   *   �� 5&   .   $��36 �6<   �� 5'   .   $
��Auto �6<   �� 5(   .   $
��Auto �6<   �� 5)   .   $��* �6<   �� 5*   .   $��60 �6<   .+�53   *   �� $��5��69   #��z 6J   �� 56   *   $��5��61   ���	#FFE20014$z�1,0,0,1,0,32W�58   1   $��14��59   1   $��53��6?   $
��Left=�5:   1   $	��Top=�5;   1   ._�5<   .   �� 
�������$	��0,8q�5>   8   #���  5?   8   $��Center=�5@   8   # z 5A   8   ��5<   8   �� *Title+8   y�5B   8   �� 8   5C   2   �� 5D   6   $	 -90Q�6F   5F   /   5G   +   �� 5I   *   $��0��65   $��2��6B   $ Vertical=�6S   $��
770,10,0,0q�6j   .+�5J   .   �� $3��-/FirstFloor.ModernUI;component/Assets/elm.png��64   $	��180��6k   $��90��6w   5K   +   �� 5N   *   $ 
Horizontal=�65   $��Right=�6N   $	��Top=�6j   $��0,8,6,0q�6�    . .+�5O   .   �� # Z 6�   8�� ��65   �� # Z ��5P   2   � 5Q   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5R   :   F� ����    ��[ � z ��[ 	$��8��6R   $��7��6\   $��Center=�6g   $��Center=�6�   $��2��5S   �   ��6?   �� *
Foreground+ �� $ FindAncestor=�$ ButtonL�6�   5T   7   5V   /   �� 5X   .   $  Maximize��65   # Z! 6�   8�� ��6G   �� # Z" ��5Y   2   � 5Z   6   $��13��6;   $��12��6F   .+�5[   :   F� +����    @B �@T� @B �@T�  z �     z 	$��9��6\   $��8��6f   $��Center=�6q   $��Center=�6�   $��2��5\   �   ��6C   �� *
Foreground+ �� $ FindAncestor=�$ ButtonL�6�   5]   7   5_   /   � 5a   .   $��1,0,1,0q�63   .+�5b   2   �� $  Restore��69   # Z# 6�   8�� $y�	Collapsed=�6�   ��6J   �� # Z$ ��5c   6   � 5d   :   $��13��6?   $��12��6J   % . $z�1,0,0,1,.5,.5W�6o   .+�5e   >   F� X���Ѐ�     � z     � z ��[ �    ��- р�[ ��- �    �� р�[ �� р�[  z �     z 	$��8��6y   $��8��6�   $��Center=�6�   $��Center=�6�   $��1��5f   �   ��6C   �� *
Foreground+ �� $ FindAncestor=�$ ButtonL�6�   5g   ;   5i   3   5j   /   �� 5k   .   # Z& 6}   8�� ��65   �� # Z' ��5l   2   � 5m   6   $��13��6;   $��12��6F   $z�1,0,0,1,0,1W�6R   .+�5n   :   F� +����        � z ��j � z     �    ��j 	$��8��6\   $��7��6f   $��Center=�6q   $��Center=�6�   $	��1.5��5o   �   ��6?   �� *
Foreground+ �� $ FindAncestor=�$ ButtonL�6�   5p   7   5r   /   5s   +   �� 5v   *   #��z( 67   $��Right=�6b   $	��Top=�6~   $��	0,6,180,0q�6�    . ��5w   .   �� 5x   2   .R�5y   6   �� $ 
Horizontal=�6A   5z   3   ��5|   .   �� 5}   2   .R�5~   6   �� $ 
Horizontal=�6A   .+�5   :   �� $) 	Separator��6?   $* .5��6R   $+ 3��6Z   $, .5��6a   $- 12��6i   $��7,0,5,0q�6q   #���  6�   �� 5�   :   $!��NavigationCommands.GoToPage��5�   A   8�� ��5�   A   �� *DisplayName+��5�   A   �� *Source+��5�   A   �� $. ContentFrame��5�   A   5�   7   / 5�   6   �� 5�   :   0 6F   ��  �� *PreviousData+1 6�   Z� .a�5�   >   �� $2 	Separator��6[    � y�$ 	Collapsed=�6r   5�   ;   5�   3   5�   +     5�   *   $��1��6>   $��36,0,0,0q�5�   >   #4 z3 5�   >   5 5�   >   �� *Source+$. ContentFrame��$6 TwoWay=�5�   >     5�   *   a7 ��@����O�@������p\-�������@��� �8@����ا  6n� �8��� ������� �p\-��O�@����O$#��NavigationCommands.BrowseBack��5�   @   $
 back��5�   @   $��2��5�   @   $
��Left=�6Q   $	��Top=�6l   $��	34,24,0,0q�6�    . ��5�   @   �� $. ContentFrame��5�   +     5�   *   $8 ContentFrame��6?   $��3��6U   $��2��6b   $��
36,8,16,16q�6s   #: z9 6�   ; 6�   �� *ContentSource+ �� *TemplatedParent+$6 TwoWay=�6�   �� 5�   *   $< Version��64   $��10(�6�   $��Right=�6�   $��4��6�   $��	0,35,20,0q�6�   ��6E   �� *	Version+ �� *TemplatedParent+$6 TwoWay=�6�   � 5�   *   $��4��6/   .+�5�   .   F� $= 
ResizeGrip��63   $y�	Collapsed=�6G   $��12��6^   $��12��6i   $��1q�6u   $��Right=�6�   #���  5�   3   $��1��5�   3   $
> None=�5�   3   �����@B ��� ���- ��� �@KL ��� ���j ��� �@T� ��� ��ا ��� Ѐ� @T� р� �ا Ѐ�[ @T� р�[ �ا Ѐ�� @T� р�� �ا �@KL ��[ ���j ��[ �@T� ��[ ��ا ��[ Ѐ�[ @KL р�[ ��j Ѐ�� @KL р�� ��j �@T� �� ��ا �� Ѐ�� @B р�� ��- 5�   3   5�   +   5�   '   5�   #   5�      �� 5�      ���	#FFE20013$��1q�6=   y�6Q   �� *
IsActive+ �� *FindAncestor+" �8  5�      5�      ? 5�      P� 5�      @ �@�WindowState$A 	Maximized=�69   . �5�      �� $2 Restore��6%    � y�$ Visible=�6P   �� 5�      $2 
LayoutRoot��6%    � ��$ 7q�6O   5�      P� 5�      @ �@�WindowState$A Normal=�69   . �5�      �� $2 Restore��6%    � y�$ 	Collapsed=�6P   5�      ]� 5�      B 5�      �� 5�   "   C �@�
ResizeMode$D CanResizeWithGrip=�6B   �� 5�   "   C �@�WindowState$D Normal=�6C   ./�5�      �� $2 
ResizeGrip��6%    � y�$ Visible=�6S   5�      5�      5�      �� 5�   
    �@ WindowChrome 5�        5�      $E 0��6   $F 1q�60   G .  $
H None=�6f   5�      5�      5�      