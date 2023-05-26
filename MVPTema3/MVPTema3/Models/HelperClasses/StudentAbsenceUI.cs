using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class StudentAbsenceUI
    {
        public StudentAbsenceUI(string nrCrt, string name, string surname, int absences)
        {
            NrCrt = nrCrt;
            Name = name;
            Surname = surname;
            Absences = absences;
        }

        private string nrCrt;

        public string NrCrt
        {
            get { return nrCrt; }
            set { nrCrt = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private int absences;

        public int Absences
        {
            get { return absences; }
            set { absences = value; }
        }

    }
}
