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
    class AdminVM : INotifyPropertyChanged
    {
        private Admin admin;
        public AdminVM(Admin admin)
        {
            this.admin = admin;

            backCommand = new RelayCommand(LogOut);
            helpCommand = new RelayCommand(Help);
            profileCommand = new RelayCommand(DisplayAdminDetails);
            studentAdministrationCommand = new RelayCommand(DisplayStudents);
            teacherAdministrationCommand = new RelayCommand(DisplayTeachers);
            courseAdministrationCommand = new RelayCommand(DisplayCourses);
            classAdministrationCommand = new RelayCommand(DisplayClasses);
            updateTable = new RelayCommand(UpdateCurrentTable);
            deleteNrCrt = new RelayCommand(DeleteFromCurrentTable);
            refresh = new RelayCommand(RefreshCurrentTable);

            DisplayAdminDetails(null);
        }

        private void DisplayClasses(object obj)
        {
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";
            VisibilityStudentsTable = "Hidden";
            VisibilityTeachersTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            VisibilityClassesTable = "Visible";

            AdminBLL adminBll = new AdminBLL();
            AllClasses = adminBll.GetAllClassesUI();
        }

        private void RefreshCurrentTable(object obj)
        {
            if (VisibilityCoursesTable == "Visible")
            {
                DisplayCourses(null);
            }
            if (VisibilityStudentsTable == "Visible")
            {
                DisplayStudents(null);
            }
            if (VisibilityTeachersTable == "Visible")
            {
                DisplayTeachers(null);
            }
            if (VisibilityClassesTable =="Visible")
            {
                DisplayClasses(null);
            }
        }

        private void DeleteFromCurrentTable(object obj)
        {
            AdminBLL adminBll = new AdminBLL();

            if (VisibilityCoursesTable == "Visible")
            {
                adminBll.DeleteCourse(NrCrt);
            }
            if (VisibilityStudentsTable == "Visible")
            {
                adminBll.DeleteStudent(NrCrt);
            }
            if (VisibilityTeachersTable == "Visible")
            {
                adminBll.DeleteTeacher(NrCrt);
            }
            if (VisibilityClassesTable == "Visible")
            {
                adminBll.DeleteClass(NrCrt);
            }
            MessageBox.Show("All changes have been updated in database!");
        }

        private void UpdateCurrentTable(object obj)
        {
            AdminBLL adminBll = new AdminBLL();

            if (VisibilityCoursesTable=="Visible")
            {
                adminBll.SaveCoursesChanges(AllCourses);
            }
            if (VisibilityStudentsTable == "Visible")
            {
                adminBll.SaveStudentChanges(AllStudents);
            }
            if (VisibilityTeachersTable == "Visible")
            {
                adminBll.SaveTeacherChanges(AllTeachers);
            }
            if (VisibilityClassesTable == "Visible")
            {
                adminBll.SaveClassesChanges(AllClasses);
            }
            MessageBox.Show("All changes have been updated in database!");
        }

        private void DisplayCourses(object obj)
        {
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";
            VisibilityStudentsTable = "Hidden";
            VisibilityTeachersTable = "Hidden";
            VisibilityCoursesTable = "Visible";
            VisibilityClassesTable = "Hidden";

            AdminBLL adminBll = new AdminBLL();
            AllCourses = adminBll.GetCourses();
        }

        private void DisplayTeachers(object obj)
        {
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";
            VisibilityStudentsTable = "Hidden";
            VisibilityTeachersTable = "Visible";
            VisibilityCoursesTable = "Hidden";
            VisibilityClassesTable = "Hidden";

            AdminBLL adminBll = new AdminBLL();
            AllTeachers = adminBll.GetAllTeachers();
        }

        private void DisplayStudents(object obj)
        {
            TextVisibility = "Hidden";
            VisibilityUpdateButton = "Visible";
            VisibilityStudentsTable = "Visible";
            VisibilityTeachersTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            VisibilityClassesTable = "Hidden";

            AdminBLL adminBll = new AdminBLL();
            AllStudents = adminBll.GetAllStudents();
        }

        private void DisplayAdminDetails(object p)
        {
            TextVisibility = "Visible";
            VisibilityUpdateButton = "Hidden";
            VisibilityStudentsTable = "Hidden";
            VisibilityTeachersTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            VisibilityClassesTable = "Hidden";

            BackgroundText = "You are logged in as:\n" +
                "ID: " + admin.UserID + "\n" +
                "Name: " + admin.Name + "\n" +
                "Surname: " + admin.Surname + "\n" +
                "Role: Admin\n";
        }

        private void Help(object obj)
        {
            TextVisibility = "Visible";
            VisibilityUpdateButton = "Hidden";
            VisibilityStudentsTable = "Hidden";
            VisibilityTeachersTable = "Hidden";
            VisibilityCoursesTable = "Hidden";
            VisibilityClassesTable = "Hidden";

            BackgroundText = "Instructions for using the application as a admin\n\n" +
               "There are three suggestive menus at the top of the screen:\n\n" +
               "1. Menu -> View data\n" +
               " - [My Profile]\nView all personal data associated with your account\n" +
               " - [Student Administration]\nEdit details about students\n" +
               " - [Teacher Administration]\nEdit details about teachers\n" +
               " - [Course Administration] \nEdit details about courses\n" +
               " - [Class Administration]\nEdit details about classes\n\n" +
               "2. Log out -> Close current session and log out\n\n" +
               "3. Help -> Display these informations\n";
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

        private string visibilityStudentsTable;

        public string VisibilityStudentsTable
        {
            get { return visibilityStudentsTable; }
            set { visibilityStudentsTable = value; OnPropertyChanged("VisibilityStudentsTable"); }
        }

        private string visibilityTeachersTable;

        public string VisibilityTeachersTable
        {
            get { return visibilityTeachersTable; }
            set { visibilityTeachersTable = value; OnPropertyChanged("VisibilityTeachersTable"); }
        }

        private string visibilityCoursesTable;

        public string VisibilityCoursesTable
        {
            get { return visibilityCoursesTable; }
            set { visibilityCoursesTable = value; OnPropertyChanged("VisibilityCoursesTable"); }
        }


        private string visibilityClassesTable;

        public string VisibilityClassesTable
        {
            get { return visibilityClassesTable; }
            set { visibilityClassesTable = value; OnPropertyChanged("VisibilityClassesTable"); }
        }

        private RelayCommand refresh;

        public RelayCommand Refresh
        {
            get { return refresh; }
        }

        private RelayCommand deleteNrCrt;

        public RelayCommand DeleteNrCrt
        {
            get { return deleteNrCrt; }
        }

        private RelayCommand profileCommand;
        public RelayCommand ProfileCommand
        {
            get { return profileCommand; }
        }

        private RelayCommand updateTable;
        public RelayCommand UpdateTable
        {
            get { return updateTable; }
        }

        private RelayCommand studentAdministrationCommand;
        public RelayCommand StudentAdministrationCommand
        {
            get { return studentAdministrationCommand; }
        }

        private RelayCommand teacherAdministrationCommand;
        public RelayCommand TeacherAdministrationCommand
        {
            get { return teacherAdministrationCommand; }
        }

        private RelayCommand courseAdministrationCommand;
        public RelayCommand CourseAdministrationCommand
        {
            get { return courseAdministrationCommand; }
        }
        
        private string nrCrt;

        public string NrCrt
        {
            get { return nrCrt; }
            set { nrCrt = value; }
        }

        private RelayCommand helpCommand;
        public RelayCommand HelpCommand
        {
            get { return helpCommand; }
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get { return backCommand; }
        }

        private RelayCommand classAdministrationCommand;
        public RelayCommand ClassAdministrationCommand
        {
            get { return classAdministrationCommand; }
        }

        private ObservableCollection<StudentUI> allStudents;
        public ObservableCollection<StudentUI> AllStudents
        {
            get
            {
                return allStudents;
            }
            set
            {
                allStudents = value;
                OnPropertyChanged("AllStudents");
            }
        }

        private ObservableCollection<TeacherUI> allTeachers;
        public ObservableCollection<TeacherUI> AllTeachers
        {
            get
            {
                return allTeachers;
            }
            set
            {
                allTeachers = value;
                OnPropertyChanged("AllTeachers");
            }
        }

        private ObservableCollection<CourseUI> allCourses;
        public ObservableCollection<CourseUI> AllCourses
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

        private ObservableCollection<ClassUI> allClasses;
        public ObservableCollection<ClassUI> AllClasses
        {
            get
            {
                return allClasses;
            }
            set
            {
                allClasses = value;
                OnPropertyChanged("AllClasses");
            }
        }
    }
}
