   M S B A M L   `   `   `  ����C  ?MVPTema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVPTema3.ViewsMVPTema3.Views  5      5clr-namespace:MVPTema3.ControlsMVPTema3.Controls  5           MVPTema3.Views.StudentView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:MVPTema3.Views     5      4controlsclr-namespace:MVPTema3.Controls     5      .��5
      �   � RowDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5       $��1* �6   .+�5"   
   ]� $��0��6   $��7��6$   .+�5#      o� $	��Top=�6   .@�5$      m� $��_Menu��6   $��25(�6*   .@�5%      m� $��
My Profile��6    m� Command 63   �� *ProfileCommand+�� 5&      m� 5'      $$��Courses and teaching materials��6    6G   �� *CoursesCommand+�� 5(      m� 5)      $��	My Grades��6    62   �� *GradesCommand+�� 5*      m� 5+      $��My Final Grades��6    68   �� *FinalGradesCommand+�� 5,      m� 5-      $��My Absences��6    64   �� *AbsencesCommand+5.      m� 5/      $��Log out��6   $��25(�6,    6:   �� *BackCommand+50      m� 51      $��_Help��6   $��25(�6*    68   �� *HelpCommand+52      53      54      (  "System.Windows.Controls.WebBrowser  57   
   $��2��6   $��0��6"   $��7��62   $��10��6F   (   "MVPTema3.Controls.WebBrowserHelper
   Url 6X   �� *	PDFViewer+y�6�   ��  �� Path$ WebVisibility��� 58   
   -   5        $��
Background��58      $��2��6K   $��1��6X   $��5��6h   $��9��6|   
���������6&   �� $ BackgroundText�y�6�   �� $ TextVisibility�&   System.Windows.Controls.DataGrid  59   
      AutoGenerateColumns . $��1��6�   $��11��6�   $��7��6�   
������� J� IsHitTestVisible .  ��6   �� $ AllAbsences� �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�y�6n   �� $ VisibilityAbsences�6    5:   
    . $��1��6�   $��11��6�   $��7��6�   
������� .  ��6   �� $ 	AllGrades�$ OneWay=�$ PropertyChanged=�y�6l   �� $ VisibilityGrades�6    5;   
    . $��1��5<   �   $��11��6�   $��7��6�   
������� .  ��6   �� $ AllFinalGrades�$ OneWay=�$ PropertyChanged=�y�6k   �� $ VisibilityFinalGrades�6  �� 5=   
   -   5        	 ��Name$	 materiiListBox��5>      $��0��5?   �   $��3��6�   $��8��6�   ��6   �� $ 
AllCourses�$ PropertyChanged=�y�6[   �� $ CoursesVisibility�6�   �� 5A   
   $��0��6   $��2��6!   y�5B   	   �� $ CoursesVisibility���5C   	   �� *
OpenCourse+��5D   	   �� 
 �� ElementName$
 materiiListBox��$ SelectedItem�.��6T   Show course6a   5E      5F      