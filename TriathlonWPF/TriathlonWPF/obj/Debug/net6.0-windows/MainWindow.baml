   M S B A M L   `   `   `  ����G  CTriathlonWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TriathlonWPFTriathlonWPF  5   	       TriathlonWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,localclr-namespace:TriathlonWPF     5   	     � Title$  TriathlonWPF��5   	   $	��450��6   $	��800��6+    � 	Resources 5         DarkBackgroundColor  DarkForegroundColor  DarkControlBackgroundColor  DarkControlForegroundColor  DarkBackgroundBrush �� Color  DarkForegroundBrush  DarkControlBackgroundBrush  DarkControlForegroundBrush �� 
TargetType �� Property �� Value��%�  &	        &	      &	 >     &	 ]     &	 |     7   &	 �     7  &	 �     7  &	 �     7  '�� �     7  7  ��5	   
   #222222��65   ��5
   
   #FFFFFF��65   ��5   
   #333333��6<   ��5   
   #b09796��6<   �� 5   
   8   66   �� 5   
   8   66   �� 5   
   8   6=   �� 5   
   8   6=   �� 5   
   " ��6   .�5      ��  � ��8   6+   �� 5       � ��8  6+   5      5      .��5      � #��[ 6   .+�5   
   �� .@�5      �� $	��Add��6   ���#858181���#2e2222.��5      � ���#474747 � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5       $
��Auto �6(   �� 5!      $
��Auto �6(    � ColumnDefinitions 5#      �� 5$      $
��Auto �6+   �� 5%      $��* �6+   .+�5(      �� $��0��6   $��0��6)   $��
Team Name:��69   #��[ 6N   �� 5)      -   5         ��Name$ TeamNameTextBox��5)   ;   $��0��6   $��1��6+   $��3q�6T   #��[ 6_   #��[ 6�   �� 5*      $��1��6   $��0��6)   $��	Laufzeit:��69   #��[ 6M   �� 5+      -   5        $ LaufzeitTextBox��5+   ;   $��1��6   $��1��6+   $��3q�6T   #��[ 6_   #��[ 6�   �� 5,      $��2��6   $��0��6)   $��Schwimmzeit:��69   #��[ 6P   �� 5-      -   5        $ SchwimmzeitTextBox��5-   ;   $��2��6   $��1��6+   $��3q�6W   #��[ 6b   #��[ 6�   �� 5.      $��3��6   $��0��6)   $��Radzeit:��69   #��[ 6L   �� 5/      -   5        $ RadzeitTextBox��5/   ;   $��3��6   $��1��6+   $��3q�6S   #��[ 6^   #��[ 6�   �� 50      -   5        	 ��Name$	 SubmitButton��50   :   $��4��6   $��1��6*   $��Submit��6P   $��3q�6v   ���#6e6262���#bfa4a46�   �� 51      -   5        
 ��Name$
 	InputList��51   ?   $��5��6   $��2��6+   #��[ 6R   �� 52      -   5         ��Name$ UpdateSuccessTextBlock��52       $$��Team Data updated successfully��6@   $y�	Collapsed=�6f   
��� � �$
��Bold"�6�   $��5q�6�   54      55      �� 57      $
��Load��6   ���#858181���#2e2222.��58      � ���#474747 5:      �� 5;      $
��Auto �6(   �� 5<      $
��Auto �6(    5@      �� 5A      $
��Auto �6+   �� 5B      $��* �6+   .+�5E      �� $��Load tab content goes��6   �� 5F      -   5        $	 LoadList��5F   >   $��0��6   $��2��6*   $��Load all Teams��6P   $��3q�6�   ���#6e6262���#bfa4a46�   �� 5G      -	   5        $
 FullList��5G   ?   $��1��6   $��2��6+   ���#474747#��[ 6f   5H      5I      �� 5J      $��Update��6   ���#858181���#2e2222.��5K      � ���#474747 5L      �� 5M      $
��Auto �6(   �� 5N      $
��Auto �6(   �� 5O      $
��Auto �6(   �� 5P      $
��Auto �6(   �� 5Q      $
��Auto �6(   �� 5R      $
��Auto �6(   �� 5S      $
��Auto �6(    5U      �� 5V      $
��Auto �6+   �� 5W      $��* �6+   .+�5Y      �� $��0��6   $��0��6)   $��Select Team:��69   #��[ 6P   �� 5Z      -
   5         ��Name$ TeamComboBox��5Z   <   $��0��6   $��1��6,   $��3q�6R   #��[ 6]   #��[ 6�   6�   �� 5[      $��1��6   $��0��6)   $��
Team Name:��69   #��[ 6N   �� 5\      -   5        $ UpdateTeamNameTextBox��5\   ;   $��1��6   $��1��6+   $��3q�6Z   #��[ 6e   #��[ 6�   �� 5]      $��2��6   $��0��6)   $��	Laufzeit:��69   #��[ 6M   �� 5^      -   5        $ UpdateLaufzeitTextBox��5^   ;   $��2��6   $��1��6+   $��3q�6Z   #��[ 6e   #��[ 6�   �� 5_      $��3��6   $��0��6)   $��Schwimmzeit:��69   #��[ 6P   �� 5`      -   5        $ UpdateSchwimmzeitTextBox��5`   ;   $��3��6   $��1��6+   $��3q�6]   #��[ 6h   #��[ 6�   �� 5a      $��4��6   $��0��6)   $��Radzeit:��69   #��[ 6L   �� 5b      -   5        $ UpdateRadzeitTextBox��5b   ;   $��4��6   $��1��6+   $��3q�6Y   #��[ 6d   #��[ 6�   �� 5c      -   5        $	 UpdateButton��5c   :   $��5��6   $��1��6*   $��Update��6P   $��3q�6|   ���#6e6262���#bfa4a46�   �� 5d      -   5        $# UpdateSuccessMessageTextBlock��5d   =   $��7��6    $��1��6-   $$��Team Data updated successfully��6d   $y�	Collapsed=�6�   
��� � �$
��Bold"�6�   $��5q�6�   5e      5g      �� 5h      $��Delete��6   ���#858181���#2e2222.��5i      � ���#474747 5j      �� 5k      $
��Auto �6(   �� 5l      $
��Auto �6(   �� 5m      $
��Auto �6(    5o      �� 5p      $
��Auto �6+   �� 5q      $��* �6+   .+�5s      �� $��0��6   $��0��6)   $��Select Team:��69   #��[ 6P   �� 5t      -   5        $ DeleteTeamComboBox��5t   <   $��0��6   $��1��6,   $��3q�6X   #��[ 6c   #��[ 6�   �� 5u      -   5        $	 DeleteButton��5u   >   $��1��6   $��2��6*   $��Delete Team��6T   $��3q�6�   ���#6e6262���#bfa4a46�   �� 5v      -   5        $# DeleteSuccessMessageTextBlock��5v   A   $��4��6    $��2��6-   $��Team deleted successfully��6h   $y�	Collapsed=�6�   
��� � �$
��Bold"�6�   $��5q�6�   5w      5x      5z      5{      5|      