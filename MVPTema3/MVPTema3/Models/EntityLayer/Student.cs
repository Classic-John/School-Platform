using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Student: User
    {
        public Student(): base()
        {
            
        }

        private string classID;

        public string ClassID
        {
            get { return classID; }
            set { classID = value; }
        }

        private string studentSubjectID;

        public string StudentSubjectID
        {
            get { return studentSubjectID; }
            set { studentSubjectID = value; }
        }

        private string specializationID;

        public string SpecializationID
        {
            get { return specializationID; }
            set { specializationID = value; }
        }

    }
}
