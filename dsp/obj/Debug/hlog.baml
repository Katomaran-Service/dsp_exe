   M S B A M L   `   `   `  ����>  :dsp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:dspdsp  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5          dsp.hlog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:dsp     5      V RMaterialDesignThemes.Wpf, Version=2.4.1.1101, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0sys&clr-namespace:System;assembly=mscorlib  5      $
��Auto��5      $
��auto��6     N� Title$
  hlog��5      .��5      � ���	#FFF0EDC4.+�5   
   �� 
�������$��0q�6    �� 5   
   -   5         ��Name$ backbut��5      $�� ��6"   $
��Left=�6-   $��51��6H   $��26,0,0,0q�6T   $	��Top=�6f   $��67��6~   ��6�   Z� ��5      �� 5       �� ImageSource$  arrow-left-bold-circle.png��6   5      �� 5   
   $��Stretch=�6   $��0,51,0,0q�65   ���	#fff0edc4$
��Auto=�6_   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ log_grid��5   +   $��
15,70,0,10q�6      
IsReadOnly .    AutoGenerateColumns .     HeadersVisibility$ Column=�6k    �� SelectedIndex$ -1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 S.NO��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *SNO+   HeaderStyle 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6$   .�5   "   ��  �� Property � �� �� Value$ Center=�6O   �� 5   "    � ��$ 12(�6=   �� 5   "    � ��$
 Bold"�6?   6N   5      5         5!      $	 	USER NAME��6)   $	
 320 6V    6<   �� *UNAME+ 5"      �� 5#      "  6$   .�5$   "   ��  � ��$ Center=�6O   �� 5%   "    � ��$ 12(�6=   �� 5&   "    � ��$
 Bold"�6?   6N   5'      5)        5*      $
	 TIME��6)   $	
 300 6P    67   �� *TIME+ 5+      �� 5,      "  6$   .�5-   "   ��  � ��$ Center=�6O   �� 5.   "    � ��$ 12(�6=   �� 5/   "    � ��$
 Bold"�6?   6N   50      52        53      $	 CATEGORY��6)   $	
 400 6X    6;   �� *
CATEGORY+ 54      �� 55      "  6$   .�56   "   ��  � ��$ Center=�6O   �� 57   "    � ��$ 12(�6=   �� 58   "    � ��$
 Bold"�6?   6N   59      5;        5<      $	 REMARK��6)   $	
 400 6T    69   �� *REMARK+ 5=      �� 5>      "  6$   .�5?   "   ��  � ��$ Center=�6O   �� 5@   "    � ��$ 12(�6=   �� 5A   "    � ��$
 Bold"�6?   6N   5B      5D      5F      5G      (� 5H   
    (� Stretch$ Uniform=�6   $��
700,10,0,0q�6$   $	��Top=�68   $
��Left=�6P   $��31��6k   $	��300��6w   .��5I      �� -   5         ��Name$ textBlock123��5I       �� TextAlignment$ Center=�6/   $
��Wrap=�6F   $�� ��6Z   $
��Bold"�6b   $
��Auto��6u   $��20(�6�   5J      2  ,MaterialDesignThemes.Wpf.MaterialDateDisplay  5K   
   $��Right=�6-   $	��160��6I   $��64��6U   $	��Top=�6a   $��	0,51,41,0q�6y   5L      5M      