   M S B A M L   `   `   `  ���� D  @PlayerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PlayerWPF	PlayerWPF      PlayerWPF.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     &myclr-namespace:PlayerWPF     -     �Name$  Window_1�� � Icon$ res1/icon.png�� � Title$ 
PIR Player��$	��600��$	��850��$
��1000��$	��700�� � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ Manual=�����  �� ImageSource$ res1/backgrounds.jpg�� � 	Resources ��%    .��� -   $��MyGrid1��.+��� -    ��Name$ SongName��$	��110�� �� TextWrapping$
 Wrap=�$	��Top=�$��Pericles)�$��Center=�	 � UseLayoutRounding	 .  "
 �� VerticalScrollBarVisibility$
 Disabled=�$��Center=� �� 	MaxLength$ 10��$��0q� J� RenderTransformOrigin$ 0.5,0.5&� � Cursor$ Arrow��|�.  $
��Bold"�$��16(� J� Opacity$	 0.5Q����	#FF3BD30F$��110,0q���Z� .������  �� Color$ 	#FF970F0F�� �� Opacity$	 0.4Q�.���� -    ��Name$ Shape_Up��$��75��$��res1/vis_shape_up.png��$ 0.5,0.5&�$	��140��$��351,139,351,355q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 9Q�   	Direction$	 315Q��� -   $ 	IMG_Round��$��0q�$��res1/round2.png��$	��116��$	��116��$��Center=�$��Center=�$��UniformToFill=�   $ 0Q�$ 0Q�   
BlurRadius$ 9Q��� -   $ Shape_Right��$	��140��$��75��$��res1/vis_shape_right.png��$��491,214,276,215q�   $	 366Q�$ 4Q��� -   $ 
Shape_Left��$	��140��$��res1/vis_shape_left.png��$��276,214,491,215q�$��75��   $	 349Q��� -   $ 
Shape_Down��$��res1/vis_shape_down.png��$	��140��{�.  	 .  $��351,354,351,140q�$��75��   $ 9Q��� -	    ��Name$ VolumeS��$��	0,0,63,46q�$ 0.5,0.5&� � SmallChange$
 0.05Q� �� TickFrequency$ 0Q� � Value$ 1Q�$��Bottom=�$��Right=�$	��153��$��25�� � Maximum$ 1Q� � LargeChange$	 0.1Q��� -
   $ Parametars_audio��$��38��$
 Wrap=�$��Bottom=�{�.   �� 	UndoLimit$	 150��$��0:00:00��$��0q�$��Center=�$��Center=�$��24(�$��Pericles)�$
��Bold"�$��Center=�$	��255��$��0,0,0,46q���Z� ��Z�  �� TextDecorations Z� .������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���   � Color$  	#FF1FCF4F��! � Offset$! 0Q�� $  	#FF14DCF0��$! 1Q�.���� -   $ AlbumIMGLeft��$
��Left=�$	��110��$	��Top=�$	��110��$��res1/herb.png��$
��Fill=�� -   " �Name$" progressBar��$��
63,0,63,30q����	#FF1FCDDE���	#FF13F990$��Bottom=�$��16��$ 0.5,0.5&�$
 0.01Q���Z� z�V� .~��� # �� ScaleY$# -1Q��� �� T� �� -   $ AlbumIMGRight��$��Right=�$	��110��$	��Top=�$	��110��$��res1/herb.png��$
��Fill=�$��0q��� -   $ 
image_play��$
��Left=�$��	10,0,0,12q�$��50��$��res1/play3_1.png��$��50��$��Bottom=��� -   $ 
image_stop��$��Right=�$��55��$��0,0,7,10q�$��Bottom=�$��55��$��res1/stop.png���� -   $ ��Name$$ label��$��Volume��$��Right=�$��Bottom=�$��
0,0,215,46q�$��75��$��Showcard Gothic)����	#FF188BCD$��16(��� -   $ image_folder��$
��Left=�$��55��$��
25,110,0,0q�$	��Top=�$��55��$��res1/FileImage1.png���� -   % ��Name$% rewindRight��$��>>��$��Right=�$��
0,0,352,51q�$��Bottom=�$��74��$��25��$��Center=�$��Center=��� -   $% 
rewindLeft��$��<<��$
��Left=�$��
352,0,0,51q�$��Bottom=�$��74��$��25��$��Center=�$	��Top=�$��14.667(�$��Medium"��� -   $ VisualisationType��$��Right=�$	��100��$��	0,115,7,0q�$	��Top=�$	��100��$��res1/VisType1.png��