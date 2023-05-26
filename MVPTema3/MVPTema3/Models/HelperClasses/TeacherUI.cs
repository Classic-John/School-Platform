using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class TeacherUI
    {
        public TeacherUI(string nrCrt, string name, string surname, bool isHeadTeacher, string subjects,string classes)
        {
            NrCrt = nrCrt;
            Name = name;
            Surname = surname;
            IsHeadTeacher = isHeadTeacher;
            Subjects = subjects;
            Classes = classes;
        }


        public TeacherUI()
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

        private bool isHeadTeacher;

        public bool IsHeadTeacher
        {
            get { return isHeadTeacher; }
            set { isHeadTeacher = value; }
        }

        public string classes;
        public string Classes
        {
            get { return classes; }
            set { classes = value; }
        }

        public string subjects;
        public string Subjects
        {
            get { return subjects; }
            set { subjects = value; }
        }
    }
}
