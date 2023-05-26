using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class StudentUI
    {

        public StudentUI(string nrCrt, string name, string surname, string specialization, string classDetails, string year)
        {
            NrCrt = nrCrt;
            Name = name;
            Surname = surname;
            Specialization = specialization;
            ClassDetails= classDetails;
            Year=year;
        }


        public StudentUI()
        {

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

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        private string classDetails;

        public string ClassDetails
        {
            get { return classDetails; }
            set { classDetails = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
    }
}
