using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Grade
    {
        public Grade()
        {

        }

        private string markID;

        public string MarkID
        {
            get { return markID; }
            set { markID = value; }
        }

        private string studentSubjectID;

        public string StudentSubjectID
        {
            get { return studentSubjectID; }
            set { studentSubjectID = value; }
        }

        private float mark;
        public float Mark
        {
            get { return mark; }
            set { mark = value; }
        }
    }
}
