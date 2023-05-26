using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using MVPTema3.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVPTema3.ViewModels
{
    class TeacherVM : INotifyPropertyChanged
    {
        private Teacher teacher;
        public TeacherVM(Teacher teacher)
        {
            this.teacher = teacher;
            backCommand = new RelayCommand(LogOut);
            finalGradesCommand = new RelayCommand(ShowFinalGrades);
            absenteesCommand = new RelayCommand(ShowAbsences);
            coursesCommand = new RelayCommand(ViewCourses);
            gradesCommand = new RelayCommand(ShowGrades);
            profileCommand = new RelayCommand(ShowTeacherDetails);
            helpCommand = new RelayCommand(Help);
            updateTable = new RelayCommand(UpdateCurrentTable);
            deleteNrCrt = new RelayCommand(DeleteFromCurrentTable);

            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Visible";
            VisibilityUpdateButton = "Hidden";

            ShowTeacherDetails(null);
        }

        private void DeleteFromCurrentTable(object obj)
        {
            if (VisibilityAbsenteesTable == "Visible")
            {
                Console.WriteLine("Absente");
            }
            if (VisibilityGradesTable == "Visible") // Grades
            {
                
            }
            if (VisibilityFinalGradesTable == "Visible") // Final Grades
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                //teacherBLL.SaveGradesChanges(allFinalGrades, teacher.UserID, true);
            }
            if (VisibilityCoursesTable == "Visible") // Courses
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                teacherBLL.DeleteCourse(NrCrt);
            }
            MessageBox.Show("All changes have been updated in database!");
        }

        private void Help(object obj)
        {
            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Visible";
            VisibilityUpdateButton = "Hidden";

            BackgroundText = "Instructions for using the application as a teacher\n\n" +
                "There are three suggestive menus at the top of the screen:\n\n" +
                "1. Menu -> View or edit data\n" +
                " - [My Profile]\nView all personal data associated with your account\n" +
                " - [Absentees]\nView or edit all student absences from your classes\n" +
                " - [Grades \nView or edit all student grades in your class\n" +
                " - [Courses]\nView or edit all your courses materials\n" +
                " - [Final Grades]\nView or edit all student final grades in your class\n\n" +
                "2. Log out -> Close current session and log out\n\n" +
                "3. Help -> Display these informations\n";
        }

        private void UpdateCurrentTable(object obj)
        {
            if(VisibilityAbsenteesTable=="Visible")
            {
                Console.WriteLine("Absente");
            }
            if(VisibilityGradesTable=="Visible") // Grades
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                teacherBLL.SaveGradesChanges(allGrades, teacher.UserID, false);
            }
            if(VisibilityFinalGradesTable=="Visible") // Final Grades
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                teacherBLL.SaveGradesChanges(allFinalGrades, teacher.UserID, true);
            }
            if(VisibilityCoursesTable=="Visible") // Courses
            {
                TeacherBLL teacherBLL = new TeacherBLL();
                teacherBLL.SaveCoursesChanges(allCourses, teacher.UserID);
            }
            MessageBox.Show("All changes have been updated in database!");
        }

        private void LogOut(object obj)
        {
            App.Current.MainWindow.DataContext = new LoginVM();
        }

        private RelayCommand deleteNrCrt;

        public RelayCommand DeleteNrCrt
        {
            get { return deleteNrCrt; }
        }

        private string nrCrt;

        public string  NrCrt
        {
            get { return nrCrt; }
            set { nrCrt = value; }
        }


        private ObservableCollection<AbsenceUI> allAbsentees;
        public ObservableCollection<AbsenceUI> AllAbsentees
        {
            get
            {
                return allAbsentees;
            }
            set
            {
                allAbsentees = value;
                OnPropertyChanged("AllAbsentees");
            }
        }

        private ObservableCollection<Subject> allCourses;
        public ObservableCollection<Subject> AllCourses
        {
            get
            {
                return allCourses;
            }
            set
            {
                allCourses = value;
                OnPropertyChanged("AllCourses");
            }
        }

        private ObservableCollection<GradeUI> allGrades;
        public ObservableCollection<GradeUI> AllGrades
        {
            get
            {
                return allGrades;
            }
            set
            {
                allGrades = value;
                OnPropertyChanged("AllGrades");
            }
        }

        private ObservableCollection<GradeUI> allFinalGrades;
        public ObservableCollection<GradeUI> AllFinalGrades
        {
            get
            {
                return allFinalGrades;
            }
            set
            {
                allFinalGrades = value;
                OnPropertyChanged("AllFinalGrades");
            }
        }

        private RelayCommand profileCommand;
        public RelayCommand ProfileCommand
        {
            get { return profileCommand; }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get { return backCommand; }
        }

        private RelayCommand absenteesCommand;
        public RelayCommand AbsenteesCommand
        {
            get { return absenteesCommand; }
        }

        private RelayCommand gradesCommand;
        public RelayCommand GradesCommand
        {
            get { return gradesCommand; }
        }

        private RelayCommand coursesCommand;
        public RelayCommand CoursesCommand
        {
            get { return coursesCommand; }
        }

        private RelayCommand finalGradesCommand;
        public RelayCommand FinalGradesCommand
        {
            get { return finalGradesCommand; }
        }

        private RelayCommand updateTable;
        public RelayCommand UpdateTable
        {
            get { return updateTable; }
        }

        private RelayCommand helpCommand;
        public RelayCommand HelpCommand
        {
            get { return helpCommand; }
        }

        private void ShowTeacherDetails(object obj)
        {
            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Visible";
            VisibilityUpdateButton = "Hidden";

            BackgroundText = "You are logged in as:\n" +
                "ID: " + teacher.UserID + "\n" +
                "Name: " + teacher.Name + "\n" +
                "Surname: " + teacher.Surname + "\n" +
                "Role: Teacher\n" +
                "Subject: ---------" + "\n";
        }
        private void ViewCourses(object obj)
        {
            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Visible";
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";

            TeacherBLL reader = new TeacherBLL();
            AllCourses = reader.GetCoursesByTeacher(teacher.UserID);
        }

        private void ShowAbsences(object obj)
        {
            VisibilityAbsenteesTable = "Visible";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";

            TeacherBLL reader = new TeacherBLL();
            AllAbsentees = reader.GetAbsenteesByTeacher(teacher.UserID);
        }

        private void ShowFinalGrades(object obj)
        {
            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Hidden";
            VisibilityFinalGradesTable = "Visible";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";

            TeacherBLL reader = new TeacherBLL();
            AllFinalGrades = reader.GetFinalGradesByTeacher(teacher.UserID);
        }

        private void ShowGrades(object obj)
        {
            VisibilityAbsenteesTable = "Hidden";
            VisibilityGradesTable = "Visible";
            VisibilityFinalGradesTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";

            TeacherBLL reader = new TeacherBLL();
            AllGrades = reader.GetGradesByTeacher(teacher.UserID);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private string visibilityAbsenteesTable;

        public string VisibilityAbsenteesTable
        {
            get { return visibilityAbsenteesTable; }
            set { visibilityAbsenteesTable = value; OnPropertyChanged("VisibilityAbsenteesTable"); }
        }

        private string visibilityCoursesTable;

        public string VisibilityCoursesTable
        {
            get { return visibilityCoursesTable; }
            set { visibilityCoursesTable = value; OnPropertyChanged("VisibilityCoursesTable"); }
        }

        private string visibilityGradesTable;

        public string VisibilityGradesTable
        {
            get { return visibilityGradesTable; }
            set { visibilityGradesTable = value; OnPropertyChanged("VisibilityGradesTable"); }
        }

        private string visibilityFinalGradesTable;

        public string VisibilityFinalGradesTable
        {
            get { return visibilityFinalGradesTable; }
            set { visibilityFinalGradesTable = value; OnPropertyChanged("VisibilityFinalGradesTable"); }
        }

        private string backgroundText;

        public string BackgroundText
        {
            get { return backgroundText; }
            set { backgroundText = value; OnPropertyChanged("BackgroundText"); }
        }

        private string textVisibility;

        public string TextVisibility
        {
            get { return textVisibility; }
            set { textVisibility = value; OnPropertyChanged("TextVisibility"); }
        }

        private string visibilityUpdateButton;

        public string VisibilityUpdateButton
        {
            get { return visibilityUpdateButton; }
            set { visibilityUpdateButton = value; OnPropertyChanged("VisibilityUpdateButton"); }
        }
    }
}