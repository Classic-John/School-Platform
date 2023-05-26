using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Subject // Course
    {
        public Subject()
        {

        }

        private string subject_id;

        public string Subject_Id
        {
            get { return subject_id; }
            set { subject_id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string specialization_id;

        public string Specialization_id
        {
            get { return specialization_id; }
            set { specialization_id = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
