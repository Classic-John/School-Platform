using MVPTema3.Models.DataAccessLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.BussinessLogicLayer
{
    class AdminBLL
    {
        public ObservableCollection<Admin> AdminList { get; set; }
        public string ErrorMessage { get; set; }

        AdminDAL adminDAL = new AdminDAL();

        public ObservableCollection<Admin> GetAllAdmins()
        {
            return adminDAL.GetAllAdmins();
        }

        public ObservableCollection<StudentUI> GetAllStudents()
        {
            return adminDAL.GetAllStudents();
        }

        public ObservableCollection<TeacherUI> GetAllTeachers()
        {
            return adminDAL.GetAllTeachers();
        }

        public ObservableCollection<CourseUI> GetCourses()
        {
            return adminDAL.GetCourses();
        }

        public void SaveCoursesChanges(ObservableCollection<CourseUI> courseUIs)
        {
            adminDAL.SaveCoursesChanges(courseUIs);
        }

        public void DeleteCourse(string course_id)
        {
            adminDAL.DeleteCourse(course_id);
        }

        public ObservableCollection<ClassUI> GetAllClassesUI()
        {
            return adminDAL.GetAllClassesUI();
        }

        public void DeleteClass(string class_id)
        {
            adminDAL.DeleteClass(class_id);
        }

        public void DeleteStudent(string student_id)
        {
            adminDAL.DeleteStudent(student_id);
        }

        public void DeleteTeacher(string teacher_id)
        {
            adminDAL.DeleteTeacher(teacher_id);
        }

        public void SaveStudentChanges(ObservableCollection<StudentUI> allStudents)
        {
            adminDAL.SaveStudentChanges(allStudents);
        }

        public void SaveTeacherChanges(ObservableCollection<TeacherUI> allTeachers)
        {
            adminDAL.SaveTeacherChanges(allTeachers);
        }

        public void SaveClassesChanges(ObservableCollection<ClassUI> allClasses)
        {
            adminDAL.SaveClassesChanges(allClasses);
        }
    }
}
