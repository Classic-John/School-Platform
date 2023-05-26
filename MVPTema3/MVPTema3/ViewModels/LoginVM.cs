using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MVPTema3.ViewModels
{
    class LoginVM : INotifyPropertyChanged
    {
        public LoginVM()
        {
            UserBLL userBLL = new UserBLL();          
            allUsers = new List<User>();
            fontPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Fonts\#password");
            currentUserType = userType[3];
            loginCommand = new RelayCommand(Login);
        }

        private List<User> allUsers;

        private List<string> userType = new List<string> { "Admin", "Teacher", "Head teacher", "Student"};

        public List<string> UserType
        {
            get { return userType; }
            set { userType = value; OnPropertyChanged("UserType"); }
        }

        private string currentUserType;

        public string CurrentUserType
        {
            get { return currentUserType; }
            set { currentUserType = value; OnPropertyChanged("CurrentUserType"); }
        }

        private string fontPath;

        public string FontPath
        {
            get { return fontPath; }
            set { fontPath = value; }
        }


        private void Login(object obj)
        {
            bool headTeacherChosen = false;

            switch (currentUserType)
            {
                case "Admin":

                    AdminBLL adminBLL = new AdminBLL();
                    foreach (User user in adminBLL.GetAllAdmins())
                    {
                        allUsers.Add(user);
                    }
                    break;

                case "Teacher":

                    TeacherBLL teacherBLL = new TeacherBLL();
                    foreach (User user in teacherBLL.GetAllTeachers())
                    {
                        allUsers.Add(user);
                    }
                    break;

                case "Head teacher":

                    headTeacherChosen = true;
                    teacherBLL = new TeacherBLL();
                    foreach (User user in teacherBLL.GetAllTeachers())
                    {
                        allUsers.Add(user);
                    }
                    break;

                case "Student":

                    StudentBLL studentBLL = new StudentBLL();
                    foreach (User user in studentBLL.GetAllStudents())
                    {
                        allUsers.Add(user);
                    }
                    break;

                default:
                    throw new Exception("Critical error!");
            }

            bool userFound = false;
            foreach (User user in allUsers)
            {
                if (user.Name == name && user.Surname == surname && user.Password==password)
                {
                    userFound = true;
                    if (user is Student)
                    {
                        App.Current.MainWindow.DataContext = new StudentVM(user as Student);
                    }
                    if (user is Teacher)
                    {
                        if (headTeacherChosen && (user as Teacher).IsHeadTeacher == true)
                            App.Current.MainWindow.DataContext = new HeadTeacherVM(user as Teacher);
                        else
                            App.Current.MainWindow.DataContext = new TeacherVM(user as Teacher);
                    }
                    if (user is Admin)
                    {
                        App.Current.MainWindow.DataContext = new AdminVM(user as Admin);
                    }
                    break;
                }
            }
            if(!userFound)
            {
                MessageBox.Show("Invalid log in informations!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged("Surname"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get { return loginCommand; }
        }
    }
}
