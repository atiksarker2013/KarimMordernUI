   M S B A M L   `   `   `  ����   DarussalamModernUI'    !DarussalamModernUI.UpdateBookInfo   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � Title$  Update Book Information��$��1332.974��$��732.117��   BlankWindow#��[   � WindowStartupLocation$ CenterScreen=�.���� .���� .+��  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��* ��� $��20 ��� $��* ��� $��20 ��� $	��400 �.+�� $��2��$��0��$��4�� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+��� $��0��$��0��  Heading2#��[ $��Book Search  �� �� TextAlignment$ Right=��� -   $��searchTextBox��$��0��$��1���� $��0��$��3�� �� Orientation$ 
Horizontal=�.+��� -   $��updateBookButton��$��Update  ���� -   $��closeButton��$��CLOSE��� $��4��$��10��$��0��$��4��.+�&   System.Windows.Controls.DataGrid  -   $��bookGrid��   CanUserReorderColumns .    CanUserResizeColumns .    CanUserResizeRows .  	   CanUserSortColumns	 . 
   
IsReadOnly
 . $��
0,0,0,-228q�$	��628��$	��Top=� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%1   '        �� "  .���  � ��$ Center=�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 520    Header$ Title��   CellTemplate �� .R���  ��Name$ 
brdBroder1��$��1q�$��Stretch=�._���  ��Name$ textBox1��$	��510��$	��3,1q�����  �� Path$ Title� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� Triggers ��  �� Value$ 0�� �� Binding �� *RemainLeave+.a���  �� 
TargetName$ 
brdBroder1�� � ��
 � � ��� $ textBox1�� � ��
 �����  $	 250 $ Writer�� �� .R��� $ 
brdBroder2��$��1q�$��Stretch=�._��� $ textBox2��$	��200��$	��3,1q����� $ Writer�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *Writer+.a��� $ 
brdBroder2�� � ��
 � � ��� $ textBox2�� � ��
 �����  $	 200 $ 	Publisher�� �� .R��� $ 
brdBroder3��$��1q�$��Stretch=�._��� $ textBox3��$	��190��$	��3,1q����� $ 	Publisher�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	Publisher+.a��� $ 
brdBroder3�� � ��
 � � ��� $ textBox3�� � ��
 �����  $	 100 $ Price�� �� .R��� $ 
brdBroder4��$��1q�$��Stretch=�._��� $ textBox4��$��90��$	��3,1q����� $ Price�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *Price+.a��� $ 
brdBroder4�� � ��
 � � ��� $ textBox4�� � ��
 �  ��  $	 100 $ InStock�� �� .R��� $ 
brdBroder5��$��1q�$��Stretch=�._��� $ textBox5��$��90��$	��3,1q����� $ InStock�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	InStock+.a��� $ 
brdBroder5�� � ��
 � � ��� $ textBox5�� � ��
 �  ��  $	 120 $ Barcode�� �� .R��� $ 	brdBroder��$��1q�$��Stretch=�._��� $ textBox��$	��110��$	��3,1q����� $ Barcode�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *RemainLeave+.a��� $ 	brdBroder�� � ��
 � � ��� $ textBox�� � ��
 �����