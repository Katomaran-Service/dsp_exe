   M S B A M L   `   `   `  ����>  :dsp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:dspdsp  5          dsp.entry_store_pg   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:dsp     5      $
��Auto��5	      $
��auto��6     N� Title$  entry_store_pg��5
       � 	Resources 5         i �� 
TargetType �� RadiusY �� RadiusX ��Name��%�   &	        �� 5   
   " ��6$   .R�5      � .+�5      �� 
���   �$ 37.034��6)   $ 37.034��6:   
���   �6K   �� 5      $ label��6   $��ENTRY��6'   $��
40,8,20,10q�67   
�������$��15(�6^   5      5      5      .��5      � ���	#FFF0EDC4.+�5   
   �� 
�������$��0q�6    �� 5   
   -   5         ��Name$ backbut��5      $�� ��6"   $
��Left=�6-   $��51��6H   $��26,0,0,0q�6T   $	��Top=�6f   $��67��6~   ��6�   Z� ��5      �� 5       �� ImageSource$  arrow-left-bold-circle.png��6   5      �� 5   
   $��Stretch=�6   $��0,51,0,0q�65   ���	#fff0edc4$
��Auto=�6_   .��5      � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ inventory_table��5   /   $��
15,70,0,10q�6   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     HeadersVisibility$ Column=�6v    �� SelectedIndex$ -1��6�      Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$
 S.NO��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *SNO+   HeaderStyle 5"      �� 5#   "    �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6(   .�5$   &   ��  �� Property � �� �� Value$ Center=�6S   �� 5%   &    � ��$ 12(�6A   �� 5&   &    � ��$
 Bold"�6C   6R   5'   #   5)        5*      $ ITEMS (UNIT)��6-   $	 350 6\    6C   �� *ITEM+ 5+      �� 5,   "   "  6(   .�5-   &   ��  � ��$ Center=�6S   �� 5.   &    � ��$ 12(�6A   �� 5/   &    � ��$
 Bold"�6C   6R   50   #   52        53      $ CURRENT��6-   $	 250 6Z    6>   �� *	CURRENT+ 54      �� 55   "   "  6(   .�56   &   ��  � ��$ Center=�6S   �� 57   &    � ��$ 12(�6A   �� 58   &    � ��$
 Bold"�6C   6R   59   #   5;        5<      $ 	THRESHOLD��6-   $	 250 6^    6@   �� *	THRESHOLD+ 5=      �� 5>   "   "  6(   .�5?   &   ��  � ��$ Center=�6S   �� 5@   &    � ��$ 12(�6A   �� 5A   &    � ��$
 Bold"�6C   6R   5B   #   5D        5E      $ STATUS��6-   $	 400 6X    6=   �� *STATUS+ 5F      �� 5G   "   "  6(   .�5H   &   ��  � ��$ Center=�6S   �� 5I   &    � ��$ 12(�6A   �� 5J   &    � ��$
 Bold"�6C   6R   5K   #   5M      4  .System.Windows.Controls.DataGridTemplateColumn  5N      $ QUANTITY��61      CanUserResize .  $	 200 6Y      
IsReadOnly .  5O      �� 5P   "   "  6(   .�5Q   &   ��  � ��$ Center=�6S   �� 5R   &    � ��$ 12(�6A   �� 5S   &    � ��$
 Bold"�6C   6R   5T   #      CellTemplate 5V      �� 5W   "   .R�5X   &   ��  ��Name$
 qtxt��6.   -   5        ��5X   [   �� *
QUANTITY+5Y   #   5[      5]      �� 5^      -   5        $ 	searchbox��5^      $
��Left=�6-   $��38��6H   $��	15,27,0,0q�6T    �� TextWrapping$
 Wrap=�6g   $��Search��6{   $	��Top=�6�   $	��234��6�   $��Italic$�6�   $��15(�6�   6�   �� 5_      -   5        $ 	issue_but��5_      $��Button��6,   $
��Left=�6=   $��55��6X   $��1371,10,0,0q�6d   $	��Top=�6y   $	��133��6�   #���   6�   6�   5`      5a      (� 5b   
    (� Stretch$ Uniform=�6   $��
700,10,0,0q�6$   $	��Top=�68   $
��Left=�6P   $��31��6k   $	��120��6w   .��5c      �� -   5         ��Name$ textBlock123��5c       �� TextAlignment$ Center=�6/   $
��Wrap=�6F   $��ENTRY��6Z   $
��Bold"�6g   $
��Auto��6z   $��20(�6�   5d      5e      5f      