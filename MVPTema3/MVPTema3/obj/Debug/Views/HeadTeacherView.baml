   M S B A M L   `   `   `  ����C  ?MVPTema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVPTema3.ViewsMVPTema3.Views  5      $    MVPTema3.Views.HeadTeacherView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MVPTema3.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5!   
   ]� $��0��6   $��7��6$   .+�5"      o� $	��Top=�6   .@�5#      m� $��_Menu��6   $��25(�6*   .@�5$      m� $��
My Profile��6    m� Command 63   �� *ProfileCommand+m� 5%      $��Uncheck Atendance��6    6:   �� *AtendanceCommand+m� 5&      $��All Absentees In My Class��6    6B   �� *AbsenteesCommand+m� 5'      $+��%All Unmotivated Absentees In My Class��6    6N   �� *UnmotivatedAbsenteesCommand+m� 5(      $��All Absentees By Student��6    6A   �� *AbsenteesByStudentCommand+m� 5)      $*��$All Unmotivated Absentees By Student��6    6M   �� *&$UnmotivatedAbsenteesByStudentCommand+m� 5*      $��Final Grades By Student��6    6@   �� *FinalGradesSemesterCommand+m� 5+      $��Class Hierarchy��6    68   �� *ClassHierarchyCommand+m� 5,      $��Class Status��6    65   �� *ClassStatusCommand+m� 5-      $��Expatriate Students��6    6<   �� *ExpatriateStudentsCommand+5.      m� 5/      $��Log out��6   $��25(�6,    6:   �� *BackCommand+50      m� 51      $��_Help��6   $��25(�6*    68   �� *HelpCommand+52      53      54      �� 56   
   -   5        $��
Background��56      $��2��6K   $��1��6X   $��5��6h   $��9��6|   
���������6&   ��  �� Path$ BackgroundText�y�6�   �� $ TextVisibility�&   System.Windows.Controls.DataGrid  58   
      AutoGenerateColumns . $��1��6�   $��10��6�   $��7��6�   
������� J� IsHitTestVisible .  ��6   �� $ AllAbsentees� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�y�6p   �� $ VisibilityAbsenteesTable�6    59   
    . $��1��6�   $��10��6�   $��7��6�   
������� .  ��6   �� $ AllUnmotivatedAbsentees�$ OneWay=�$ PropertyChanged=�y�6{   �� $) #VisibilityUnmotivatedAbsenteesTable�6&    5:   
    . $��2��6�   $��9��6�   $��7��6�   
������� .  ��6   �� $ AllAbsenteesForStudent�$ OneWay=�$ PropertyChanged=�y�6z   �� $( "VisibilityAbsenteesForStudentTable�6#    5;   
    . $��2��6�   $��9��6�   $��7��6	  
������� .  ��6   �� $' !AllUnmotivatedAbsenteesForStudent�$ OneWay=�$ PropertyChanged=�y�6�   �� $3 -VisibilityUnmotivatedAbsenteesForStudentTable�69    5<   
    . $��1��6�   $��9��6�   $��7��6�   
������� .  ��6   �� $ ClassHierarchy�$ OneWay=�$ PropertyChanged=�y�6r   �� $# VisibilityClassHierrachyTable�6    5=   
    . $��1��6�   $��9��6�   $��7��6�   
������� .  ��6   �� $ ClassStatus�$ OneWay=�$ PropertyChanged=�y�6o   �� $  VisibilityClassStatusTable�6    5>   
    . $��1��6�   $��9��6�   $��7��6�   
������� .  ��6   �� $ ExpatriateStudents�$ OneWay=�$ PropertyChanged=�y�6v   �� $' !VisibilityExpatriateStudentsTable�6    5?   
    . $��2��6�   $��9��6�   $��7��6�   
������� .  ��6   �� $ AllFinalGradesSemester�$ OneWay=�$ PropertyChanged=�y�6z   �� $' !VisibilityFinalMarksSemesterTable�6"    5@   
    . $��2��6�   $��7��6�   $��7��6�   
������� . ��6   �� $&  AllAbsenteesForStudentToMotivate�$ OneWay=�$ PropertyChanged=�y�6�   �� $ VisibilityAtendanceTable�6#  �� 5C   
   $��
Semester 1��6   $��9��6%   $��0��62   y�6B   �� $' !VisibilityFinalMarksSemesterTable�6�   �� 5D   
   $��
Semester 2��6   $��9��6%   $��1��62   y�6B   �� $' !VisibilityFinalMarksSemesterTable�6�   �� 5E   
   $��10��6�   $��0��6�   ��6   �� $ FinalSemester1�$ PropertyChanged=�y�6\   �� $' !VisibilityFinalMarksSemesterTable�6�   �� 5F   
   $��10��6�   $��1��6�   ��6   �� $ FinalSemester2�$ PropertyChanged=�y�6\   �� $' !VisibilityFinalMarksSemesterTable�6�   �� 5H   
   $��1��6W   $��1��6d   ��6   �� $ 	StudentID�$ PropertyChanged=�y�6t   �� $ VisibilityHeader��� 5I   
   $��Student ID:��6   $��1��6%   $��0��62   y�6B   �� $ VisibilityHeader��� 5J   
   $��Show for this student��6*   $��1��6J   $��2��6W   $��2��6g   ��6   �� *Show+y�6{   �� $ VisibilityHeader��� 5L   
   $��9��6W   $��1��6d   ��6   �� $ 	AbsenceID�$ PropertyChanged=�y�6t   �� $ VisibilityAtendanceTable��� 5M   
   $��Absence number:��6   $��9��6)   $��0��66   y�6F   �� $ VisibilityAtendanceTable��� 5N   
   $��Motivate Absence��65   $��9��6P   $��2��6]   $��2��6m   ��6   �� *MotivateCommand+y�6�   �� $ VisibilityAtendanceTable��� 5P   
   $��11��6T   $��7��6b   ��6   �� $
 Info�y�6/   �� $ InfoText�6b   5Q      5R      