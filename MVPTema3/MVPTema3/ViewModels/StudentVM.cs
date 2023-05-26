using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using MVPTema3.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MVPTema3.ViewModels
{
    class StudentVM : INotifyPropertyChanged
    {
        private Student student;
        public StudentVM(Student student)
        {
            backCommand = new RelayCommand(LogOut);
            gradesCommand = new RelayCommand(ShowGrades);
            finalGradesCommand = new RelayCommand(ShowFinalGrades);
            absencesCommand = new RelayCommand(ShowAbsences);
            profileCommand = new RelayCommand(DisplayStudentDetails);
            coursesCommand = new RelayCommand(ViewCourses);
            openCourse = new RelayCommand(OpenCourseById);
            helpCommand = new RelayCommand(Help);

            this.student = student;
            DisplayStudentDetails(null);


            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            TextVisibility = "Visible";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            VisibilityAbsences = "Hidden";
            CoursesVisibility = "Hidden";
        }

        private void Help(object obj)
        {
            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            TextVisibility = "Visible";
            VisibilityAbsences = "Hidden";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            CoursesVisibility = "Hidden";

            BackgroundText = "Instructions for using the application as a student\n\n" +
               "There are three suggestive menus at the top of the screen:\n\n" +
               "1. Menu -> View data\n" +
               " - [My Profile]\nView all personal data associated with your account\n" +
               " - [Courses and teaching materials]\nView all your courses associated with your specialization\n" +
               " - [My Grades]\nView all your grades at each subject\n" +
               " - [My Final Grades \nView all your final grades at each subject\n" +
               " - [My Absences]\nView all your absences at each subject\n\n" +
               "2. Log out -> Close current session and log out\n\n" +
               "3. Help -> Display these informations\n";
        }

        private void OpenCourseById(object obj)
        {
            string courseName = obj as String;
            MessageBox.Show("A fost aleasa materia: " + courseName + "\n\nDupa apsarea butonului OK, cursul se va incarca in cateva secunde");

            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            VisibilityAbsences = "Hidden";
            WebVisibility = "Visible";
            TextVisibility = "Hidden";
            CourseVisibility = "Hidden";
            CoursesVisibility = "Hidden";

            StudentBLL reader = new StudentBLL();


            PDFViewer = reader.GetSubjectBySpecialization(student.SpecializationID, courseName);
        }

        private void ViewCourses(object obj)
        {
            StudentBLL reader = new StudentBLL();
            courses = reader.GetStudentCourses(student.UserID);
            AllCourses = new ObservableCollection<string>();
            foreach(Tuple<string, string, string> subject in courses)
            {
                AllCourses.Add(subject.Item2);
            }

            CoursesVisibility = "Hidden";
            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            VisibilityAbsences = "Hidden";
            WebVisibility = "Hidden";
            CourseVisibility = "Visible";
            TextVisibility = "Hidden";
            CoursesVisibility = "Visible";
        }

        private void ShowAbsences(object obj)
        {
            StudentBLL reader = new StudentBLL();
            AllAbsences = reader.GetAbsencesByStudent(student.UserID);
            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            TextVisibility = "Hidden";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            VisibilityAbsences = "Visible";
            CoursesVisibility = "Hidden";
        }

        private void ShowFinalGrades(object obj)
        {
            StudentBLL reader = new StudentBLL();
            AllFinalGrades = reader.GetFinalGradesByStudent(student.UserID);

            VisibilityFinalGrades = "Visible";
            VisibilityGrades = "Hidden";
            VisibilityAbsences = "Hidden";
            TextVisibility = "Visible";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            BackgroundText = "AICI VOM PRELUA DIN BAZA DE DATE MATERIA SI MEDIA FINALA";
            CoursesVisibility = "Hidden";
        }

        private void ShowGrades(object obj)
        {
            StudentBLL reader = new StudentBLL();
            AllGrades = reader.GetGradesByStudent(student.UserID);

            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Visible";
            VisibilityAbsences = "Hidden";
            TextVisibility = "Visible";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            BackgroundText = "AICI VOM PRELUA DIN BAZA DE DATE MATERIA SI NOTA";
            CoursesVisibility = "Hidden";
        }

        private void DisplayStudentDetails(object obj)
        {
            VisibilityFinalGrades = "Hidden";
            VisibilityGrades = "Hidden";
            VisibilityAbsences = "Hidden";
            TextVisibility = "Visible";
            CourseVisibility = "Hidden";
            WebVisibility = "Hidden";
            CoursesVisibility = "Hidden";
            BackgroundText = "You are logged in as:\n" +
                "ID: " + student.UserID + "\n" +
                "Name: " + student.Name + "\n" +
                "Surname: " + student.Surname + "\n" +
                "Role: Student\n" +
                "Class: " + student.ClassID + "\n";
        }

        private ObservableCollection<Tuple<string, string, string>> courses;

        private ObservableCollection<AbsenceUI> allAbsences;
        public ObservableCollection<AbsenceUI> AllAbsences
        {
            get
            {
                return allAbsences;
            }
            set
            {
                allAbsences = value;
                OnPropertyChanged("AllAbsences");
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
        private ObservableCollection<string> allCourses;
        public ObservableCollection<string> AllCourses
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
        private void LogOut(object obj)
        {
            App.Current.MainWindow.DataContext = new LoginVM();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get { return backCommand; }
        }

        private RelayCommand coursesCommand;
        public RelayCommand CoursesCommand
        {
            get { return coursesCommand; }
        }

        private RelayCommand gradesCommand;
        public RelayCommand GradesCommand
        {
            get { return gradesCommand; }
        }

        private RelayCommand finalGradesCommand;
        public RelayCommand FinalGradesCommand
        {
            get { return finalGradesCommand; }
        }

        private RelayCommand absencesCommand;
        public RelayCommand AbsencesCommand
        {
            get { return absencesCommand; }
        }

        private RelayCommand profileCommand;
        public RelayCommand ProfileCommand
        {
            get { return profileCommand; }
        }

        private RelayCommand openCourse;
        public RelayCommand OpenCourse
        {
            get { return openCourse; }
        }

        private RelayCommand helpCommand;
        public RelayCommand HelpCommand
        {
            get { return helpCommand; }
        }

        private string backgroundText;

        public string BackgroundText
        {
            get { return backgroundText; }
            set { backgroundText = value; OnPropertyChanged("BackgroundText"); }
        }

        private string visibilityFinalGrades;

        public string VisibilityFinalGrades
        {
            get { return visibilityFinalGrades; }
            set { visibilityFinalGrades = value; OnPropertyChanged("VisibilityFinalGrades"); }
        }

        private string textVisibility;

        public string TextVisibility
        {
            get { return textVisibility; }
            set { textVisibility = value; OnPropertyChanged("TextVisibility"); }
        }

        private string courseVisibility;

        public string CourseVisibility
        {
            get { return courseVisibility; }
            set { courseVisibility = value; OnPropertyChanged("CourseVisibility"); }
        }

        private string webVisibility;

        public string WebVisibility
        {
            get { return webVisibility; }
            set { webVisibility = value; OnPropertyChanged("WebVisibility"); }
        }

        private string coursesVisibility;

        public string CoursesVisibility
        {
            get { return coursesVisibility; }
            set { coursesVisibility = value; OnPropertyChanged("CoursesVisibility"); }
        }

        private string visibilityAbsences;
        public string VisibilityAbsences
        {
            get { return visibilityAbsences; }
            set { visibilityAbsences = value; OnPropertyChanged("VisibilityAbsences"); }
        }

        private string visibilityGrades;
        public string VisibilityGrades
        {
            get { return visibilityGrades; }
            set { visibilityGrades = value; OnPropertyChanged("VisibilityGrades"); }
        }

        private string pDFViewer;

        public string PDFViewer
        {
            get { return pDFViewer; }
            set { pDFViewer = value; OnPropertyChanged("PDFViewer"); }
        }
    }
}
