using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVPTema3.Models.DataAccessLayer
{
    class TeacherDAL
    {
        #region GetData

        public string FindSubjectNameOfStudentSpecializationID(string student_subject_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("FindSubjectNameOfStudentSpecializationID", con);
                string result = "";
                cmd.Parameters.Add("@student_subject_id", SqlDbType.Int).Value = Convert.ToInt32(student_subject_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllTeachers", con);
                ObservableCollection<Teacher> result = new ObservableCollection<Teacher>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.UserID = ""+reader.GetInt32(0);

                    UserBLL userBLL = new UserBLL();
                    foreach (User user in userBLL.GetAllUsers())
                    {
                        if (user.UserID.Equals(teacher.UserID))
                        {
                            teacher.Name = user.Name;
                            teacher.Surname = user.Surname;
                            teacher.Password = user.Password;
                            break;
                        }
                    }

                    teacher.TeacherSubjectID = ""+reader.GetInt32(1);
                    teacher.IsHeadTeacher = (bool)reader["isHeadTeacher"];
                    result.Add(teacher);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public string GetSubjectNameByStudentSubjectId(string student_subject_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectNameByStudentSubjectId", con);
                string result = "";
                cmd.Parameters.Add("@student_subject_id", SqlDbType.Int).Value = Convert.ToInt32(student_subject_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }
        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacher(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsenteesByTeacher", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = Convert.ToInt32(teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string convert = "";
                string convert1 = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    convert1 = "" + reader.GetInt32(3);
                    result.Add(new AbsenceUI(convert, (bool)reader["isMotivated"], (DateTime)reader["date"],
                        GetSubjectNameByStudentSubjectId(convert1)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<GradeUI> GetGradesByTeacher(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetGradesByTeacher", con);
                ObservableCollection<GradeUI> result = new ObservableCollection<GradeUI>();
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = Convert.ToInt32(teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string convert = "";
                string convert1 = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    convert1 = "" + reader.GetInt32(1);
                    result.Add(new GradeUI(convert, convert1, (float)reader.GetDouble(2)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<GradeUI> GetFinalGradesByTeacher(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetFinalGradesByTeacher", con);
                ObservableCollection<GradeUI> result = new ObservableCollection<GradeUI>();
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = Convert.ToInt32(teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new GradeUI(""+reader.GetInt32(0), ""+reader.GetInt32(1), (float)reader.GetDouble(2)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Subject> GetCoursesByTeacher(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetTeacherCourses", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = Convert.ToInt32(teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subject subject = new Subject();
                    subject.Subject_Id =""+ reader.GetInt32(0);
                    subject.Name = reader.GetString(1);
                    subject.Specialization_id =""+ reader.GetInt32(2);
                    subject.Path = reader.GetString(3);
                    result.Add(subject);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion GetData

        #region SaveChanges
        public void SaveGradesChanges(ObservableCollection<GradeUI> grades, string teacher_id, bool isFinalGrade)
        {
            SqlConnection con = DALHelper.Connection;
            foreach (GradeUI newGrade in grades)
            {
                // search if in BD is a grade with same id                 
                try
                {
                    SqlCommand cmd;
                    if (!isFinalGrade)
                        cmd = new SqlCommand("SelectGradeWithID", con);
                    else
                        cmd = new SqlCommand("SelectFinalGradeWithID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter id = new SqlParameter("@grade_id", Convert.ToInt32(newGrade.Nrcrt));
                    cmd.Parameters.Add(id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Grade grade = new Grade();
                    grade.MarkID = "-1";
                    string convert = "";
                    while (reader.Read())
                    {
                        convert = "" + reader.GetInt32(0);
                        grade.MarkID = convert;
                        convert = "" + reader.GetInt32(1);
                        grade.StudentSubjectID = convert;
                        grade.Mark = (float)reader.GetDouble(2);
                    }
                    if (grade.MarkID != "-1")
                    {

                        if (newGrade.Grade == grade.Mark)
                        {
                            // grade is the same -> nothing to do
                            Console.WriteLine("ONE GRADE IS THE SAME");
                        }
                        else
                        {
                            Console.WriteLine("UPDATE ONE GRADE");

                            // to update grade
                            SqlCommand cmd2;
                            if (!isFinalGrade)
                                cmd2 = new SqlCommand("UpdateGrade", con);
                            else
                                cmd2 = new SqlCommand("UpdateFinalGrade", con);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter mark_id = new SqlParameter("@mark_id", Convert.ToInt32(newGrade.Nrcrt));
                            SqlParameter param_grade = new SqlParameter("@grade", newGrade.Grade);
                            SqlParameter param_teacher_id = new SqlParameter("@teacher_id", Convert.ToInt32(teacher_id));

                            cmd2.Parameters.Add(mark_id);
                            cmd2.Parameters.Add(param_grade);
                            cmd2.Parameters.Add(param_teacher_id);
                            con.Close();
                            con.Open();
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        try
                        {
                            Console.WriteLine("INSERT ONE GRADE");

                            //to insert
                            SqlCommand cmd3;
                            if (!isFinalGrade)
                                cmd3 = new SqlCommand("InsertNewGrade", con);
                            else
                                cmd3 = new SqlCommand("InsertNewFinalGrade", con);
                            cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                            if (newGrade.Grade <= 1 || newGrade.Grade > 10)
                            {
                                throw new Exception("Invalid mark");
                            }

                            SqlParameter mark_id = new SqlParameter("@mark_id", Convert.ToInt32(newGrade.Nrcrt));
                            SqlParameter param_grade = new SqlParameter("@grade", newGrade.Grade);
                            SqlParameter param_teacher_id = new SqlParameter("@teacher_id", Convert.ToInt32(teacher_id));

                            cmd3.Parameters.Add(mark_id);
                            cmd3.Parameters.Add(param_grade);
                            cmd3.Parameters.Add(param_teacher_id);
                            con.Close();
                            con.Open();
                            cmd3.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Invalid " + newGrade.Grade + " values!");
                        }

                    }
                    reader.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void SaveCoursesChanges(ObservableCollection<Subject> subjects, string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            foreach (Subject newCourse in subjects)
            {
                // search if in BD is a course with same id                 
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectTeacherCourseWithID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter teacher_id_param = new SqlParameter("@teacher_id", Convert.ToInt32(teacher_id));
                    SqlParameter course_id = new SqlParameter("@course_id", Convert.ToInt32(newCourse.Subject_Id));
                    cmd.Parameters.Add(teacher_id_param);
                    cmd.Parameters.Add(course_id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Subject subject = new Subject();
                    subject.Subject_Id = "-1";
                    string convert = "";
                    while (reader.Read())
                    {
                        convert = "" + reader.GetInt32(0);
                        subject.Subject_Id = convert;
                        subject.Name = reader.GetString(1);
                        convert = "" + reader.GetInt32(2);
                        subject.Specialization_id = convert;
                        subject.Path = reader.GetString(3);
                    }
                    if (subject.Subject_Id != "-1")
                    {

                        if (newCourse.Name.Equals(subject.Name) && newCourse.Specialization_id.Equals(subject.Specialization_id) && newCourse.Path.Equals(subject.Path))
                        {
                            Console.WriteLine("ONE COURSE IS THE SAME");
                        }
                        else
                        {

                            SqlCommand cmd2;
                            cmd2 = new SqlCommand("UpdateCourse", con);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter subject_id = new SqlParameter("@subject_id", Convert.ToInt32(newCourse.Subject_Id));
                            SqlParameter name = new SqlParameter("@name", newCourse.Name);
                            SqlParameter specialization_ID = new SqlParameter("@specialization_ID", Convert.ToInt32(newCourse.Specialization_id));
                            SqlParameter path = new SqlParameter("@path", newCourse.Path);

                            cmd2.Parameters.Add(subject_id);
                            cmd2.Parameters.Add(name);
                            cmd2.Parameters.Add(specialization_ID);
                            cmd2.Parameters.Add(path);
                            con.Close();
                            con.Open();
                            cmd2.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        try
                        {
                            SqlCommand cmd4 = new SqlCommand("InsertNewCourse", con);
                            cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter name = new SqlParameter("@name", newCourse.Name);
                            SqlParameter path = new SqlParameter("@path", newCourse.Path);
                            SqlParameter specialization_id = new SqlParameter("@specialization_id", newCourse.Specialization_id);
                            SqlParameter subject_id2 = new SqlParameter("@subject_id", newCourse.Subject_Id);

                            cmd4.Parameters.Add(subject_id2);
                            cmd4.Parameters.Add(name);
                            cmd4.Parameters.Add(path);
                            cmd4.Parameters.Add(specialization_id);
                            con.Close();
                            con.Open();
                            cmd4.ExecuteNonQuery();
                        }
                        catch (SqlException exception)
                        {
                            MessageBox.Show("Invalid " + newCourse.Subject_Id + " values!");
                        }

                    }
                    reader.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DeleteCourse(string grade_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter id = new SqlParameter("@grade_id", Convert.ToInt32(grade_id));
                cmd.Parameters.Add(id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                con.Close();
            }
        }

        #endregion SaveChanges

        #region HeadTeacher

        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacherClass(string class_id, string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsenteesByTeacherClass", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    result.Add(new AbsenceUI(index + "", (bool)reader["isMotivated"], (DateTime)reader["date"],
                        FindSubjectNameOfStudentSpecializationID(convert)));
                    index++;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public string FindClassOfHeadTeacher(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("FindClassOfHeadTeacher", con);
                string result = "";
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string convert = "";
                while (reader.Read())
                {
                    convert=""+reader.GetInt32(0);
                    result = convert;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<AbsenceUI> GetUnmotivatedAbsenteesByTeacherClass(string class_id, string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsenteesByTeacherClass", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    if (((bool)reader["isMotivated"]) == false)
                    {
                        convert = "" + reader.GetInt32(0);
                        result.Add(new AbsenceUI(index + "", false, (DateTime)reader["date"],
                          FindSubjectNameOfStudentSpecializationID(convert)));
                        index++;
                    }
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<AbsenceUI> GetAbsenteesByTeacherClassForStudentID(string class_id, string teacher_id, string student_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsenteesByTeacherClassForStudentID", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                if(class_id == null || class_id=="")
                {
                    class_id = "" + 1;
                }
                if(student_id==null ||student_id=="")
                {
                    student_id = "" + 1;
                }
                cmd.Parameters.AddWithValue("@class_id", class_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    result.Add(new AbsenceUI(index + "", (bool)reader["isMotivated"], (DateTime)reader["date"],
                        FindSubjectNameOfStudentSpecializationID(convert)));
                    index++;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<AbsenceUI> GetUnmotivatedAbsenteesByTeacherClassForStudentID(string class_id, string teacher_id, string student_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsenteesByTeacherClassForStudentID", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                cmd.Parameters.AddWithValue("@class_id",class_id);
                cmd.Parameters.AddWithValue("@teacher_id", teacher_id);
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    if (((bool)reader["isMotivated"]) == false)
                    {
                        convert = "" + reader.GetInt32(0);
                        result.Add(new AbsenceUI(index + "", false, (DateTime)reader["date"],
                          FindSubjectNameOfStudentSpecializationID(convert)));
                        index++;
                    }
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }


        public ObservableCollection<StudentGradeUI> GetClassFinalMarks(string class_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClassFinalMarks", con);
                ObservableCollection<StudentGradeUI> result = new ObservableCollection<StudentGradeUI>();
                cmd.Parameters.AddWithValue("@class_id",class_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    result.Add(new StudentGradeUI(index + "", convert, (float)reader.GetDouble(1)));
                    index++;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<ExtendedStudentGradeUI> GetClassFinalMarksWithStatus(string class_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetClassFinalMarks", con);
                ObservableCollection<ExtendedStudentGradeUI> result = new ObservableCollection<ExtendedStudentGradeUI>();
                cmd.Parameters.AddWithValue("@class_id",class_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                string convert = "";
                while (reader.Read())
                {
                    convert = "" + reader.GetInt32(0);
                    float mark = (float)reader.GetDouble(1);
                    StudentGradeUI first = new StudentGradeUI(index + "", convert, mark);
                    string second = "";
                    if (mark >= 5)
                    {
                        if (index == 1) second = "1st Prize";
                        if (index == 2) second = "2nd Prize";
                        if (index == 3) second = "3rd Prize";
                        if (index == 4) second = "Mention";
                    }
                    else
                    {
                        second = "Conditioned";
                    }
                    result.Add(new ExtendedStudentGradeUI(first, second));
                    index++;
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }


        public ObservableCollection<StudentAbsenceUI> GetExpatriateStudents(string class_id, string teacher_id)
        {
            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<StudentAbsenceUI> result = new ObservableCollection<StudentAbsenceUI>();

            int index = 1;
            foreach (Student student in studentBLL.GetAllStudents())
            {
                if (student.ClassID != class_id)
                    continue;
                ObservableCollection<AbsenceUI> outputForCurrentStudent = GetAbsenteesByTeacherClassForStudentID(class_id, teacher_id, student.UserID);
                if (outputForCurrentStudent.Count >= Convert.ToInt32(ConfigurationManager.AppSettings["maximumAbsences"]))
                {
                    result.Add(new StudentAbsenceUI(index + "", student.Name, student.Password, outputForCurrentStudent.Count));
                    index++;
                }
            }
            return result;
        }

        public ObservableCollection<FinalGradeSemesterUI> GetStudentFinalMarksByStudentId(string student_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentFinalMarksByStudentId", con);
                ObservableCollection<FinalGradeSemesterUI> result = new ObservableCollection<FinalGradeSemesterUI>();
                cmd.Parameters.AddWithValue("@student_id", student_id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int index = 1;
                while (reader.Read())
                {
                    result.Add(new FinalGradeSemesterUI(new StudentGradeUI(index + "", reader.GetString(0), (float)reader.GetDouble(1))
                      , reader.GetInt32(2), reader.GetString(3)));
                    index++;

                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void MotivateAbsence(string absence_id, bool is_motivated)
        {
            SqlConnection con = DALHelper.Connection;
            SqlCommand cmd2;
            cmd2 = new SqlCommand("UpdateAbsence", con);
            cmd2.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter absenceId = new SqlParameter("@absence_id", Convert.ToInt32(absence_id));
            SqlParameter isMotivated = new SqlParameter("@is_motivated", Convert.ToInt32(is_motivated));
            cmd2.Parameters.Add(absenceId);
            cmd2.Parameters.Add(isMotivated);

            con.Close();
            con.Open();
            cmd2.ExecuteNonQuery();
        }

        #endregion HeadTeacher

    }
}
