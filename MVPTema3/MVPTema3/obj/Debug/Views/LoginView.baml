   M S B A M L   `   `   `  ����C  ?MVPTema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVPTema3.ViewsMVPTema3.Views  5      9!clr-namespace:MVPTema3.ViewModelsMVPTema3.ViewModels  5          MVPTema3.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MVPTema3.Views     5      8
viewModels!clr-namespace:MVPTema3.ViewModels     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5       $��1* �6   .+�5#   
   �� $��2��6q   $��2��6�   $��3��6�   ��6   ��  �� Path$ UserType� �� Mode$ OneWay=� �� SelectedItem 6H   �� *CurrentUserType+6�   �� 5$   
   $��2��6U   $��4��6e   $��3��6r   ��6   �� $
 Name� �� UpdateSourceTrigger$ PropertyChanged=�6r   �� 5%   
   $��2��6X   $��6��6h   $��3��6u   ��6   �� $ Surname�$ PropertyChanged=�6u   �� 5&   
   $��2��6Y   $��8��6i   $��3��6v   ��6   �� $ Password�$ PropertyChanged=���6�   �� $ FontPath��� 5'   
   $��Log in��67   $��3��6H   $��10��6X   ��6   �� $ LoginCommand�6X   �� 5)   
   $��	Login as:��6   $��1��6$   $��2��64   �� 5*   
   $��Name:��6   $��1��6    $��4��61   �� 5+   
   $��Surname:��6   $��1��6#   $��6��63   �� 5,   
   $��	Password:��6   $��1��6$   $��8��64   5-      5.      