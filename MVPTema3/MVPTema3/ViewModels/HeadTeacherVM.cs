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
    class HeadTeacherVM : INotifyPropertyChanged
    {
        private Teacher teacher;
        public HeadTeacherVM(Teacher teacher)
        {
            this.teacher = teacher;
            backCommand = new RelayCommand(LogOut);
            profileCommand = new RelayCommand(ShowTeacherDetails);
            absenteesCommand = new RelayCommand(ShowAbsences);
            helpCommand = new RelayCommand(Help);
            profileCommand = new RelayCommand(ShowTeacherDetails);
            unmotivatedAbsenteesCommand = new RelayCommand(ShowUnmotivatedAbsences);
            absenteesByStudentCommand = new RelayCommand(ShowAbsencesByStudent);
            unmotivatedAbsenteesByStudentCommand = new RelayCommand(ShowUnmotivatedAbsencesByStudent);
            classHierarchyCommand = new RelayCommand(ShowClassHierarchy);
            classStatusCommand = new RelayCommand(ShowClassStatus);
            expatriateStudentsCommand = new RelayCommand(ShowExpatriateStudents);
            finalGradesSemesterCommand = new RelayCommand(ShowFinalMarksForStudent);
            atendanceCommand = new RelayCommand(ShowAtendance);
            motivateCommand = new RelayCommand(Motivate);
            show = new RelayCommand(ShowButton);
            ShowTeacherDetails(null);
        }

        private void Motivate(object obj)
        {
            TeacherBLL reader = new TeacherBLL();
            foreach(AbsenceUI abs in AllAbsenteesForStudentToMotivate)
            {
                if(abs.Nrcrt == AbsenceID)
                {
                    reader.MotivateAbsence(AbsenceID, abs.IsMotivated);
                    return;
                }
            }
        }

        public void ShowFinalMarksForStudent(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Visible";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Visible";
            VisibilityClassHierrachyTable = "Hidden";
            Info = "";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";
        }
        private void ShowButton(object obj)
        {
            if (VisibilityAbsenteesForStudentTable == "Visible")
                Search_ShowAbsencesByStudent();
            if (VisibilityUnmotivatedAbsenteesForStudentTable == "Visible")
                Search_ShowUnmotivatedAbsencesByStudent();
            if (VisibilityFinalMarksSemesterTable == "Visible")
                Search_ShowFinalMarksSemesterByStudent();
            if (VisibilityAtendanceTable == "Visible")
                Search_ShowAtendance();
        }

        private void ShowAtendance(object obj)
        {
            VisibilityAtendanceTable = "Visible";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Visible";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Visible";
            VisibilityClassHierrachyTable = "Hidden";
            Info = "";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";
        }
        private void Search_ShowAtendance()
        {
            TeacherBLL reader = new TeacherBLL();
            AllAbsenteesForStudentToMotivate = reader.GetAbsenteesByTeacherClass(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID);
        }

        private void ShowAbsencesByStudent(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Visible";
            VisibilityAbsenteesForStudentTable = "Visible";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Visible";
            VisibilityClassHierrachyTable = "Hidden";
            Info = "";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";
        }

        private void Search_ShowAbsencesByStudent()
        {
            TeacherBLL reader = new TeacherBLL();
            AllAbsenteesForStudent = reader.GetAbsenteesByTeacherClassForStudentID(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID, StudentID);
            Info = "Total absentees for this student: " + AllAbsenteesForStudent.Count();
        }

        private void Search_ShowFinalMarksSemesterByStudent()
        {
            TeacherBLL reader = new TeacherBLL();
            AllFinalGradesSemester = reader.GetStudentFinalMarksByStudentId(StudentID);

            List<float> firstSemesterMarks = new List<float>();
            List<float> secondSemesterMarks = new List<float>();
            foreach (FinalGradeSemesterUI grade in AllFinalGradesSemester)
            {
                if (grade.Semester == 1)
                    firstSemesterMarks.Add(grade.Mark);
                else
                    secondSemesterMarks.Add(grade.Mark);
            }
            FinalSemester1 = firstSemesterMarks.Sum() / firstSemesterMarks.Count;
            FinalSemester2 = secondSemesterMarks.Sum() / secondSemesterMarks.Count;
        }

        private void ShowUnmotivatedAbsencesByStudent(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Visible";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Visible";
            VisibilityHeader = "Visible";
            Info = "";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";
        }

        private void Search_ShowUnmotivatedAbsencesByStudent()
        {
            TeacherBLL reader = new TeacherBLL();
            AllUnmotivatedAbsenteesForStudent = reader.GetAbsenteesByTeacherClassForStudentID(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID, StudentID);
            Info = "Total unmotivated absentees for this student: " + AllUnmotivatedAbsenteesForStudent.Count();
        }

        private void ShowExpatriateStudents(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Visible";

            TeacherBLL reader = new TeacherBLL();
            ExpatriateStudents = reader.GetExpatriateStudents(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID);
        }

        private void ShowClassHierarchy(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityClassHierrachyTable = "Visible";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";

            TeacherBLL reader = new TeacherBLL();
            ClassHierarchy = reader.GetClassFinalMarks(reader.FindClassOfHeadTeacher(teacher.UserID));

        }

        private void ShowClassStatus(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Visible";
            VisibilityExpatriateStudentsTable = "Hidden";

            TeacherBLL reader = new TeacherBLL();
            ClassStatus = reader.GetClassFinalMarksWithStatus(reader.FindClassOfHeadTeacher(teacher.UserID));

        }

        private void ShowUnmotivatedAbsences(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Visible";
            InfoText = "Visible";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";

            TeacherBLL reader = new TeacherBLL();
            AllUnmotivatedAbsentees = reader.GetUnmotivatedAbsenteesByTeacherClass(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID);
            Info = "Total unmotivated absentees in my class: " + AllUnmotivatedAbsentees.Count();
        }

        private void Help(object obj)
        {
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            TextVisibility = "Visible";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";

            BackgroundText = "Instructions for using the application as a headteacher\n\n" +
                "There are three suggestive menus at the top of the screen:\n\n" +
                "1. Menu -> View or edit data about your class\n\n" +
                "2. Log out -> Close current session and log out\n\n" +
                "3. Help -> Display these informations\n";
        }

        private void LogOut(object obj)
        {
            App.Current.MainWindow.DataContext = new LoginVM();
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

        private ObservableCollection<AbsenceUI> allUnmotivatedAbsentees;
        public ObservableCollection<AbsenceUI> AllUnmotivatedAbsentees
        {
            get
            {
                return allUnmotivatedAbsentees;
            }
            set
            {
                allUnmotivatedAbsentees = value;
                OnPropertyChanged("AllUnmotivatedAbsentees");
            }
        }

        private ObservableCollection<AbsenceUI> allAbsenteesForStudent;
        public ObservableCollection<AbsenceUI> AllAbsenteesForStudent
        {
            get
            {
                return allAbsenteesForStudent;
            }
            set
            {
                allAbsenteesForStudent = value;
                OnPropertyChanged("AllAbsenteesForStudent");
            }
        }

        private ObservableCollection<AbsenceUI> allAbsenteesForStudentToMotivate;
        public ObservableCollection<AbsenceUI> AllAbsenteesForStudentToMotivate
        {
            get
            {
                return allAbsenteesForStudentToMotivate;
            }
            set
            {
                allAbsenteesForStudentToMotivate = value;
                OnPropertyChanged("AllAbsenteesForStudentToMotivate");
            }
        }

        private ObservableCollection<FinalGradeSemesterUI> allFinalGradesSemester;
        public ObservableCollection<FinalGradeSemesterUI> AllFinalGradesSemester
        {
            get
            {
                return allFinalGradesSemester;
            }
            set
            {
                allFinalGradesSemester = value;
                OnPropertyChanged("AllFinalGradesSemester");
            }
        }

        private ObservableCollection<AbsenceUI> allUnmotivatedAbsenteesForStudent;
        public ObservableCollection<AbsenceUI> AllUnmotivatedAbsenteesForStudent
        {
            get
            {
                return allUnmotivatedAbsenteesForStudent;
            }
            set
            {
                allUnmotivatedAbsenteesForStudent = value;
                OnPropertyChanged("AllUnmotivatedAbsenteesForStudent");
            }
        }

        private ObservableCollection<StudentGradeUI> classHierarchy;
        public ObservableCollection<StudentGradeUI> ClassHierarchy
        {
            get
            {
                return classHierarchy;
            }
            set
            {
                classHierarchy = value;
                OnPropertyChanged("ClassHierarchy");
            }
        }

        private ObservableCollection<ExtendedStudentGradeUI> classStatus;
        public ObservableCollection<ExtendedStudentGradeUI> ClassStatus
        {
            get
            {
                return classStatus;
            }
            set
            {
                classStatus = value;
                OnPropertyChanged("ClassStatus");
            }
        }

        private ObservableCollection<StudentAbsenceUI> expatriateStudents;
        public ObservableCollection<StudentAbsenceUI> ExpatriateStudents
        {
            get
            {
                return expatriateStudents;
            }
            set
            {
                expatriateStudents = value;
                OnPropertyChanged("ExpatriateStudents");
            }
        }
        private RelayCommand atendanceCommand;
        public RelayCommand AtendanceCommand
        {
            get { return atendanceCommand; }
        }

        private RelayCommand finalGradesSemesterCommand;
        public RelayCommand FinalGradesSemesterCommand
        {
            get { return finalGradesSemesterCommand; }
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

        private RelayCommand classHierarchyCommand;

        public RelayCommand ClassHierarchyCommand
        {
            get { return classHierarchyCommand; }
        }

        private RelayCommand absenteesCommand;
        public RelayCommand AbsenteesCommand
        {
            get { return absenteesCommand; }
        }

        private RelayCommand absenteesToMotivateCommand;
        public RelayCommand AbsenteesToMotivateCommand
        {
            get { return absenteesToMotivateCommand; }
        }

        private RelayCommand motivateCommand;
        public RelayCommand MotivateCommand
        {
            get { return motivateCommand; }
        }

        private RelayCommand expatriateStudentsCommand;
        public RelayCommand ExpatriateStudentsCommand
        {
            get { return expatriateStudentsCommand; }
        }

        private RelayCommand unmotivatedAbsenteesCommand;
        public RelayCommand UnmotivatedAbsenteesCommand
        {
            get { return unmotivatedAbsenteesCommand; }
        }

        private RelayCommand absenteesByStudentCommand;
        public RelayCommand AbsenteesByStudentCommand
        {
            get { return absenteesByStudentCommand; }
        }

        private RelayCommand unmotivatedAbsenteesByStudentCommand;
        public RelayCommand UnmotivatedAbsenteesByStudentCommand
        {
            get { return unmotivatedAbsenteesByStudentCommand; }
        }

        private RelayCommand helpCommand;
        public RelayCommand HelpCommand
        {
            get { return helpCommand; }
        }

        private RelayCommand classStatusCommand;
        public RelayCommand ClassStatusCommand
        {
            get { return classStatusCommand; }
        }

        private RelayCommand show;
        public RelayCommand Show
        {
            get { return show; }
        }

        private void ShowTeacherDetails(object obj)
        {
            VisibilityAtendanceTable = "Hidden";
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            VisibilityAbsenteesTable = "Hidden";
            TextVisibility = "Visible";
            InfoText = "Hidden";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";

            BackgroundText = "You are logged in as:\n" +
                "ID: " + teacher.UserID + "\n" +
                "Name: " + teacher.Name + "\n" +
                "Surname: " + teacher.Surname + "\n" +
                "Role: HeadTeacher\n" +
                "Subject: ---------" + "\n";
        }

        private void ShowAbsences(object obj)
        {
            VisibilityFinalMarksSemesterTable = "Hidden";
            VisibilityAbsenteesTable = "Visible";
            TextVisibility = "Hidden";
            VisibilityUnmotivatedAbsenteesTable = "Hidden";
            InfoText = "Visible";
            VisibilityAbsenteesForStudentTable = "Hidden";
            VisibilityHeader = "Hidden";
            VisibilityUnmotivatedAbsenteesForStudentTable = "Hidden";
            VisibilityClassHierrachyTable = "Hidden";
            VisibilityClassStatusTable = "Hidden";
            VisibilityExpatriateStudentsTable = "Hidden";

            TeacherBLL reader = new TeacherBLL();
            AllAbsentees = reader.GetAbsenteesByTeacherClass(reader.FindClassOfHeadTeacher(teacher.UserID), teacher.UserID);
            Info = "Total absentees in my class: " + AllAbsentees.Count();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private string visibilityFinalMarksSemesterTable;

        public string VisibilityFinalMarksSemesterTable
        {
            get { return visibilityFinalMarksSemesterTable; }
            set { visibilityFinalMarksSemesterTable = value; OnPropertyChanged("visibilityFinalMarksSemesterTable"); }
        }

        private string visibilityAbsenteesTable;

        public string VisibilityAbsenteesTable
        {
            get { return visibilityAbsenteesTable; }
            set { visibilityAbsenteesTable = value; OnPropertyChanged("VisibilityAbsenteesTable"); }
        }

        private string visibilityAbsenteesForStudentTable;

        public string VisibilityAbsenteesForStudentTable
        {
            get { return visibilityAbsenteesForStudentTable; }
            set { visibilityAbsenteesForStudentTable = value; OnPropertyChanged("VisibilityAbsenteesForStudentTable"); }
        }

        private string visibilityUnmotivatedAbsenteesForStudentTable;

        public string VisibilityUnmotivatedAbsenteesForStudentTable
        {
            get { return visibilityUnmotivatedAbsenteesForStudentTable; }
            set { visibilityUnmotivatedAbsenteesForStudentTable = value; OnPropertyChanged("VisibilityUnmotivatedAbsenteesForStudentTable"); }
        }

        private string visibilityClassHierrachyTable;

        public string VisibilityClassHierrachyTable
        {
            get { return visibilityClassHierrachyTable; }
            set { visibilityClassHierrachyTable = value; OnPropertyChanged("VisibilityClassHierrachyTable"); }
        }

        private string visibilityHeader;

        public string VisibilityHeader
        {
            get { return visibilityHeader; }
            set { visibilityHeader = value; OnPropertyChanged("VisibilityHeader"); }
        }

        private string visibilityClassStatusTable;

        public string VisibilityClassStatusTable
        {
            get { return visibilityClassStatusTable; }
            set { visibilityClassStatusTable = value; OnPropertyChanged("VisibilityClassStatusTable"); }
        }
        private string visibilityExpatriateStudentsTable;

        public string VisibilityExpatriateStudentsTable
        {
            get { return visibilityExpatriateStudentsTable; }
            set { visibilityExpatriateStudentsTable = value; OnPropertyChanged("VisibilityExpatriateStudentsTable"); }
        }

        private string studentID;

        public string StudentID
        {
            get { return studentID; }
            set { studentID = value; OnPropertyChanged("StudentID"); }
        }

        private string absenceID;

        public string AbsenceID
        {
            get { return absenceID; }
            set { absenceID = value; OnPropertyChanged("AbsenceID"); }
        }

        private string info;

        public string Info
        {
            get { return info; }
            set { info = value; OnPropertyChanged("Info"); }
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

        private string infoText;

        public string InfoText
        {
            get { return infoText; }
            set { infoText = value; OnPropertyChanged("InfoText"); }
        }

        private string visibilityUnmotivatedAbsenteesTable;

        public string VisibilityUnmotivatedAbsenteesTable
        {
            get { return visibilityUnmotivatedAbsenteesTable; }
            set { visibilityUnmotivatedAbsenteesTable = value; OnPropertyChanged("VisibilityUnmotivatedAbsenteesTable"); }
        }
        

        private string visibilityAtendanceTable;

        public string VisibilityAtendanceTable
        {
            get { return visibilityAtendanceTable; }
            set { visibilityAtendanceTable = value; OnPropertyChanged("VisibilityAtendanceTable"); }
        }

        private float finalSemester1;

        public float FinalSemester1
        {
            get { return finalSemester1; }
            set { finalSemester1 = value; OnPropertyChanged("FinalSemester1"); }
        }

        private float finalSemester2;

        public float FinalSemester2
        {
            get { return finalSemester2; }
            set { finalSemester2 = value; OnPropertyChanged("FinalSemester2"); }
        }
    }
}