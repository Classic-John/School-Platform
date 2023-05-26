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
    class StudentBLL
    {
        public ObservableCollection<Student> StudentsList { get; set; }
        public string ErrorMessage { get; set; }

        StudentDAL studentDAL = new StudentDAL();

        public ObservableCollection<Student> GetAllStudents()
        {
            return studentDAL.GetAllStudents();
        }

        public void AddStudent(User user, Student student)
        {
            if (user.UserID == student.UserID)
                studentDAL.AddStudent(user, student);
            else throw new Exception("Error inserting new student");
        }

        public void UpdateStudent(User user, Student student)
        {
            if (user.UserID == student.UserID)
                studentDAL.UpdateStudent(user, student);
            else throw new Exception("Error updating new student");
        }

        public ObservableCollection<AbsenceUI> GetAbsencesByStudent(string studentID)
        {
            return studentDAL.GetAbsencesByStudent(studentID);
        }

        public ObservableCollection<GradeUI> GetGradesByStudent(string studentID)
        {
            return studentDAL.GetGradesByStudent(studentID);
        }

        public ObservableCollection<GradeUI> GetFinalGradesByStudent(string studentID)
        {
            return studentDAL.GetFinalGradesByStudent(studentID);
        }

        public ObservableCollection<Tuple<string, string, string>> GetStudentCourses(string studentID)
        {
            return studentDAL.GetStudentCourses(studentID);
        }

        public string GetSubjectBySpecialization(string specialization_id, string subjectName)
        {
            return studentDAL.GetSubjectBySpecialization(specialization_id, subjectName);
        }
    }
}
