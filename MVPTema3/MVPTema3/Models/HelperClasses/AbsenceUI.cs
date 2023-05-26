using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.HelperClasses
{
    class AbsenceUI
    {
        public AbsenceUI(string nrcrt, bool isMotivated, DateTime date, string subject)
        {
            Nrcrt = nrcrt;
            IsMotivated = isMotivated;
            Date = date;
            Subject = subject;
        }
        private string nrcrt;

        public string Nrcrt
        {
            get { return nrcrt; }
            set { nrcrt = value; }
        }

        private bool isMotivated;

        public bool IsMotivated
        {
            get { return isMotivated; }
            set { isMotivated = value; }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string subject;
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

    }
}
