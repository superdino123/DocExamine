   M S B A M L   `   `   `  ����K  GDocExamineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DocExamineSystemDocExamineSystem  5   	   &     DocExamineSystem.DocManagerIndex   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DocExamineSystem     5   	     � Title$  文档审批管理��5   	   $	��600��6   $
��1211��6%    � WindowState$ 	Maximized=�62    � Icon$ Doc.png��6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��60* �6   �� 5      $
��524* �6   .+�5   
   �� -   5         ��Name$ examineDocButton��5      $��审批文档��6+   $��Right=�6:   $��
0,10,10,10q�6V   $	��100��6j   $��30��6�   �� 5   
   -   5        $ downloadDocButton��5      $��下载文档��6,   $��Right=�6;   $��0,10,130,10q�6W   $	��100��6l   $��30��6�   �� 5   
   -   5        $ downloadAllDocButton��5      $��全部下载��6/   $��Right=�6>   $��0,10,250,10q�6Z   $	��100��6o   $��30��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��10,-9.23,10,10q�6%   $��1��6=      
IsReadOnly .    AutoGenerateColumns .  ��6\   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 队长名称��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 63   �� *
userName+6R     5      $	 文档名称��6%   
 63   �� *	docName+6Q     5      $	 审核状态��6%   
 63   �� *
docState+6R     5      $	 上传时间��6%   
 63   �� *docUploadTime+6W   5      �� 5   
   -   5        $ refreshButton��5      $��刷新��6(   $��Right=�65   $��0,14.229,370,14.23q�6Q   $	��100��6m   $��30��6y   6�   5      5      