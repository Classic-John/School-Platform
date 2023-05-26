using MVPTema3.Models.BussinessLogicLayer;
using MVPTema3.Models.EntityLayer;
using MVPTema3.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVPTema3.Models.DataAccessLayer
{
    class AdminDAL
    {
        #region GetData
        public ObservableCollection<Admin> GetAllAdmins()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAdmins", con);
                ObservableCollection<Admin> result = new ObservableCollection<Admin>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin admin = new Admin();
                    admin.UserID = "" + reader.GetInt32(0);

                    UserBLL userBLL = new UserBLL();
                    foreach (User user in userBLL.GetAllUsers())
                    {
                        if (user.UserID.Equals(admin.UserID))
                        {
                            admin.Name = user.Name;
                            admin.Surname = user.Surname;
                            admin.Password = user.Password;
                            break;
                        }
                    }
                    result.Add(admin);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Class> GetAllClasses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Class new_class = new Class();
                    new_class.Class_ID = "" + reader.GetInt32(0);
                    new_class.Specialization_ID = "" + reader.GetInt32(1);
                    new_class.Head_Teacher_ID = "" + reader.GetInt32(2);
                    new_class.Name = reader.GetString(3).ToCharArray()[0];
                    new_class.Number = reader.GetInt32(4);
                    new_class.Year = "" + reader.GetInt32(5);
                    result.Add(new_class);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public string GetStudentSpecializationName(string specialization_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentSpecializationName", con);
                SqlParameter specialization = new SqlParameter("@specialization_id", Convert.ToInt32(specialization_id));
                cmd.Parameters.Add(specialization);
                string result = "";
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

        public string GetTeacherClasses(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetTeacherClasses", con);
                SqlParameter teacher = new SqlParameter("@teacher_id", Convert.ToInt32(teacher_id));
                cmd.Parameters.Add(teacher);
                string result = "";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result += reader.GetInt32(1) + reader.GetString(0) + " ";
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public string GetTeacherCourses(string teacher_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetTeacherCourses", con);
                SqlParameter teacher = new SqlParameter("@teacher_id", Convert.ToInt32(teacher_id));
                cmd.Parameters.Add(teacher);
                string result = "";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result += reader.GetInt32(0) + " ";
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<StudentUI> GetAllStudents()
        {
            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<Student> students = studentBLL.GetAllStudents();
            ObservableCollection<Class> classes = GetAllClasses();
            ObservableCollection<StudentUI> studentUIs = new ObservableCollection<StudentUI>();

            int index = 1;
            foreach (Student student in students)
            {
                Class student_class = classes[(classes.IndexOf(classes.Where(X => X.Class_ID == student.ClassID).FirstOrDefault()))];

                string specialization = GetStudentSpecializationName(student.SpecializationID);

                StudentUI studentUI = new StudentUI(index + "", student.Name, student.Surname, specialization,
                    student_class.Number + "" + student_class.Name, student_class.Year);
                studentUIs.Add(studentUI);
                index++;

            }
            return studentUIs;
        }

        public string GetStudentIdByStudentUI(int i)
        {
            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<Student> students = studentBLL.GetAllStudents();

            int index = 1;
            foreach (Student student in students)
            {
                if (i == index)
                    return student.UserID;
                index++;

            }
            return "";
        }

        public string GetTeacherIdByTeacherUI(int i)
        {
            TeacherBLL teacherBLL = new TeacherBLL();
            ObservableCollection<Teacher> teachers = teacherBLL.GetAllTeachers();

            int index = 1;
            foreach (Teacher teacher in teachers)
            {
                if (i == index)
                    return teacher.UserID;
                index++;

            }
            return "";
        }

        public string GetStudentById(string id)
        {
            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<Student> students = studentBLL.GetAllStudents();
            ObservableCollection<Class> classes = GetAllClasses();
            ObservableCollection<StudentUI> studentUIs = new ObservableCollection<StudentUI>();

            int index = 1;
            foreach (Student student in students)
            {
                if (index == Convert.ToInt32(id))
                {
                    return student.UserID;
                }
                index++;

            }
            return "";
        }

        public ObservableCollection<TeacherUI> GetAllTeachers()
        {
            TeacherBLL teacherBLL = new TeacherBLL();
            ObservableCollection<Teacher> teachers = teacherBLL.GetAllTeachers();
            ObservableCollection<TeacherUI> teacherUIs = new ObservableCollection<TeacherUI>();

            int index = 1;
            foreach (Teacher teacher in teachers)
            {
                string teacher_classes = GetTeacherClasses(teacher.UserID);
                string teacher_courses = GetTeacherCourses(teacher.UserID);

                TeacherUI teacherUI = new TeacherUI(index + "", teacher.Name, teacher.Surname, teacher.IsHeadTeacher, teacher_courses, teacher_classes);
                teacherUIs.Add(teacherUI);
                index++;

            }
            return teacherUIs;
        }

        public string GetTeacherById(string id)
        {
            TeacherBLL teacherBLL = new TeacherBLL();
            ObservableCollection<Teacher> teachers = teacherBLL.GetAllTeachers();
            ObservableCollection<TeacherUI> teacherUIs = new ObservableCollection<TeacherUI>();

            int index = 51;
            foreach (Teacher teacher in teachers)
            {
                if (index == Convert.ToInt32(id))
                {
                    return teacher.UserID;
                }
                index++;

            }
            return "";
        }

        public ObservableCollection<ClassUI> GetAllClassesUI()
        {
            ObservableCollection<ClassUI> classesUIs = new ObservableCollection<ClassUI>();
            ObservableCollection<Class> classes = GetAllClasses();
            int index = 1;
            foreach (Class new_class in classes)
            {
                ClassUI classUI = new ClassUI(index + "", GetSpecializationName(new_class.Specialization_ID), new_class.Number,
                    new_class.Name, new_class.Head_Teacher_ID, new_class.Year);
                classesUIs.Add(classUI);
                index++;
            }

            return classesUIs;
        }


        public string FindClassUI(int id)
        {
            ObservableCollection<ClassUI> classesUIs = new ObservableCollection<ClassUI>();
            ObservableCollection<Class> classes = GetAllClasses();
            int index = 1;
            foreach (Class new_class in classes)
            {
                if (index == id)
                    return new_class.Class_ID;
                index++;
            }

            return "";
        }
        public string GetSpecializationBySubjectID(string subject_id)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetSpecializationBySubjectID", con);
                string result = "";
                SqlParameter subject = new SqlParameter("@id", Convert.ToInt32(subject_id));
                cmd.Parameters.Add(subject);
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


        public string GetSpecializationIDByName(string name)
        {
            SqlConnection con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("GetSpecializationIDByName", con);
                SqlParameter subject = new SqlParameter("@name", name);
                cmd.Parameters.Add(subject);
                string result = "";
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

        public string GetCourseID(string i)
        {
            SqlConnection con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("GetAllCourses", con);
                int index = 1;
                string result = "";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (index == Convert.ToInt32(i))
                        result = "" + reader.GetInt32(0);
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


        public string GetSpecializationName(string id)
        {
            SqlConnection con = DALHelper.Connection;

            try
            {
                SqlCommand cmd = new SqlCommand("GetSpecializationName", con);
                string result = "";
                SqlParameter subject = new SqlParameter("@id", Convert.ToInt32(id));
                cmd.Parameters.Add(subject);
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

        public ObservableCollection<CourseUI> GetCourses()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllCourses", con);
                ObservableCollection<CourseUI> result = new ObservableCollection<CourseUI>();
                int index = 1;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CourseUI course = new CourseUI();
                    course.NrCrt = index + "";
                    course.Name = reader.GetString(1);
                    course.Specialization = GetSpecializationBySubjectID("" + reader.GetInt32(2));
                    course.Path = reader.GetString(3);
                    index++;
                    result.Add(course);
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

        #region ChangesForCourses
        public void SaveCoursesChanges(ObservableCollection<CourseUI> courseUIs)
        {
            SqlConnection con = DALHelper.Connection;
            foreach (CourseUI courseUI in courseUIs)
            {
                // search if in BD is a course with same ID
                try
                {
                    string subject_id_main = GetCourseID(courseUI.NrCrt);
                    string specialization_id = "";
                    SqlCommand cmd = new SqlCommand("GetSubjectByID", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int temp = 1;
                    if (subject_id_main == "")
                    {
                        subject_id_main = "" + temp;
                        if (temp == 5)
                        {
                            temp = 1;
                        }
                        temp++;
                    }
                    SqlParameter id = new SqlParameter("@subject_id", Convert.ToInt32(subject_id_main));
                    cmd.Parameters.Add(id);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    CourseUI course = new CourseUI();
                    course.NrCrt = "-1";
                    while (reader.Read())
                    {
                        course.NrCrt = "" + reader.GetInt32(0);
                        course.Name = reader.GetString(1);
                        course.Specialization = GetSpecializationBySubjectID("" + reader.GetInt32(2));
                        specialization_id = "" + reader.GetInt32(2);
                        course.Path = reader.GetString(3);
                    }
                    if (course.NrCrt != "-1")
                    {
                        if (courseUI.Name.Equals(course.Name) && courseUI.Specialization.Equals(course.Specialization) && courseUI.Path.Equals(course.Path))
                        {
                            //nothing to do
                        }
                        else
                        {
                            // to update course
                            SqlCommand cmd2;
                            cmd2 = new SqlCommand("UpdateCourse", con);
                            cmd2.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter subject_id = new SqlParameter("@subject_id", Convert.ToInt32(subject_id_main));
                            SqlParameter name = new SqlParameter("@name", courseUI.Name);

                            SqlParameter specialization_ID = new SqlParameter("@specialization_ID", Convert.ToInt32(specialization_id));
                            SqlParameter path = new SqlParameter("@path", courseUI.Path);

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
                            //to insert
                            SqlCommand cmd3;
                            cmd3 = new SqlCommand("InsertNewCourse", con);
                            cmd3.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter subject_id2 = new SqlParameter("@subject_id", Convert.ToInt32(courseUI.NrCrt));
                            SqlParameter name2 = new SqlParameter("@name", courseUI.Name);
                            SqlParameter specialization_ID2 = new SqlParameter("@specialization_ID", Convert.ToInt32(GetSpecializationIDByName(courseUI.Specialization)));
                            SqlParameter path2 = new SqlParameter("@path", courseUI.Path);

                            cmd3.Parameters.Add(subject_id2);
                            cmd3.Parameters.Add(name2);
                            cmd3.Parameters.Add(specialization_ID2);
                            cmd3.Parameters.Add(path2);
                            con.Close();
                            con.Open();
                            cmd3.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("Invalid " + courseUI.NrCrt + " values!");
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

        public void DeleteCourse(string course_id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteCourse", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (course_id == null || course_id == "")
                {
                    course_id = "" + 1;
                }
                SqlParameter paramIdPersoana = new SqlParameter("@grade_id", course_id);
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        #endregion ChangesForCourses

        #region ChangesForStudents

        public void DeleteStudent(string student_id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@student_id", GetStudentById(student_id));
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public User FindStudentId(Student student)
        {
            UserBLL user = new UserBLL();
            foreach (User u in user.GetAllUsers())
            {
                if (student.UserID.Equals(u.UserID))
                {
                    return u;
                }
            }
            return null;
        }

        public void SaveStudentChanges(ObservableCollection<StudentUI> allStudents)
        {
            StudentBLL studentBLL = new StudentBLL();
            ObservableCollection<Student> students = studentBLL.GetAllStudents();
            bool found;

            foreach (StudentUI studentUI in allStudents)
            {
                found = false;
                foreach (Student student in students)
                {

                    if (student.UserID == GetStudentIdByStudentUI(Convert.ToInt32(studentUI.NrCrt)))
                    {
                        User user = FindStudentId(student);
                        user.Name = studentUI.Name;
                        user.Surname = studentUI.Surname;
                        studentBLL.UpdateStudent(user, student);
                        found = true;
                    }
                }
                if (!found)
                {
                    Student student = new Student();
                    User user = new User();
                    UserBLL userBLL = new UserBLL();
                    user.UserID = userBLL.GetAllUsers().Count() + "";
                    user.Name = studentUI.Name;
                    user.Surname = studentUI.Surname;
                    //studentBLL.AddStudent(student as User, student);
                }
            }
        }

        #endregion ChangesForStudents

        #region ChangesForTeachers

        public void DeleteTeacher(string teacher_id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeacher", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (teacher_id == null || teacher_id == "")
                {
                    teacher_id = "" + 51;
                }
                SqlParameter paramIdPersoana = new SqlParameter("@teacher_id", Convert.ToInt32(GetTeacherById(teacher_id)));
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateTeacher(User user, Teacher teacher)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateTeacher", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter("@name", user.Name);
                SqlParameter surname = new SqlParameter("@surname", user.Surname);
                SqlParameter password = new SqlParameter("@password", user.Password);

                SqlParameter user_id = new SqlParameter("@user_id", Convert.ToInt32(teacher.UserID));
                SqlParameter is_head_teacher = new SqlParameter("@is_head_teacher", Convert.ToInt32(teacher.IsHeadTeacher));

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(surname);
                cmd.Parameters.Add(password);

                cmd.Parameters.Add(user_id);
                cmd.Parameters.Add(is_head_teacher);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void SaveTeacherChanges(ObservableCollection<TeacherUI> allTeachers)
        {
            TeacherBLL teacherBLL = new TeacherBLL();
            ObservableCollection<Teacher> teachers = teacherBLL.GetAllTeachers();
            bool found;

            foreach (TeacherUI teacherUI in allTeachers)
            {
                found = false;
                foreach (Teacher teacher in teachers)
                {

                    if (teacher.UserID.Equals(GetTeacherIdByTeacherUI(Convert.ToInt32(teacherUI.NrCrt))))
                    {
                        User user = FindTeacherId(teacher);
                        user.Name = teacherUI.Name;
                        user.Surname = teacherUI.Surname;
                        UpdateTeacher(user, teacher);
                        found = true;
                    }
                }
                if (!found)
                {
                    //studentBLL.AddStudent(student as User, student);
                }
            }
        }

        public User FindTeacherId(Teacher teacher)
        {
            UserBLL user = new UserBLL();
            foreach (User u in user.GetAllUsers())
            {
                if (teacher.UserID.Equals(u.UserID))
                {
                    return u;
                }
            }
            return null;
        }

        #endregion ChangesForTeachers

        #region ChangesForClasses

        public void DeleteClass(string class_id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdPersoana = new SqlParameter("@class_id", Convert.ToInt32(class_id));
                cmd.Parameters.Add(paramIdPersoana);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void SaveClassesChanges(ObservableCollection<ClassUI> allClasses)
        {
            ObservableCollection<ClassUI> clasees = GetAllClassesUI();
            bool found;

            foreach (ClassUI classUI in allClasses)
            {
                found = false;
                foreach (ClassUI class_ui in clasees)
                {

                    if (class_ui.NrCrt == classUI.NrCrt)
                    {
                        UpdateClass(classUI);
                        found = true;
                    }
                }
                if (!found)
                {
                    //studentBLL.AddStudent(student as User, student);
                }
            }
        }

        public void UpdateClass(ClassUI classUI)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("UpdateClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter name = new SqlParameter("@name", classUI.Name);
                SqlParameter id = new SqlParameter("@id", Convert.ToInt32(FindClassUI(Convert.ToInt32(classUI.NrCrt))));
                SqlParameter year = new SqlParameter("@year", Convert.ToInt32(classUI.Year));
                SqlParameter number = new SqlParameter("@number", Convert.ToInt32(classUI.Number));

                cmd.Parameters.Add(name);
                cmd.Parameters.Add(id);
                cmd.Parameters.Add(year);
                cmd.Parameters.Add(number);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }

        #endregion ChangesForClasses
    }
}
