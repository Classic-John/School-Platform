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
    class TeacherBLL
    {
        public ObservableCollection<Teacher> TeacherList { get; set; }
        public string ErrorMessage { get; set; }

        TeacherDAL teacherDAL = new TeacherDAL();

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return teacherDAL.GetAllTeachers();
        }

        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacher(string teacher_id)
        {
            return teacherDAL.GetAbsenteesByTeacher(teacher_id);
        }

        public ObservableCollection<GradeUI> GetGradesByTeacher(string teacher_id)
        {
            return teacherDAL.GetGradesByTeacher(teacher_id);
        }

        public ObservableCollection<GradeUI> GetFinalGradesByTeacher(string teacher_id)
        {
            return teacherDAL.GetFinalGradesByTeacher(teacher_id);
        }

        public ObservableCollection<Subject> GetCoursesByTeacher(string teacher_id)
        {
            return teacherDAL.GetCoursesByTeacher(teacher_id);
        }

        public void SaveGradesChanges(ObservableCollection<GradeUI> grades, string teacher_id, bool isFinalGrade)
        {
            teacherDAL.SaveGradesChanges(grades, teacher_id, isFinalGrade);
        }

        public void SaveCoursesChanges(ObservableCollection<Subject> subjects, string teacher_id)
        {
            teacherDAL.SaveCoursesChanges(subjects, teacher_id);
        }

        public void DeleteCourse(string grade_id)
        {
            teacherDAL.DeleteCourse(grade_id);
        }

        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacherClass(string class_id, string teacher_id)
        {
            return teacherDAL.GetAbsenteesByTeacherClass(class_id, teacher_id);
        }

        public ObservableCollection<AbsenceUI> GetUnmotivatedAbsenteesByTeacherClass(string class_id, string teacher_id)
        {
            return teacherDAL.GetUnmotivatedAbsenteesByTeacherClass(class_id, teacher_id);
        }

        public string FindClassOfHeadTeacher(string teacher_id)
        {
            return teacherDAL.FindClassOfHeadTeacher(teacher_id);
        }

        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacherClassForStudentID(string class_id, string teacher_id, string student_id)
        {
            return teacherDAL.GetAbsenteesByTeacherClassForStudentID(class_id, teacher_id, student_id);
        }

        public ObservableCollection<AbsenceUI> GetUnmotivatedAbsenteesByTeacherClassForStudentID(string class_id, string teacher_id, string student_id)
        {
            return teacherDAL.GetUnmotivatedAbsenteesByTeacherClassForStudentID(class_id, teacher_id, student_id);
        }

        public ObservableCollection<StudentGradeUI> GetClassFinalMarks(string class_id)
        {
            return teacherDAL.GetClassFinalMarks(class_id);
        }

        public ObservableCollection<ExtendedStudentGradeUI> GetClassFinalMarksWithStatus(string class_id)
        {
            return teacherDAL.GetClassFinalMarksWithStatus(class_id);
        }

        public ObservableCollection<StudentAbsenceUI> GetExpatriateStudents(string class_id, string teacher_id)
        {
            return teacherDAL.GetExpatriateStudents(class_id, teacher_id);
        }
        public ObservableCollection<FinalGradeSemesterUI> GetStudentFinalMarksByStudentId(string student_id)
        {
            return teacherDAL.GetStudentFinalMarksByStudentId(student_id);
        }

        public void MotivateAbsence(string absence_id, bool isMotivated)
        {
            teacherDAL.MotivateAbsence(absence_id, isMotivated);
        }
    }
}
