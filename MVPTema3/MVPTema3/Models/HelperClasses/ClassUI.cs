using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class ClassUI
    {
        public ClassUI(string nrCrt, string specialization, int number, char name, string headTeacher, string year)
        {
            NrCrt = nrCrt;
            Specialization = specialization;
            Name = name;
            Number = number;
            HeadTeacher = headTeacher;
            Year = year;
        }
        
        public ClassUI()
        {

        }

        private string nrCrt;

        public string NrCrt
        {
            get { return nrCrt; }
            set { nrCrt = value; }
        }

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private char name;

        public char Name
        {
            get { return name; }
            set { name = value; }
        }

        

        private string headTeacher;

        public string HeadTeacher
        {
            get { return headTeacher; }
            set { headTeacher = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
