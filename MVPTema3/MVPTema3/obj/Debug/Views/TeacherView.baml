   M S B A M L   `   `   `  ����C  ?MVPTema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVPTema3.ViewsMVPTema3.Views  5           MVPTema3.Views.TeacherView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MVPTema3.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5"   
   ]� $��0��6   $��7��6$   .+�5#      o� $	��Top=�6   .@�5$      m� $��_Menu��6   $��25(�6*   .@�5%      m� $��
My Profile��6    m� Command 63   �� *ProfileCommand+�� 5&      m� 5'      $��	Absentees��6    62   �� *AbsenteesCommand+�� 5(      m� 5)      $��Grades��6    6/   �� *GradesCommand+�� 5*      m� 5+      $��Courses��6    60   �� *CoursesCommand+�� 5,      m� 5-      $��Final Grades��6    65   �� *FinalGradesCommand+5.      m� 5/      $��Log out��6   $��25(�6,    6:   �� *BackCommand+50      m� 51      $��_Help��6   $��25(�6*    68   �� *HelpCommand+52      53      54      �� 56   
   -   5        $��
Background��56      $��2��6K   $��1��6X   $��5��6h   $��9��6|   
���������6&   ��  �� Path$ BackgroundText�y�6�   �� $ TextVisibility�&   System.Windows.Controls.DataGrid  58   
      AutoGenerateColumns . $��1��6�   $��10��6�   $��7��6�   
���������6   �� $ AllAbsentees� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�y�6p   �� $ VisibilityAbsenteesTable�6�     59   
    . $��1��6�   $��10��6�   $��7��6�   
���������6   �� $ 	AllGrades�$ OneWay=�$ PropertyChanged=�y�6p   �� $ VisibilityGradesTable�6�     5:   
    . $��1��6�   $��10��6�   $��7��6�   
���������6   �� $ AllFinalGrades�$ OneWay=�$ PropertyChanged=�y�6p   �� $  VisibilityFinalGradesTable�6�     5;   
    . $��1��6�   $��10��6�   $��7��6�   
���������6   �� $ 
AllCourses�$ OneWay=�$ PropertyChanged=�y�6p   �� $ VisibilityCoursesTable�6�   �� 5<   
   $(��"Update this table with all changes��6   $��11��6>   $��2��6L   $��3��6\   ��6p   �� $ UpdateTable�y�6�   �� $ VisibilityUpdateButton��� 5=   
   $��Delete this nr crt��6   $��11��6.   $��0��6<   ��6L   �� $ DeleteNrCrt�y�6q   �� $ VisibilityUpdateButton��� 5>   
   $��11��6/   $��1��6>   ��6   �� $ NrCrt�y�6N   �� $ VisibilityUpdateButton�5?      5@      