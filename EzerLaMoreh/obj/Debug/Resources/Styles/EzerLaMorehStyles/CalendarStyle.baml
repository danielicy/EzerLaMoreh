   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source:    4System.Windows.Controls.Primitives.CalendarDayButton �� 
TargetType   CalendarDayButtonStyle7   1System.Windows.Controls.Primitives.CalendarButton  CalendarButtonStyle �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   Name   Transitions%   System.Windows.VisualTransition	   GeneratedDuration
   States    System.Windows.VisualState   Name   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration	 �� To R� KeyTime R� Value  System.Windows.Visibility ��Name �� RadiusX �� RadiusY J� Opacity  SelectedBackgroundColor �� Color ��Name J� IsHitTestVisible  PreviousButtonTemplate � Cursor  GlyphMouseOver F�Name �� Stretch  
GlyphColor  NextButtonTemplate  CalendarItemStyle5   /System.Windows.Controls.Primitives.CalendarItem ��Name  HeaderButtonTemplate&    System.Windows.Controls.Calendar 	 standardCalendar�� 5      J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        :x,http://schemas.microsoft.com/winfx/2006/xaml      5        5      �� 5   
   $ EzerCoreStyles.xaml?�6   %�  &	        &	 !     &	 4
    &	 O    7  &	 `    &	 ,    &		     7  �� 5
      "   6   5�      �� 5�      "  6   .�5�   
   ��  � ��$ 40��5�      �� 5�   
    � ��$ 42��5�      �� 5�   
    � ��$ 10(�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � �� 5�      �� 5�      "  6"   .R�5�      �  5�        5�      $ CommonStates��6/    5�   "     5�   &   $	 0:0:0.1D�67   .
 5�   "     $ Normal��6.     5�   "   $ 	MouseOver��6.   . 5�   &   �� .��5�   *   W� $ 
Background��6:   $ Opacity�5�   $   $ .5X�5�   $   $ 0D�5�   $   5�   '   5�   #     5�   "   $ Pressed��6.   . 5�   &   �� .��5   *   W� $ 
Background��6:   $ Opacity�5  $   $ .5X�5  $   $ 0D�5  $   5  '   5  #   5       5     $ SelectionStates��6/    5  "     5	  &   $	 0D�67   .
 5  "     $ 
Unselected��6.     5  "   $ Selected��6.   . 5  &   �� .��5  *   W� $ SelectedBackground��6:   $ Opacity�5  $   $	 .75X�5  $   $ 0D�5  $   5  '   5  #   5       5     $ ActiveStates��6/    5  "     5  &   $	 0D�67   .
 5  "     $ Active��6.     5  "   $ Inactive��6.   . 5  &   �� .��5  *   �� $ 0D�69   $ 
NormalText��5  #   $M G(TextElement.Foreground).                       (SolidColorBrush.Color)�5  #   $ 	#FF777777X�5   #   5!  '   5"  #   5#       5$     $ CalendarButtonFocusStates��6/    5%  "     5&  &   $	 0D�67   .
 5(  "     $ CalendarButtonFocused��6.   . 5)  &   �� .��5*  *   T� $ 0D�6H   $ CalendarButtonFocusVisual��5+  2   $ 
Visibility�5,  2   ..�5-  .   i� $ 0��6E    5.  2    5/  6   Visible=�6J   51  /   52  +   53  '   54  #     55  "   $ CalendarButtonUnfocused��6.   56     .+�58     �� $ SelectedBackground��6$   $ 1��59     $ 1��5:     $ 0Q�5;     ��5<     �� 5=  "   # �  62   5?     �� 5@     $ 
Background��6$   $ 1��5A     $ 1��5B     $ 0Q�5C     ��5D     �� 5E  "   # �  62   5G     �� 5H     $ 
NormalText��6+   #��z��5I     #��z��5J     $��1,0,1,1q�5K     ��5L     �� 5M  "   $ 	#FF333333��62   5O     �� 5P     $ CalendarButtonFocusVisual��6$   $y�	Collapsed=�5Q      .  $ 1��5S     $ 1��5T     ��5U     �� 5V  "   # �  62   5X     5Y     5Z     5\     �� 5]  
    � �� 5^     �� 5_     $ 	#FFFF0F0F��6"   5a     5b     �� 5f     " ��5g     .R�5h  
   � $
 Hand��6    5i       5j     CommonStates��.
 5k       
Normal��6"     5l     	MouseOver��. 5m     �� .��5n     �� $ 0D�6-   $
 path��5o     $* $(Shape.Fill).(SolidColorBrush.Color)�5p     # �  5q     5r     5s       5t     Disabled��. 5u     �� .��5v     W� $ 0D�6.   $ .5X�5w     $" (Shape.Fill).(Brush.Opacity)�5x     $
 path��5y     5z     5{     5|     .+�5     � 
������ .+�5�     F� $
 path��6   $��	14,-6,0,0q�5�     $
 Fill=�5�     $
��Left=�5�     $��10��5�     $��Center=�5�     $��6��5�     "�����5���Ѱ�5h�W��<�h�	��5�     �� 5�     # �  6*   5�     5�     5�     5�     �� 5�     " ��5�     .R�5�  
   � $
 Hand��6    5�       5�     CommonStates��.
 5�       
Normal��6"     5�     	MouseOver��. 5�     �� .��5�     �� $ 0D�6-   8   $* $(Shape.Fill).(SolidColorBrush.Color)�5�     $
 path��5�     5�     5�       5�     Disabled��. 5�     �� .��5�     W� $ 0D�6.   $ .5X�5�     $" (Shape.Fill).(Brush.Opacity)�5�     $
 path��5�     5�     5�     5�     .+�5�     � 
������ .+�5�     F� $
 path��6   "����xT��!��xT���S�h4 	$��Right=�5�     $��10��5�     $��	0,-6,14,0q�5�     $
 Fill=�5�     $��Center=�5�     $��6��5�     ��5�     �� 5�     # �  6*   5�     5�     5�     5�     �� 5�     "  6&   .�5�  
   ��  � �� 5�     �� 5�     "  6"   .R�5�  &   �� $ PART_HeaderButton��6-   $	��100��5�  .   ���	#FFFF0F0F5�  -   5�     5�     5�     �� 5�     " ��5�     .R�5�  
   � $
 Hand��6   .+�5�     �� $ buttonContent��6   $	��100��5�     $��20��5�     #��z��5�     #��z��5�     ���	#FFFF0F0F5�     5�     5�     �� 5�     "  6   .�5�  
   ��  �@ CalendarItemStyle8   5�     5�     5�     