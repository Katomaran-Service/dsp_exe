   M S B A M L   `   `   `  ����>  :dsp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:dspdsp  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          dsp.clean_room   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:dsp     5      6sys&clr-namespace:System;assembly=mscorlib     5      $
��Auto��5
      $
��auto��6     N� Title$  
clean_room��5       � 	Resources 5       
  BLOCKR �� 
TargetType �� RadiusY �� RadiusX ��Name��%�   &	        �� 5   
   " ��6)   .R�5      � .+�5      �� 
���   �$ 37.034��6)   $ 37.034��6:   
���   �6K   �� 5      $ label��6   $��CLEANED��6'   $��
33,8,27,10q�69   
�������$��20(�6`   5      5      5      .��5      � ���	#FFF0EDC4.+�5   
   �� 
�������$��0q�6    �� 5   
   -   5         ��Name$ backbut��5      $�� ��6"   $
��Left=�6-   $��51��6H   $��26,0,0,0q�6T   $	��Top=�6f   $��67��6~   ��6�   Z� ��5      �� 5       �� ImageSource$  arrow-left-bold-circle.png��6   5      (� 5   
    (� Stretch$ Uniform=�6   $��
692,10,0,0q�6$   $	��Top=�68   $
��Left=�6P   $��31��6k   $	��160��6w   .��5      �� -   5        	 ��Name$	 textBlock123��5      
 �� TextAlignment$
 Center=�6/   $
��Wrap=�6F   $��ROOM CLEANING��6Z   $
��Bold"�6o   $
��Auto��6�   $��20(�6�   5      �� 5   
   $��Stretch=�6   $��0,51,0,0q�65   ���	#fff0edc4$
��Auto=�6_   .��5      � ���	#fff0edc4$��0,0,0,0q�6*   $
��1450��6<   $
��Auto��6L   $
��Auto��6Z   .+�5       �� -   5         ��Name$ rtype��5       $
��Left=�6*   $��45��6E   $	��Top=�6Q   $	��301��6i   $��
350,60,0,0q�6u   $��20(�6�   �� 5!      -   5        $	 	textBlock��5!      $
��Left=�6/   $��25(�6J   $
 Right=�6X   $��45��6n   $��
150,60,0,0q�6z   $
��Wrap=�6�   $��ROOM NO:��6�   $	��Top=�6�   $	��135��6�   $
��Bold"�6�   �� 5"      -   5         ��Name$ release_remark��5"      $
��Left=�62   $��55��6M   $��350,320,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��301��6�   $��20(�6�   �� 5#      -   5        $ room_no��5#      $
��Left=�6,   $��45��6G   $	��Top=�6S   $	��150��6k   $��350,170,0,0q�6w   $��20(�6�   �� 5$      -   5        $	 textBlock_Copy��5$      $
��Left=�64   $��25(�6O   $
 Right=�6]   $��45��6s   $��904,147,0,0q�6   $
��Wrap=�6�   $
��TIME��6�   $	��Top=�6�   $	��135��6�   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  5%      -   5          Name$ releasedate��5%      $
��Left=�62   $��45��6M   $��1085,60,0,0q�6Y   $	��Top=�6n   $	��225��6�   
 �� Now   DisplayDateStart# Z 6�      SelectedDate# Z 6�      SelectedDateFormat$ Short=�6�   $��20(�6  {�.  6  �� 5&      -	   5        $ release_time��5&      $
��Left=�61   $��45��6L   $	��Top=�6X   $	��150��6p   $��1085,147,0,0q�6|   $��20(�6�   �� 5'      -
   5        $	 textBlock_Copy2��5'      $
��Left=�65   $��25(�6P   $
 Right=�6^   $��45��6t   $��
837,59,0,0q�6�   $
��Wrap=�6�   $��CLEANED DATE��6�   $	��Top=�6�   $	��202��6�   $
��Bold"�6�   �� 5(      -   5        $	 textBlock_Copy4��5(      $
��Left=�65   $��25(�6P   $
 Right=�6^   $��45��6t   $��150,330,0,0q�6�   $
��Wrap=�6�   $��REMARK:��6�   $	��Top=�6�   $	��135��6�   $
��Bold"�6�   �� 5)      -   5        $ release_but��5)      $��Button��6.   $
��Left=�6?   $��65��6Z   $��708,491,0,0q�6f   $	��Top=�6{   $	��164��6�   #���   6�   6�   5+      5,      5-      5.      