   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   RowMenu  � DataContext �� RelativeSource m� Command  DefaultRowStyle �� 
TargetType)    #System.Windows.Controls.DataGridRow �� Property �� Value=   7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType ��Name �� Padding	 �� 
StartPoint
 �� EndPoint � Offset � Color J� SnapsToDevicePixels'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value?   9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?   9System.Windows.Controls.Primitives.DataGridCellsPresenter    
ItemsPanelA   ;System.Windows.Controls.Primitives.DataGridDetailsPresenter    DetailsVisibility$   SelectiveScrollingOrientation;	   5System.Windows.Controls.SelectiveScrollingOrientation 	  Vertical �� ConverterParameter&
    System.Windows.Controls.DataGrid# 
  RowDetailsScrollingConverter �� 	Converter �� AncestorType:   4System.Windows.Controls.Primitives.DataGridRowHeader7   1System.Windows.Controls.DataGridHeadersVisibility
   Row!  
  HeadersVisibilityConverter*   $System.Windows.Controls.DataGridCell�� 5      J 9http://schemas.microsoft.com/winfx/2006/xaml/presentation        :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %h  &	        &	 �     7   '      '   q    '  �    �� 5        6#   �� *PlacementTarget.DataContext+ �� *Self+.@�5   
   m� $$��הפוך לברירת מחדל��6    6-   �� *MakeDefaultCommand+5      �� 5      "   6$   .�5   
   ��  �@�ContextMenu8   6(   5      �� 5
      "  6   .�5   
   ��  � ��$ Center=�65   �� 5   
    � ��$ 35��6#   �� 5   
    �@ SeparatorBrush
 �  ��6+   �� 5   
    � ��$ Black"�6'   �� 5   
    � �� �	#FFD7ECFB6'   �� 5   
    � ��$ Center=�68   �� 5   
    � �� 5      �� 5      "  6"   .R�5      � .+�5      �� $ columnHeaderBorder��6"   $��1q�6>   $ 3,0,3,0q�6R   ��5      �� 5   "   $	 0.5,0&�66   $
 0.5,1&�6I   .��5   &   � $ 0Q�63   $ #A5A5A5��6>   � 5   &   $ 1Q�63   $ #4B4B4B��6>   5   #   ��5      �� 5   "   $	 0.5,0&�66   $
 0.5,1&�6I   .��5   &   � $ 0Q�63   $ 	#FF095BCF��6>   � 5   &   $ 1Q�63   $ 	#FF2E1585��6>   5    #   ._�5"      �� #��z��6/   #��z��5#   	   # z 5$      5%      5&      5'      5)      5*      �� 5,      "   6   .�5-   
   ��  � ��
 �����6'   �� 5.   
    �@J�SnapsToDevicePixels . 60   �� 5/   
    �@=�ErrorTemplate 65   Z� �� 50   
    � ��$ 35��6#   �� 51   
    �@  ValidationErrorTemplate 52      �� 53      .R�54      �� $��2,0,0,0q�6    $��Center=�55      
���  ��$��!��57      58      5:      �� 5;   
    � �� 5<      �� 5=      "   6"   .R�5>      �� $ 
DGR_Border��6   #��z��5?      #��z��5@       . ��5B      �� 5C      $	 0.5,0&�62   $
 0.5,1&�6E   .��5D   "   � $ 0Q�6/   $ 	#AAAAB9FF��6:   � 5E   "   $ 1Q�6/   $ 	#AAA3DEF9��6:   5F       5H        5I      CommonStates��. 5J   "     
Normal��6.     5K   "   Normal_AlternatingRow��. 5L   &   �� .��5M   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5N   .     $ 0��6B   $ 	#AAF0C570��6N   5O   +   �� 5P   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5Q   .     $ 0��6B   $ 	#AAFF7F00��6N   5R   +   5S   '   5T   #     5U   "   Normal_Selected��. 5V   &   �� .��5W   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5X   .     $ 0��6B   $ 	#CCAA0000��6N   5Y   +   �� 5Z   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5[   .     $ 0��6B   $ 	#77D52B00��6N   5\   +   5]   '   5^   #     5_   "   	MouseOver��. 5`   &   �� .��5a   *   �� $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�6j   .g�5b   .     $ 0��6B   $ 	#AAEA9595��6N   5c   +   �� 5d   *   $ 
DGR_Border��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6j   .g�5e   .     $ 0��6B   $ 	#AAF54B4B��6N   5f   +   5g   '   5h   #   5i      ._�5k         5l      �� 5m   "   $
��Auto �63   �� 5n   "   $��* �63    5p      �� 5q   "   $��* �60   �� 5r   "   $
��Auto �60   .+�5t        $��1��65   #��z 5u       # z 5v         5w      $��1��67   $��1��5x   "   #y�z 5}   "    5y   "   �� *AreRowDetailsFrozen+# Z # Z  �� " 
 5}   "     5~      $��2��60   $ Vertical=�5      y�5�      �� *HeadersVisibility+# Z # Z   �� " 
 5�      5�      5�      5�      5�      �� 5�      "  6   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ border��6   
������ 
������ $��1q�5�       . $��Center=�5�   )   $��Center=�6F    5�        5�      FocusStates��. 5�   "     	Unfocused��6.     5�   "   Focused��6.   5�        5�      CurrentStates��. 5�   "     Regular��6.     5�   "   Current��. 5�   &   �� .��5�   *   �� $ border��6G   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6f   .g�5�   .     $ 0��6B   $
 Gray��6N   5�   +   5�   '   5�   #   5�      ._�5�      �� # z 6+   5�      5�      5�      5�      5�      