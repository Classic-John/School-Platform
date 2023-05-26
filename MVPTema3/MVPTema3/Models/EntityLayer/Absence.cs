using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Absence
    {
        public Absence()
        {

        }

        private string absence_id;

        public string Absence_id
        {
            get { return absence_id; }
            set { absence_id = value; }
        }

        private string studentSubjectID;

        public string StudentSubjectID
        {
            get { return studentSubjectID; }
            set { studentSubjectID = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string teacherID;

        public string TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        private bool isMotivated;

        public bool IsMotivated
        {
            get { return isMotivated; }
            set { isMotivated = value; }
        }
    }
}
