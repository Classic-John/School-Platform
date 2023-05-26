using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace MVPTema3.Models.DataAccessLayer
{
    class StudentDAL
    {
        public ObservableCollection<Student> GetAllStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Student> result = new ObservableCollection<Student>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    string convert = "";
                    convert += reader.GetInt32(0);
                    student.UserID = convert;
                    convert = "";
                    UserBLL userBLL = new UserBLL();
                    foreach (User user in userBLL.GetAllUsers())
                    {
                        if (user.UserID.Equals(student.UserID))
                        {
                            student.Name = user.Name;
                            student.Surname = user.Surname;
                            student.Password = user.Password;
                            break;
                        }
                    }
                    convert += reader.GetInt32(1);
                    student.ClassID = convert;
                    convert = "" + reader.GetInt32(2);
                    student.StudentSubjectID = convert;
                    convert = "" + reader.GetInt32(3);
                    student.SpecializationID = convert;
                    result.Add(student);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddStudent(User user, Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter("@name", user.Name);
                SqlParameter surname = new SqlParameter("@surname", user.Surname);
                SqlParameter password = new SqlParameter("@password", user.Password);

                SqlParameter user_id = new SqlParameter("@user_id", Convert.ToInt32(student.UserID));
                SqlParameter class_id = new SqlParameter("@class_id", Convert.ToInt32(student.ClassID));
                SqlParameter student_subject_id = new SqlParameter("@student_subject_id", Convert.ToInt32(student.StudentSubjectID));
                SqlParameter specialization_id = new SqlParameter("@specialization_id", Convert.ToInt32(student.SpecializationID));

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(surname);
                cmd.Parameters.Add(password);

                cmd.Parameters.Add(user_id);
                cmd.Parameters.Add(class_id);
                cmd.Parameters.Add(student_subject_id);
                cmd.Parameters.Add(specialization_id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /*public void DeleteStudent(Student persoana)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@id", persoana.UserID);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }*/

        public void UpdateStudent(User user, Student student)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter("@name", user.Name);
                SqlParameter surname = new SqlParameter("@surname", user.Surname);
                SqlParameter password = new SqlParameter("@password", user.Password);

                SqlParameter user_id = new SqlParameter("@user_id", Convert.ToInt32(student.UserID));
                SqlParameter class_id = new SqlParameter("@class_id", Convert.ToInt32(student.ClassID));
                SqlParameter student_subject_id = new SqlParameter("@student_subject_id", Convert.ToInt32(student.StudentSubjectID));
                SqlParameter specialization_id = new SqlParameter("@specialization_id", Convert.ToInt32(student.SpecializationID));

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(surname);
                cmd.Parameters.Add(password);

                cmd.Parameters.Add(user_id);
                cmd.Parameters.Add(class_id);
                cmd.Parameters.Add(student_subject_id);
                cmd.Parameters.Add(specialization_id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public ObservableCollection<AbsenceUI> GetAbsencesByStudent(string studentID)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAbsencesByStudent", con);
                ObservableCollection<AbsenceUI> result = new ObservableCollection<AbsenceUI>();
                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = Convert.ToInt32(studentID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s1 = "" + (reader.GetInt32(0));
                    bool b1 = (bool)reader["isMotivated"];
                    DateTime d1 = (DateTime)reader["date"];
                    string s2 = reader.GetString(3);
                    result.Add(new AbsenceUI(s1,
                        b1,
                        d1,
                        s2));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }
        public ObservableCollection<GradeUI> GetGradesByStudent(string studentID)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetGradesByStudent", con);
                ObservableCollection<GradeUI> result = new ObservableCollection<GradeUI>();
                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = Convert.ToInt32(studentID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new GradeUI("" + reader.GetInt32(0), reader.GetString(1), (float)reader.GetDouble(2)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }

        public ObservableCollection<GradeUI> GetFinalGradesByStudent(string studentID)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetFinalGradesByStudent", con);
                ObservableCollection<GradeUI> result = new ObservableCollection<GradeUI>();
                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = Convert.ToInt32(studentID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new GradeUI("" + reader.GetInt32(0), reader.GetString(1), (float)reader.GetDouble(2)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }

        public ObservableCollection<Tuple<string, string, string>> GetStudentCourses(string studentID)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentSubjects", con);
                ObservableCollection<Tuple<string, string, string>> result = new ObservableCollection<Tuple<string, string, string>>();
                cmd.Parameters.Add("@student_id", SqlDbType.Int).Value = Convert.ToInt32(studentID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(Tuple.Create(reader.GetString(0), reader.GetString(1), reader.GetString(2)));
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }

        }

        public string GetSubjectBySpecialization(string specialization_id, string subjectName)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSubjectBySpecialization", con);
                if (specialization_id == null || specialization_id == "")
                {
                    specialization_id = "" + 1;
                }
                if(subjectName==null || subjectName =="")
                {
                    subjectName = "mate-info";
                }
                cmd.Parameters.AddWithValue("@specialization_id", Convert.ToInt32(specialization_id));
                cmd.Parameters.AddWithValue("@name", subjectName);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                reader.Close();
                return "";
            }
            finally
            {
                con.Close();
            }

        }
    }
}
