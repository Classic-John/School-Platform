using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class CourseUI
    {
        public CourseUI(string nrCrt, string name, string specialization, string path)
        {
            NrCrt = nrCrt;
            Name = name;
            Specialization = specialization;
            Path = path;
        }

        public CourseUI()
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

        private string specialization;

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
