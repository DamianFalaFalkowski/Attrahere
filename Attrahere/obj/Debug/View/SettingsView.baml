   M S B A M L   `   `   `  ����D  @Attrahere, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Attrahere.Controls.ColorPickerAttrahere.Controls.ColorPicker  5      /clr-namespace:Attrahere.ViewAttrahere.View  5      !    Attrahere.View.SettingsView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;cp,clr-namespace:Attrahere.Controls.ColorPicker     5      .localclr-namespace:Attrahere.View     5      -   5          >�Name$
  self��5       � 	Resources 5	       �� 
TargetType �� Property �� Value��%W   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 0,0,0,5q�6'   5      5      .��5      �� ��6   ��  �� ElementName$
 self�� �� Path$ HorizontalAlignment���5      �� $
 self��$ VerticalAlignment�.+�5   
   �� $��Radius - double at (0,2]��6   �� 5   
   ��6   �� $ Radius� �� Mode$ TwoWay=��� 5   
   $%��Max Iteration - uint at [1,inf]��6   �� 5   
   ��6   �� $ MaximumIteration�$ TwoWay=��� 5   
   $!��Image Size - double (0,inf]��6   �� 5   
   ��6   �� $ ImageRealisticHeight�$ TwoWay=��� 5   
   $��DPI - double at (0,inf]��6   �� 5   
   ��6   �� $	 Dpi�$ TwoWay=��� 5   
   $!��Center X - double at [-2,2]��6   �� 5   
   ��6   �� $ CenterAtXAxis�$ TwoWay=��� 5   
   $!��Center Y - double at [-2,2]��6   �� 5   
   ��6   �� $ CenterAtYAxis�$ TwoWay=�� 5   
    � ColumnDefinitions 5      �� 5       $��* �6#   �� 5!      $��* �6#   .+�5#      �� -   5        $
��Undo��5#      {�5$      �� $ IsUndoAvalible�5%      �� 5&      -   5        $��1��5&      $
��Redo��6%   {�5'      �� $ IsRedoAvalible�5(      5)      �� 5+   
   -   5        $��Zoom(x0.25)��5+      ���	#FFAFD7EA6>   �� 5,   
   -   5        $��
Zoom(x0.5)��5,      ���	#FFAFD7EA6<   �� 5-   
   -   5        $��Zoom(x2)��5-      ���	#FFFB9E8A69   �� 5.   
   -   5        $��Zoom(x4)��5.      ���	#FFFB9E8A69   �� 5/   
   -   5        $��Generate��5/      ���	#FF78DA9C6;   �� 50   
   -	   5        $��Generate with saving��50      ���	#FF78DA9C51   2   �� 53   
   $��20��6   $��Stretch=�6    �� 55   
   $��Colors:��6   �� 56   
   }�. |�.  	 �� IsTextSearchEnabled	 .  $��Disabled=�58      $��Stretch=�59      ��.  #��� ��5=      ��56      �� $ 
ColorsList���5;      �� $ OneWay=���5<      �� $ OneWay=���5>      �� 5?      .R�5@      0   *Attrahere.Controls.ColorPicker.ColorPicker  
   R
 6%   �� $ R�   G 5A   %   �� $ G�   B 5B   %   �� $ B�5C      5E      � 5F   
    5G      �� 5H      $��* �6#   �� 5I      $��* �6#   .+�5K      �� -
   5        $��-��5K   6   �� 5L      -   5        $��+��5L   3   $��1��6?   5M      �� 5O   
   $��20��6   $��Stretch=�6    �� 5Q   
   $��Start Possition��6   {�.  6+   �� 5R   
   $��Show Actual center��6   {�.  60   �� 5T   
   $��20��6   $��Stretch=�6    5V      5W      