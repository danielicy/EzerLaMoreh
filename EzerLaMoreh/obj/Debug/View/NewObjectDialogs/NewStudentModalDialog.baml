   M S B A M L   `   `   `  ����F  BEzerLaMoreh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:EzerLaMoreh.CustomUser_ControlsEzerLaMoreh.CustomUser_Controls  5      0    *EzerLaMoreh.View.add.NewStudentModalDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   @custom-clr-namespace:EzerLaMoreh.CustomUser_Controls     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � WindowStartupLocation$  CenterScreen=�5	   ;      ModalDialogTemplate#��[  6`     PopupWindow#��[ 6�    � Title$ תלמיד חדש��5
   	   $	��420��6   $	��730��6(    � 	Resources 5        HeaderButtonTemplate �� 
TargetType � Cursor'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration  GlyphMouseOver		 �� To
 �� TargetProperty �� 
TargetName	 W� To ��Name��%�  &	       �� 5   
   " ��5      .R�5      � $
 Hand��6    5        5      CommonStates��. 5        
Normal��6&     5      	MouseOver��. 5      �� .��5   "   �� $ 0D�61   #	 �  5      $6
 0(TextElement.Foreground).(SolidColorBrush.Color)�5      $ buttonContent��5      5      5        5      Disabled��. 5      �� .��5   "   W� $ 0D�62   $ .5X�5      $
 Opacity�5      $ buttonContent��5      5       5!      5"      .+�5$      �� $ buttonContent��6#   $	��100��6:   $��20��6F   #��z��5%      #��z��5&      ���	#FFFF0F0F5'      5(      5)      5*      .��5,      �  5-   
    �� DataType-  'System.Windows.Controls.ValidationError �� Path��%�   (��       5.      *, +)�� 6   "  6   .R�5/      �� $��Italic$�6   
���  ��$��10(�50      $	��0,1q�6*   ��67   �� $ ErrorContent�51      52       � ColumnDefinitions 54   
   �� 55      $
��212* �6   �� 56      $
��241* �6   �� 57      $
��269* �6    � RowDefinitions 59   
   �� 5:      $	��55* �6   �� 5;      $	��46* �6   �� 5<      $	��57* �6   �� 5=      $	��70* �6   �� 5>      $	��66* �6   �� 5@      $	��67* �6   �� 5B      $	��51* �6   .+�5D   
   �� $"��הוספת תלמיד חדש��6   $��1��6*     HeaderLabel#��[ 6:   $��	40,7,31,7q�6_   $	��170��6r   �� 5E   
   $��2��6    �� Orientation$ 
Horizontal=�6%   .+�5F      �� $��	כיתה:��6   �� 5G      ��6   �� $ class1.ClassName�5I      �� 5J   
   $��2��6   .+�5K      1   +EzerLaMoreh.CustomUser_Controls.CloseButton  $��Right=�6#   $��
 0,10,30,0q�6@   5L      �� 5N   
   $��4��6   $��25,25q�6"    �� CornerRadius$ 30��6:   $	��200��6L   $	��Top=�6Y   ��5O      �� 5P       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5Q      �  � Color$ 	#FF547BFF��6#    � Offset$ 0Q�65   � 5R      $ White��6#   $ 1Q�61   5S      ._�5U      ��   BrowsePicButton#��[ 6   5W      � 5X   
   $��1��6   $��1��6!    5Y      �� 5Z      $��30 �6    �� 5[      .+�5]      �� $��שם פרטי��6   �� 5^      -   5         ��Name$ txtName��5^       �� TextWrapping$
 Wrap=�6(   $	��120��6�   ��6<   �� $ Model.FirstName� �� ValidatesOnDataErrors .  �� UpdateSourceTrigger$ PropertyChanged=� =� ErrorTemplate 5_   %   Z� �� 5`      $��1��6!   ��5a      ��  �� ElementName$ txtName��$% (Validation.Errors).CurrentItem�5b      � 5c   
   $��2��6   $��1��6     5d      �� 5e      $��30 �6    �� 5f      .+�5h      �� $��שם משפחה��6   �� 5i      -   5        $ txtLastName��5i      $
 Wrap=�6+   $	��120��6e   ��6?   �� $ Model.LastName�6e   �� 5j      $��1��6!   ��5k      �� $ txtLastName��$% (Validation.Errors).CurrentItem�5l      � 5m   
   $��1��6   $��2��6!    5n      �� 5o      $��30 �6    �� 5p      .+�5r      �� $��ת.ז.��6   �� 5s      -   5        $ txtStudentID��5s      $��23��6,   $
 Wrap=�68   $	��120��6l   ��6L   �� $ Model.TZ�6l   �� 5t      $��1��6!   ��5u      �� $ txtStudentID��$% (Validation.Errors).CurrentItem�5v      �� 5w   
   $��2��6   $��2��6%   $ 
Horizontal=�62   .+�5x      �� $��תאריך לידה��6   (  "System.Windows.Controls.DatePicker  5y      -   5        $��DP��5y      $��Center=�6#      SelectedDateFormat$ Short=�6l   $
��0,13q�6�   $	��116��6�      SelectedDate 6?   �� $ Model.BirthDay�6�   5{      � 5|   
   $��1��6   $��3��6     5}      �� 5~      $��30 �6    �� 5      .+�5�      �� $��
כתובת��6   $
��Auto��6$   $��5,5,5,1q�62   �� 5�      -   5        $ 
txtAddress��5�      $	��150��6*   $��
30,10,29,0q�6\   ��68   �� $ Model.Address�6\   �� 5�      $��1��6!   ��5�      �� $ 
txtAddress��$% (Validation.Errors).CurrentItem�5�      �� 5�   
   $��2��6   $��3��6&   $ 
Horizontal=�63   .+�5�      �� $��עיר��6   �� 5�      -   5        $ txtCity��5�      $��23��6'   $
 Wrap=�63   $	��126��6i   $
��5,10q�6u   ��6G   �� $ 
Model.City�6u   5�      �� 5�   
   $��0��6   $��4��6&   $ 
Horizontal=�63   .+�5�      �� $��טלפון בבית��6   �� 5�      -   5        $ 	txtPhone1��5�      $��23��6)   $
 Wrap=�65   $	��126��6m   $
��5,10q�6y   ��6I   �� $ Model.Phone1�6y   5�      �� 5�   
   $��1��6   $��4��6&   $ 
Horizontal=�63   .+�5�      �� $��טלפון אבא��6   �� 5�      -   5        $ 	txtPhone2��5�      $��23��6)   $
 Wrap=�65   $	��126��6m   $
��5,10q�6y   ��6I   �� $ Model.Phone2�6y   5�      �� 5�   
   $��2��6   $��4��6&   $ 
Horizontal=�63   .+�5�      �� $��טלפון אמא��6   �� 5�      -	   5        $ 	txtPhone3��5�      $��23��6)   $
 Wrap=�65   $	��126��6m   $
��5,10q�6y   ��6I   �� $ Model.Phone3�6y   5�      �� 5�   
   $��5��6   $ 
Horizontal=�6$   .+�5�      �� $��שם אבא��6   �� 5�      -
   5        $ txtDad��5�      $��23��6&   $
 Wrap=�62   $	��126��6k   $
��5,10q�6w   ��6F   �� $ Model.DadName�6w   5�      �� 5�   
   $��1��6   $��5��6%   $ 
Horizontal=�62   .+�5�      �� $��שם אמא��6   �� 5�      -   5        $ txtMom��5�      $��23��6&   $
 Wrap=�62   $	��126��6k   $
��5,10q�6w   ��6F   �� $ Model.MomName�6w   5�      �� 5�   
   $��	0,28,0,42q�6   $��2��6(   $��5��69   $��Center=�6F   $��48��6a   $��2��6m   .+�5�      5   /EzerLaMoreh.CustomUser_Controls.OkCancelButtons  5�      5�      5�      