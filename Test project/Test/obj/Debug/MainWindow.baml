   M S B A M L   `   `   `  ����?  ;Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TestTest  5   	       Test.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Test     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� RelativeSource	 �� Path��%�  '��       '�� H     '�� a    �� 5
   
   " ��6   .�5      ��  � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)    5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip 5      ��  �� *Self+$)	 #(Validation.Errors)[0].ErrorContent��� 5       � ��
 �  ��63   5      5      �� 5   
   " ��6   .�5      ��  � ��$ 40��6&   �� 5       � ��$ 5q�6'   5      5      .��5      � 
 � ColumnDefinitions
 5   
   �� 5       $��* �6   �� 5!      $
��0.8* �6    � RowDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $
��0.2* �6   .+�5'   
   �� $��0��6    �� AlternationCount$ 2��5(      ��5'   "   �� *
Students+ �� SelectedItem 5)      �� *SelectedStudent+��5*      �� 5+      " ��6   .�5,      ��  � ��$	 5,3q�6/   �� 5-       � ��$ 5q�60   �� 5.       � ��
 ��İ�63   �� 5/       � �� 50      �� 51       �� 
TargetType" ��6.   .R�52   "   ��  ��Name$	 brd��6)   #��z��66   #��z��53   *   #��z��6V   ._�54   &   �� #��z��67   55   #    �� Triggers 56   "   P� 57   &    �@��AlternationIndex$ 1��6W   . �58   *   ��  � ��
 � ���6G   59   '   P� 5;   &    �@��
IsSelected . . �5<   *   ��  � ��
 �2�2�6G   �� 5=   *    � ��
 �����6G   �� 5>   *    � ��$ 1q�6L   �� 5?   *    � ��
 �   �6H   5@   '   5B      5D      5E      ��5G      �� 5H      .R�5I      �� $��5q�6!   .+�5J      �� ��6$   �� $	 ID��� 5K      2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6D   ��6$   �� $	 	FirstName� �� 6[   ��6e   �� $
	 Last�6�   �� 5L       preserve6>   ��6$   �� $		 Age�	 лет6Y   �� 5M      ��6$   �� $	 Gender�5N      5O      5Q      �� 5R   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5S      �� $��74��64   ��6   �� *
AddCommand+.��6?   Добавить6I   �� 5T      $��78��5U   B   $��Удалить��6M   ��5T      �� *RemoveCommand+��5U      �� *SelectedStudent+6M   �� 5V      $	��132��5W   B   ��5V      �� *SaveCommand+��5W      �� *SelectedStudent+.��6N   Сохранить6Y   5X      �� 5Z   
   $��1��6    � DataContext 6%   �� *SelectedStudent+.+�5[      �� $'��!Выбранный студент��6   �� 5\      $��Имя��6   �� 5]      ��6   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors . �� 5^      $��Фамилия��6   �� 5_      ��6   �� *Last+$ PropertyChanged=� . �� 5`      $��Возраст��6   �� 5a      ��6   �� *Age+$ PropertyChanged=� . �� 5b      $��Пол��6   �� 5c      ��6   �� *Gender+$ PropertyChanged=� . 5d      5e      5f      