   M S B A M L   `   `   `  ����N  JModernGUI_Surveilia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullg8clr-namespace:ModernGUI_Surveilia.UserContent.Components*ModernGUI_Surveilia.UserContent.Components  5   	   g8clr-namespace:ModernGUI_Surveilia.UserContent.ViewModels*ModernGUI_Surveilia.UserContent.ViewModels  5   	   8    2ModernGUI_Surveilia.UserContent.Components.MenuBar   5
      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Jlocal8clr-namespace:ModernGUI_Surveilia.UserContent.Components     5   	   O
viewmodels8clr-namespace:ModernGUI_Surveilia.UserContent.ViewModels     5   	   ���#140915$	��450��5   	   $	��800��6     � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value    BooleanToVisibilityConverter��%�  '��       &	  �    �� 5   
   " ��6   .�5      ��  � �� �#1409156+   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   
���   �$��1q�6_   ._�5       �� $��Center=�6/   $��Center=�6L   5!      5"      5$       5%      P� 5&       �@J�IsMouseOver$
 True��61   . �5'      ��  � �� �#27259063   5(      5*      �� 5+   
   6'   5,      .��5.      �  � RowDefinitions 5/   
   �� 50      �� 51      $	��415 �6   	 � ColumnDefinitions	 54   
   �� 55      $	��130 �6   �� 56      $	��653 �6   .+�59   
   � ���#0F0F2D$��2��6$   $��	0,0,-17,0q�68    5:      �� 5;      $��35 �6    �� 5<      $
��Auto �6    	 5>      �� 5?      $	��130 �6#   �� 5@      $��93 �6#   �� 5A      $	��100 �6#   �� 5B      $	��100 �6#   �� 5C      $	��333 �6#   �� 5D      $��27 �6#   .+�5J      �� $��	SURVEILIA��6   
�������$��Center=�6A   $��Center=�6\   $��20(�5K      $��Copperplate Gothic Bold)�6"   $��22��6G   $	��124��6S   �� 5L      -   5        
 ��Name$

 Menu��5L      $
��Home��6#   $��18(�62   
�������$��1��6W   $��Center=�6g   ���#0F0F2D$��Center=�5M   *   $��Copperplate Gothic Bold)�6G   $��22��6l   $��56��6x    � ToolTip$
 Menu��6�   ��6�   �� *NavigateMenuCommand+�� 5N      -   5        $
 Stats��5N      $��Stats��6$   $��18(�64   
�������$��2��6Y   $��Center=�6i   ���#0F0F2D$
��Left=�5O   *   $��Copperplate Gothic Bold)�6E   $��22��6j   $��21,0,0,0q�6v   $��61��6�   $ Stats��6�   ��6�   �� *NavigateStatsCommand+�� 5P      -   5        $

 Help��5P      $
��Help��6#   $��18(�62   
�������$��3��6W   $��Center=�6g   ���#0F0F2D$
��Left=�5Q   *   $��Copperplate Gothic Bold)�6E   $��22��6j   $��25,0,0,0q�6v   $��53��6�   $
 Help��6�   ��6�   �� *NavigateHelpCommand+�� 5R      -   5        $
 Minimize��5R      $
��Left=�6'   $��Center=�6B   $��_��6]   
�������$��4��5S   ,   $��14(�6S   $��23��6a   $��23��6l   $��	300,0,0,0q�6x   �� 5T      -   5        $

 Exit��5T      $
��Left=�6#   $��Center=�6>   $��X��6Y   
�������$��5��5U   ,   $��14(�6O   $��23��6]   $��22��6h   5V      �� 5\   
   $��0,0,0,0q�6   ���#0F093D$��1��6;   .+�5]      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5^      �� -   5        $
 UserBTN��5^      $��90��6*   $��90��66   $ Edit User Settings��6A   $��0,20,0,0q�6�   ��6^   �� *NavigateUserMenuCommand+��5_      �� 5`       �� ImageSource$+ %/UserContent/Components/Surveilia.jpg��6%     5b      ��%_   '��       �� 5c      " ��6    .�5d      ��  �@��CornerRadius$ 10��6=   5e      5f      5g      5h      �� 5i      $ 
Horizontal=�6   $��5,0,5,5q�62   $��Center=�6C   �� 5j      -   5        $��NameTextBlock��5j      $	��110��6)   $��28��68   $	��115��6G   $��30��6V   $��Center=�6e   $��Center=�6�   ���#0F293D$��Copperplate Gothic Bold)�6�   $��0,7,0,0q�6�   $	��115��6�   $��30��6�   $��0,20,0,0q�6  
�������$
��Name��5k   -   $��Center=�6<     5l      ��%_   '��       �� 5m      " ��6    .�5n      ��  �@��CornerRadius$ 10��6=   5o      5p      5q      �� 5r      -   5        $��lblTime��5r      $��Center=�6'   $��0,25,0,0q�6D   $	��115��6V   $��30��6b   $��14(�6n   
����������#0F293D$��Center=�5s        5t      ��%_   '��       �� 5u      " ��6   .�5v      ��  �@��CornerRadius$ 10��69   5w      5x      5y      �� 5{      -	   5        $
 ScreenshotButton��5{      $��Center=�6/   $��0,25,0,0q�6L   $	��100��6^   $��60��6j    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��1,1,1,1q�6�   z�5|      V� 5}      .~�5~      �� �� 5       �� AngleX$ 0Q�6(   �� 5�      T� 5�      5�      ��5�      �� 5�      $( "/UserContent/Components/camera.jpg��6!     5�      ��%_   '��       �� 5�      " ��6   .�5�      ��  �@��CornerRadius$ 15��69   5�      5�      5�      5�      5�      5�      