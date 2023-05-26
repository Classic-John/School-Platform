using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class ExtendedStudentGradeUI
    {
        public ExtendedStudentGradeUI(StudentGradeUI studentGradeUI, string status)
        {
            NrCRT = studentGradeUI.NrCRT;
            Name = studentGradeUI.Name;
            Mark = studentGradeUI.Mark;
            Status = status;
        }

        private string nrCRT;

        public string NrCRT
        {
            get { return nrCRT; }
            set { nrCRT = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private float mark;

        public float Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }



    }
}
