   M S B A M L   `   `   `  ����A  =Prac02, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Prac02Prac02  5   	       Prac02.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _MaterialDesignThemes.MahApps, Version=0.2.2.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   "localclr-namespace:Prac02   5   	   -   5          �Name$  MW��5   	   $	��450��5      $	��800��6'    � 
ResizeMode$ NoResize=�63    � SizeToContent$ Manual=�6I    � WindowStartupLocation$ CenterScreen=�6`    � WindowStyle$
 None=�6�   .��5	      � .+�5
   
   � -   5         �Name$ MainGrid��5
      $��0,25,0,0q�6!    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      .+�5      �� -   5         ��Name$ ControlBorder��5      $��1��6,    �� CornerRadius$ 	15,0,0,15��6<   ���	#FFEEEEEE	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   Opacity$	
 0.4Q�6'      
BlurRadius$ 15Q�65      ShadowDepth$ 1Q�6E   ._�5      ��  �� Left$	 322��6   
 �� Top$	 276��6*   $��
0,212,0,19q�6;   $+��%/c23e78db1e71d000a43b0c9b0df2dccb.png��6O   $��UniformToFill=�6   $��1��6�   	 5        5      $
 1Q�6+   $ 25Q�67   $ 1Q�6G   5      5      �� 5      -   5         ��Name$ 	WhatPunkt��5      $��Stretch=�6*   $��
5,39,0,353q�6F   $��Bahnschrift)�6Z   $��16(�6�   $��1��6�   .@�5      �� $��5��6   �� 5      $��10��6   �� 5      $��20��6   �� 5      $��50��6   �� 5       $	��100��6   �� 5!      $	��200��6   �� 5"      $	��500��6   5#      �� 5$      -   5        $ 	WhatSpeed��5$       �� SelectedIndex$ 0��6*   $��Bahnschrift)�6j   $��16(�6�   $��
5,106,-1,0q�6�   $	��Top=�6�   $��1��6�   $��32��6�   .@�5%      �� $
��1000��6   �� 5&      $	��500��6   �� 5'      $	��200��6   �� 5(      $	��100��6   �� 5)      $��50��6   �� 5*      $��10��6   �� 5+      $��5��6   �� 5,      $��1��6   5-      �� 5.      -   5         �� BitmapScalingMode$ HighQuality=�5.      $��Button��6C   $
��Left=�6T   $��167,156,0,0q�6o   $	��Top=�6�   $��23��6�   $��1��6�    J� RenderTransformOrigin$ 0.583,0.208&�6�   $��23��6
  ��6�   Z� ��5/      �� 50       �� ImageSource$ /Фон2.png��6!   $ HighQuality=�69    j� Stretch$
 Fill=�6g   52      �� 53      $'��!КІЛЬКІСТЬ ПУНКТІВ��6   $��40,15,40,386q�60   $��Bahnschrift Condensed)�6F   $��18(�6i   $��1��6w   �� 55      -   5         ��Name$ 
GridToDraw��55      $��0��6)   59      	� 5:      -   5         	�Name$ 	GenButton��5:      $+��%Генетичний алгоритм��6-   $
��Left=�6K   $��
10,147,0,0q�6f   $	��Top=�6z   $��1��6�   $��Bahnschrift)�6�   	� 5;      -	   5        $ GreedButton��5;      $'��!Жадібний алгоритм��6/   $
��Left=�6K   $��
10,169,0,0q�6f   $	��Top=�6z   $��1��6�   $��Bahnschrift)�6�   �� 5<      $!��ШВИДКІСТЬ, У МС��6   $��44,77,44,319q�6.   $��Bahnschrift Condensed)�6D   $��18(�6g   $��1��6u   5=      � 5>   
   -
   5        $ ToolBar��5>   3   $��25��6   $	��Top=�6   .+�5?      �� -   5        
����p��$��25��5?   0   $	��Top=�6<   $ 0,0,5,5��6T   	 5@        5A      $	
 0.5Q�6'   $ 15Q�65   $ 1Q�6E   5C      �� 5E      -   5         ��Name$ CloseBtn��5E      $��18��6'   $��18��63   $ HighQuality=�6>   $��Center=�6m   $
��Left=�6�   $��	770,0,0,0q�6�   ��6�   Z� ��6�   Z� ��5F      �� 5G      $ /close1.png��6!   5I      �� 5J      -   5        $ MinBtn��5J      $��18��6%   $��18��61   $ HighQuality=�6<   $��Center=�6k   $
��Left=�6�   $��	745,0,0,0q�6�   ��6�   Z� ��6�   Z� ��5K      �� 5L      $ 	/min1.png��6!   5N      5O      5Q      5T      