   M S B A M L   `   `   `  ����   	PlayerWPF    PlayerWPF.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  Window_1�� � Title$ 
PIR Player��$	��450��$	��600��$	��600��$	��450�� � SizeToContent$ WidthAndHeight=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ White��$ 1Q�.��� .+��� -    ��Name$ TextBox1��$��53�� �� TextWrapping$
 Wrap=�$	��Top=�$��0q�$��Adobe Gothic Std B)�$��Center=�	 � UseLayoutRounding	 .  "
 �� VerticalScrollBarVisibility$
 Disabled=�$��Center=� �� 	MaxLength$ 10�����	#FF970F0F$��0q� J� RenderTransformOrigin$ 0.5,0.5&� � Cursor$ Arrow��$	��464��|�.  $��Center=�.��z�V� .~��� �� �� T� .���� -    ��Name$ play_button��$��	0,0,-1,-1q�$��Right=�$��64��$��53��$��Bottom=�$��0q�.���� $��res1/play11.png���� -   $ file_button��$��0q�$��64��$
��Left=�$��Center=�$	��Top=�$��53��
 � Tag$  �� J� IsHitTestVisible . $��0q�����  �� ImageSource$ res1/File_Open.png��r� -    r�Name$	 wmp�� r� LoadedBehavior$ Manual=�$��0q�$	��313��$	��464��$��Center=�$��Center=� . $��Disabled=�$y�Hidden=��� -    ��Name$ VolumeS��$��	10,0,0,57q�$ 0.5,0.5&� � SmallChange$ 1Q� �� TickFrequency$ 0Q� � Value$ 10Q�$��Bottom=�$
��Left=�$��20�� �� Orientation$ Vertical=�$	��100���� -   $ stop_button��$�� ��$
��Left=�$��	-1,0,0,-1q�$��Bottom=�$��64��$��53��$��0q���Z� ��Z� ���� $ res1/stop.png�� j� Stretch$
 None=��� -   $ close_button��$�� ��$��Right=�$	��Top=�$��64��$��53��$��0q����� $ res1/close.png���� -	    ��Name$ IMG_All��$��Center=�$	��292��$��Center=�$	��292��$��0q�$��res1/vis_shape_base.png�� . $y�Hidden=��� -
   $ Parametars_audio��$��Center=�$��53��$��0q�$
 Wrap=�$��Bottom=�$	��465��{�.   �� 	UndoLimit$	 150��$��0:00:00��$��0q�$��Center=�$��Center=�$��24(�$��Pericles)�$
��Bold"���Z� ��Z�  �� TextDecorations Z� .������ $ 0.5,1&�$ 0.5,0&�.��� $ 	#FF1FCF4F��$ 0Q�� $ 	#FF14DCF0��$ 1Q�.���� -   $
 TEST��$
��Left=�$	��127��$��362,53,-1,0q�$
 Wrap=�$	��Top=�$	��231��$
 5000��{�.  �� -   $ Shape_Up��$��66��$��res1/vis_shape_up.png��$ 0.5,0.5&�$	��100��$��246,94,246,259q��� -   $ 
Shape_Down��$��66��$��res1/vis_shape_down.png��$	��100��$��246,262,246,91q��� -   $ 	IMG_Round��$��0q�$��res1/vis_round.png��$	��100��$��Uniform=�$	��100��$��Center=�$��Center=��� -    ��Name$ TEST2��$
��Left=�$	��100��$	��Top=�$	��175��$��	-1,53,0,0q�. �/� .T�J� .*�.*��� $�RichTextBox��