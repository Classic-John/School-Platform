using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class GradeUI
    {
        public GradeUI(string nrcrt, string subject, float grade)
        {
            Nrcrt = nrcrt;
            Subject = subject;
            Grade = grade;
        }

        private string nrcrt;

        public string Nrcrt
        {
            get { return nrcrt; }
            set { nrcrt = value; }
        }

        private string subject;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        private float grade;

        public float Grade
        {
            get { return grade; }
            set { grade = value; }
        }


    }
}
