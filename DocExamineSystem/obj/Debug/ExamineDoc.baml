   M S B A M L   `   `   `  ����K  GDocExamineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DocExamineSystemDocExamineSystem  5   	   !    DocExamineSystem.ExamineDoc   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DocExamineSystem     5   	     � Title$  
ExamineDoc��5   	   $	��600��6   $
��1204��6)    � WindowState$ 	Maximized=�66    � Icon$ Doc.png��6N   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��367* �6   �� 5      $
��231* �6   .+�5   
   �� -   5         ��Name$ toIndexButton��5      $��首页��6(   $��1��65   $
��Left=�6E   $��40��6`   $��	10,10,0,0q�6l   $	��Top=�6   $	��100��6�   6�   �� 5   
   $/��)审批意见(每条意见以句号结尾)��6   $��1��6*   $
��Left=�6:   $��30��6U   $��	10,73,0,0q�6a   $	��Top=�6t   $	��200��6�   �� 5   
   -   5         ��Name$ problemTextBox��5      $��1��6*   $��10,103,10,80q�6:    �� TextWrapping$
 Wrap=�6P   �� 5   
   -   5        $ submitProblemButton��5      $��提交审批意见��6.   $��1��6?   $
��Left=�6O   $��20��6j   $��	62,0,0,38q�6v   $��Bottom=�6�   $	��100��6�   6�   �� 5   
   -   5        $ submitSucceedButton��5      $��审批通过��6.   $��1��6=   $��Right=�6M   $��20��6i   $��	0,0,60,38q�6u   $��Bottom=�6�   $	��100��6�   6�   Z� 5   
   -   5         Z�Name$ documentViewer��5      $��	10,10,0,0q�61   5      5      