   M S B A M L   `   `   `  ����   KarimModernUINavigationApp0    *KarimModernUINavigationApp.KarimAddNewBook   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � Title$  Add New Book��$��1775.053��$��700.092��7  1FirstFloor.ModernUI.Windows.Controls.ModernWindow   LogoData� ��|�{h���l�~���ӴL����$:�<��C<��p�<L^��������ф�̴�ӄ��n�$�W`�F�W���d�W<�w@Xt�}̴�� ~o�"%���:���C�:��P���:� -�"%��	h�����@Xt0�"��W��@��W�|�c��W|�{�n|�{h���܄��:�����:`-�m``-����`-��
����(d�܄�(d��P6i(d���B�
���B��Ӽ�Bm`P6i�:܄��:�$&��:Ӱt�:D�Dm`D�D���D�D�
��t(d�$&�(d�Ә׿(d��}��
��}���Ӡ}�m`�׿�:$&��:   BlankWindow#��[   � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���� .���� .+��  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $	��430 ��� $��* ��� $��* ��� $��* ��� $��* �.+�(  "System.Windows.Controls.DatePicker  -   $��entryDateDatepicker��$��1��$��3��� $��3��$��0��$��4�� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+��� -   $��	addButton��$��3��$��	0,0,197,0q�$	��Add��� $��4��$��0��$��4��.+�&   System.Windows.Controls.DataGrid  -   $��posDatagrid��   AutoGenerateColumns .     
IsReadOnly .  � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader	 �� 
TargetType
 �� Property �� Value �� StringFormat��%u   '        �� "	  .��� 
 � ��$ Center=��� 
 �@��ContentStringFormat �� *
Resolution+$
 N{0}��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 520    Header$ Title��   CellTemplate �� .R���  ��Name$ 
brdBroder1��$��1q�$��Stretch=�._���  ��Name$ textBox1��$	��510��$	��3,1q�����  �� Path$ Title� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� Triggers ��  �� Value$ 0�� �� Binding �� *RemainLeave+.a���  �� 
TargetName$ 
brdBroder1��
 � ��
 � � ��� $ textBox1��
 � ��
 �����  $	 250 $ Writer�� �� .R��� $ 
brdBroder2��$��1q�$��Stretch=�._��� $ textBox2��$	��200��$	��3,1q����� $ Writer�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *Writer+.a��� $ 
brdBroder2��
 � ��
 � � ��� $ textBox2��
 � ��
 �����  $	 150 $ 	Publisher�� �� .R��� $ 
brdBroder3��$��1q�$��Stretch=�._��� $ textBox3��$	��150��$	��3,1q����� $ 	Publisher�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	Publisher+.a��� $ 
brdBroder3��
 � ��
 � � ��� $ textBox3��
 � ��
 �����  $	 100 $
 Year�� �� .R��� $ 
brdBroder6��$��1q�$��Stretch=�._��� $ textBox6��$��90��$	��3,1q����� $ PublishYear�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	Publisher+.a��� $ 
brdBroder6��
 � ��
 � � ��� $ textBox6��
 � ��
 �����  $	 100 $ Edition�� �� .R��� $ brdBroder12��$��1q�$��Stretch=�._��� $ 	textBox12��$��90��$	��3,1q����� $ Edition�$ TwoWay=�$ PropertyChanged=�  $	 100 $ Book Binding�� �� .R��� $ brdBroder12��$��1q�$��Stretch=�._��� $ 	textBox12��$��90��$	��3,1q����� $ BookBinding�$ TwoWay=�$ PropertyChanged=�  $	 150 $ Subject�� �� .R��� $ 
brdBroder8��$��1q�$��Stretch=�._��� $ textBox8��$	��140��$	��3,1q����� $ BookType�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	Publisher+.a��� $ 
brdBroder8��
 � ��
 � � ��� $ textBox8��
 � ��
 �����  $ 70 $
 Unit�� �� .R��� $ 
brdBroder7��$��1q�$��Stretch=�._��� $ textBox7��$��65��$	��3,1q����� $ PublisherUnit�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	Publisher+.a��� $ 
brdBroder7��
 � ��
 � � ��� $ textBox7��
 � ��
 �����  $	 100 $ Publisher Price�� �� .R��� $ 
brdBroder9��$��1q�$��Stretch=�._��� $ textBox9��$��90��$	��3,1q����� $ PublisherPrice�$ TwoWay=�$ PropertyChanged=�$ N2�� �� $ 0�� �� *Price+.a��� $ 
brdBroder9��
 � ��
 � � ��� $ textBox9��
 � ��
 �  ��  $	 100 $ InStock�� �� .R��� $ 
brdBroder5��$��1q�$��Stretch=�._��� $ textBox5��$��90��$	��3,1q����� $ InStock�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *	InStock+.a��� $ 
brdBroder5��
 � ��
 � � ��� $ textBox5��
 � ��
 �  ��  $	 120 $ Barcode�� �� .R��� $ 	brdBroder��$��1q�$��Stretch=�._��� $ textBox��$	��110��$	��3,1q����� $ Barcode�$ TwoWay=�$ PropertyChanged=� �� $ 0�� �� *RemainLeave+.a��� $ 	brdBroder��
 � ��
 � � ��� $ textBox��
 � ��
 ������� $��8��$��3�� �� Orientation$ 
Horizontal=�.+��� -   $��
saveButton��$
��Save���� -   $��closeButton��$��Close��