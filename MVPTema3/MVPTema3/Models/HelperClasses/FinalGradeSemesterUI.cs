using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class FinalGradeSemesterUI
    {
        public FinalGradeSemesterUI(StudentGradeUI studentGradeUI, int semester, string subjectName)
        {
            NrCRT = studentGradeUI.NrCRT;
            Name = studentGradeUI.Name;
            Mark = studentGradeUI.Mark;
            Semester = semester;
            SubjectName = subjectName;
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

        private string subjectName;

        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        private float mark;

        public float Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        private int semester;
        public int Semester
        {
            get { return semester; }
            set { semester = value; }
        }
    }
}
