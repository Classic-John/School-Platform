using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class StudentGradeUI
    {

        public StudentGradeUI(string nrCrt, string name, float mark)
        {
            NrCRT = nrCrt;
            Name = name;
            Mark = mark;
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


    }
}
