using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Teacher: User
    {
        public Teacher() : base()
        {

        }

        private bool isHeadTeacher;

        public bool IsHeadTeacher
        {
            get { return isHeadTeacher; }
            set { isHeadTeacher = value; }
        }

        private string teacherSubjectID;

        public string TeacherSubjectID
        {
            get { return teacherSubjectID; }
            set { teacherSubjectID = value; }
        }
    }
}
