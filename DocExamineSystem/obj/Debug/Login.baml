   M S B A M L   `   `   `  ����K  GDocExamineSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DocExamineSystemDocExamineSystem  5   	       DocExamineSystem.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DocExamineSystem     5   	     � Title$  文档审批系统��5   	   $	��600��6   $
��1200��6%    � Icon$ Doc.png��62    � WindowState$ 	Maximized=�6A   .��5	      � .+�5
   
   � .+�5      � $��365,163,327,115q�6   $��Center=�6,   $	��500��6I   .+�5      �� $��	账户：��6   $
��Left=�6&   $��
106,70,0,0q�6A   $	��Top=�6U   $��29��6m   $��46��6y   �� 5      $��	密码：��6   $
��Left=�6&   $��24��6A   $��106,124,0,0q�6M   $	��Top=�6b   $��46��6z    J� RenderTransformOrigin$ 0.457,3.083&�6�   �� 5      -   5         ��Name$ 
userIdText��5      $
��Left=�6.   $��23��6I   $��
166,70,0,0q�6U    �� TextWrapping$
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��191��6�   $��2��6�   �� 5      -   5        $ passwordText��5      $
��Left=�60   $��23��6K   $��166,124,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��191��6�   $��2��6�   �� 5      -   5         ��Name$ loginButton��5      $��登  录��6.   $
��Left=�6=   $��106,186,0,0q�6X   $	��Top=�6m   $	��251��6�   $��30��6�   �� 5      $��文档审查系统��6   $��38��6)   $��162,0,216,0q�65   $	��Top=�6J   $��18.667(�6b   $
��Bold"�6t   $��Center=�6�   $��2��6�   �� 5      -   5         ��Name$ toRegisterLabel��5      $*��$没有账号？请点击此处注册��61   $��27��6H   $��146,216,0,0q�6T   ���	#FF7A939B$
��Left=�6�   $	��Top=�6�   5      5      5      5      