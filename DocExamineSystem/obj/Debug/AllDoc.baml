   M S B A M L   `   `   `  ����K  GDocExamineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DocExamineSystemDocExamineSystem  5   	       DocExamineSystem.AllDoc   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DocExamineSystem     5   	     � Title$  以往版本��5   	   $	��600��6   $
��1200��6#    � WindowState$ 	Maximized=�60    � Icon$ Doc.png��6H   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��109* �6   �� 5      $
��700* �6   �� 5      $
��381* �6   .+�5   
   �� -   5         ��Name$ label��5      $�� ��6   $��21��6*   $��
10,0,10,10q�66   $��Bottom=�6J   �� 5   
   -   5         ��Name$ toIndexButton��5      $��首页��6(   $��40��65   $��
10,30,10,0q�6A   $	��Top=�6U   6m   �� 5   
   -   5        $ oldAllDocButton��5      $��以往版本��6*   $��40��69   $��10,100,10,0q�6E   $	��Top=�6Z   6r   �� 5   
   -   5        $ refreshButton��5      $��刷新��6(   $��40��65   $��10,170,10,0q�6A   $	��Top=�6V   6n   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��2��6%   $��1��69   $��10,35,10,10q�6I      AutoGenerateColumns .     
IsReadOnly . 	   	RowHeight$	 30Q�6�   ��6z   �� 
   RowStyle
 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property � �� �� Value �#F0F0F063    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5      ��  � �� �#F0F0F06;   �� 5       � �� �#495A806;   5      5         Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ 文档编号��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *docId+6O     5"      $ 文档名称��6%    63   �� *	docName+6Q     5#      $ 文档路径��6%    63   �� *	docPath+6Q     5$      $ 上传时间��6%    63   �� *docUploadTime+6W   5&      �� 5'   
   -   5        $ downloadDocButton��5'      $��下载��6,   $��2��69   $��Right=�6I   $��20��6e   $��	0,10,10,0q�6q   $	��Top=�6�   $��90��6�   6�   5)      5*      