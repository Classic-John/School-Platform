using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.EntityLayer
{
    class Class
    {
        public Class()
        {

        }

        private string class_id;

        public string Class_ID
        {
            get { return class_id; }
            set { class_id = value; }
        }

        private string specialization_id;

        public string Specialization_ID
        {
            get { return specialization_id; }
            set { specialization_id = value; }
        }

        private string head_teacher_id;

        public string Head_Teacher_ID
        {
            get { return head_teacher_id; }
            set { head_teacher_id = value; }
        }

        private char name;

        public char Name
        {
            get { return name; }
            set { name = value; }
        }

        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

    }
}
