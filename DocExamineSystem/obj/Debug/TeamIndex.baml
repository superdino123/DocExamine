   M S B A M L   `   `   `  ����K  GDocExamineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DocExamineSystemDocExamineSystem  5   	        DocExamineSystem.TeamIndex   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DocExamineSystem     5   	     � Title$  团队文档管理��5   	   $	��600��6   $
��1198��6%    � WindowState$ 	Maximized=�62    � Icon$ Doc.png��6J   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��109* �6   �� 5      $
��700* �6   �� 5      $
��381* �6   .+�5   
   �� -   5         ��Name$ uploadDocButton��5      $��上传文档��6*   $��40��69   $��10,170,10,0q�6E   $	��Top=�6Z   6r   �� 5   
   -   5        $ oldAllDocButton��5      $��以往版本��6*   $��40��69   $��10,100,10,0q�6E   $	��Top=�6Z    J� RenderTransformOrigin$ 0.534,0.321&�6r   6�   �� 5   
   -   5         ��Name$ examineProblemListBox��5      $��2��61   $��10,169,10,143q�6A   � 5   
   $��2��6   $��63��6   $��
10,10,10,0q�6+   $	��Top=�6?   .+�5      �� $��队伍名称��6   $
��Left=�6#   $��10,10,0,28.88q�6>   $��66��6U   $ 	0.5,0.502&�6`   �� 5      -   5         ��Name$ userNameLabel��5      $�� ��6+   $��85,10,10,28.88q�66   5      �� 5   
   $��审批意见��6   $��27��6   $��2��6+   $��21,139,29,0q�6;   $	��Top=�6P   Z� 5   
   -   5         Z�Name$ documentViewer��5      $��1��61   $��0q�6A   � 5   
   $��2��6   $��63��6   $��
10,73,10,0q�6+   $	��Top=�6?   .+�5      �� $��审批状态��6   $
��Left=�6#   $��10,10,0,28.88q�6>   $��66��6U   �� 5      -   5        $ docStateLabel��5      $�� ��6+   $��85,10,10,28.88q�66   5      �� 5   
   -   5        $ openDocInWordButton��5      $��Word中打开��6.   $��40��6@   $��10,240,10,0q�6L   $	��Top=�6a   6y   �� 5   
   -   5        $ toIndexButton��5      $��首页��6(   $��40��65   $��
10,30,10,0q�6A   $	��Top=�6U   6m   5      5       