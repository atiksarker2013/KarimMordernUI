   M S B A M L   `   `   `  ����   KarimModernUINavigationApp/    )KarimModernUINavigationApp.InvoiceHistory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � Title$  Sales History��$��1536.955��$��701.112��7  1FirstFloor.ModernUI.Windows.Controls.ModernWindow   LogoData� ��|�{h���l�~���ӴL����$:�<��C<��p�<L^��������ф�̴�ӄ��n�$�W`�F�W���d�W<�w@Xt�}̴�� ~o�"%���:���C�:��P���:� -�"%��	h�����@Xt0�"��W��@��W�|�c��W|�{�n|�{h���܄��:�����:`-�m``-����`-��
����(d�܄�(d��P6i(d���B�
���B��Ӽ�Bm`P6i�:܄��:�$&��:Ӱt�:D�Dm`D�D���D�D�
��t(d�$&�(d�Ә׿(d��}��
��}���Ӡ}�m`�׿�:$&��:   BlankWindow#��[   � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���   ContentRoot#��[  � ColumnDefinitions �� $
��690* ��� $
��473* �.+��� $��2��.���� $	��568��.+��  �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $	��430 ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��0��  Heading2#��[ $��From Date  �� �� TextAlignment$ Right=�(  "System.Windows.Controls.DatePicker  -   $��fromDateDatepicker��$��1��$��1���� $��1��$��2��#��[ $��	To Date  ��$ Right=�  -   $��toDateDatepicker��$��1��$��3��� $��2��$��0��$��4�� �� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+��� $��0��$��3�� �� Orientation$ 
Horizontal=�.+��� -   $��Search���� -   $��closeButton��$��Close��� $��4��$��0��$��4��.+�&   System.Windows.Controls.DataGrid  -   $��posDatagrid��   AutoGenerateColumns .  	   
IsReadOnly	 . 
 � 	Resources
 =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%1   '        �� "  .���  � ��$ Center=� � ContextMenu �� -   $��ZoneIformationList��
������� �� 	StaysOpen .  J� BitmapEffect �� .@�m� -   $��printInfoContextMenu��$��Print Invoice��m� -   $��receiveDueContextMenu��$��Receive Due��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50    Header$ Sl.No��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Id�  $	 100 $
 Date�� �� $
 Date�  $	 110 $ 
KarimRefNo�� �� $ 
KarimRefNo�  $	 120 $ CustomerRefNo�� �� $ CustomerRefNo�  $	 250 $ Customer Name�� �� $
 Name�  $ 90 $ Mobile�� �� $ Mobile�  $	 100 $ Total�� �� $ Total�  $	 100 $ Discount�� �� $ Discount�  $	 120 $ OtherDiscount�� �� $ OtherDiscount�  $	 110 $ Grand Total�� �� $ 
GrandTotal�  $	 100 $ Receive�� �� $ Receive�  $ 80 $	 Due�� �� $	 Due�4	  .System.Windows.Controls.DataGridTemplateColumn	  $	 150 $ Status�� 	  CellTemplate �� .R���  ��Name$ 	brdBroder��$��1q�$��Stretch=�._���  ��Name$ txtTextBlock��$	��3,1q����� *Status+ �� Triggers ��  �� Value$
 Paid�� �� Binding �� *Status+.a���  �� 
TargetName$ 	brdBroder�� � ��
 � � ��� $ txtTextBlock�� � ��
 ������� $ Un Paid�� �� *Status+.a��� $ 	brdBroder�� � ��
 �  ���� $ txtTextBlock�� � ��
 ������� $ 
Horizontal=�.+��� -	   $��cusNoChkBox��$��Customer SlNo ���� -
   $��titleChkBox��$��Title ���� -   $��writerChkBox��$��Writer ���� -   $��publisherChkBox��$��
Publisher ���� -   $��
isbnChkBox��$��ISBN ���� -   $��bookTypeChkBox��$��Subject ���� -   $��publisherPriceChkBox��$��Publisher Price ���� -   $��publisherUnitChkBox��$��Publisher Currency ���� $ 
Horizontal=�.+��� -   $��priceChkBox��$��Price ���� -   $��stockQtyChkBox��$��
Stock Qty ���� -   $��orderQtyChkBox��$��
Order Qty ���� -   $��totalUnitPriceChkBox��$��Total Unit Price ���� -   $��discountChkBox��$��	Discount ���� -   $��discountTakaChkBox��$��Discount(Taka) ��