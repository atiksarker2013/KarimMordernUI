   M S B A M L   `   `   `  ����   KarimModernUINavigationApp9    3KarimModernUINavigationApp.PopupKarimBookListReport   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � Title$  Book Stock List Report��$��2007.309��$	��727��   BlankWindow#��[   � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�.���� .���� .+��  � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* � � RowDefinitions �� $��* ��� $��20 ��� $��30 ��� $��20 ��� $	��500 ��� $��10 ��� $��30 ��� $��30 ��� $��30 �.+�� $��2��$��0��$��4�� �� $��* ��� $��* ��� $��* ��� $��* ��� $��* � �� $��* �.+��� -   $��searchTextBox��$��0��$��2��$��	118,0,0,0q�	� -   $��selectedBook��$��0��$��
10,0,151,0q�$��Book Search�� 	� 	GroupName$ PaymentType��	� -   $��allBook��$��2��$��
10,0,154,0q�$��All Book��$ PaymentType���� $��0��$��3�� �� Orientation$ 
Horizontal=�.+��� $��Stock Qty Greater Than ��$
��Left=��� -   $!��stockQtyGreatherThanTextBox��$��60�� �� TextAlignment$ Right=��� $��0��$��5��$ 
Horizontal=�.+��� $��     Subject��$
��Left=��� -   $��ZoneBranchIDcomboBox��$��23��$��Right=�$	��Top=�$	��210������ .R��� $ 
Horizontal=�.+��� $	��200������ *SubjectName+� $��4��$��10��$��0��$��4��.+�&   System.Windows.Controls.DataGrid  -   $��bookGrid��   CanUserReorderColumns . 	   CanUserResizeColumns	 . 
   CanUserResizeRows
 .     CanUserSortColumns .    
IsReadOnly . $	��500��$	��Top=� � ContextMenu �� -   $��ZoneIformationList�� �� 	StaysOpen . 
������� J� BitmapEffect �� .@�m� -   $��RemoveZoneInfoContextMenu��$��Remove�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%1   '        �� "  .���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150    Header$ Subject��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ BookType�  $	 500 $ Title�� �� $ Title�  $	 250 $ Writer�� �� $ Writer�  $	 150 $ 	Publisher�� �� $ 	Publisher�  $	 150 $ Edition�� �� $ Edition�  $	 150 $
 Year�� �� $ PublishYear�  $	 150 $
 ISBN�� �� $ Barcode�  $	 150 $
 Bind�� �� $ BookBinding�  $	 100 $ Publisher Unit�� �� $ PublisherUnit�  $	 100 $ 	Pub.Price�� �� $ PublisherPrice�  $ 70 $ Price TK�� �� $ Price�  $ 70 $ 	Stock Qty�� �� $ InStock��� $��6��$��3��$��30,0,0,0q�$ 
Horizontal=�.+��� -	   $��previewButton��$��Preview���� -
   $��closeButton��$��73��$��Close���� $��6��$��0��$��3��$ 
Horizontal=�.+��� $!��    Total number Of Book : ���� -   $��itemCountLabel��$��0���� $ 
Horizontal=�$��7��$��0��$��3��.+��� -   $��titleChkBox��$��Title ���� -   $��writerChkBox��$��Writer ���� -   $��publisherChkBox��$��
Publisher ���� -   $��
isbnChkBox��$��ISBN ���� -   $��publisherPriceChkBox��$��Publisher Price ���� -   $��publisherUnitChkBox��$��Publisher Unit ���� -   $��priceChkBox��$��Price ���� -   $��stockQtyChkBox��$��
Stock Qty ���� $ 
Horizontal=�$��10��$��0��$��3��