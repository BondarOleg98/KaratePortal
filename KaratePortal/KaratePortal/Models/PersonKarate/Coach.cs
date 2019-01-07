using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class Coach : KaratePerson
    {
        private string jadgeCategoty;
        public string JadgeCategory
        {
            get { return jadgeCategoty; }
            set
            {
                if ((value==string.Empty)||(value==null))
                {
                    jadgeCategoty = "Empty";
                }
                else
                {
                    jadgeCategoty = value;
                }
            }
        }
        private string rank;
        public string Rank
        {
            get { return rank; }
            set
            {
                if ((value==string.Empty)||(value==null))
                {
                    rank = "Empty";
                }
                else
                {
                    rank = value;
                }
            }
        }
        private int yearStartTrainer;
 
        public int YearStartTrainer
        {
            get { return yearStartTrainer; }
            set
            {
                if (value < 0)
                {
                    yearStartTrainer = 1963;
                }
                else if (value > 2018)
                {
                    yearStartTrainer = DateTime.Now.Year;
                }
                else
                {
                    yearStartTrainer = value;
                }
            }
        }
        private int countsStudent;
        public int CountsStudent
        {
            get { return countsStudent; }
            set
            {
                if (value < 0)
                {
                    countsStudent = 0;
                }
                else
                {
                    countsStudent = value;
                }
            }
        }
        public int CountPeople(int[] selectedStudents)
        {
            if (selectedStudents == null)
            {
                return 0;
            }
            return selectedStudents.Count();
        }

        public virtual ICollection<KarateStudent> KarateStudents { get; set; }

        public Coach()
        {
            KarateStudents = new List<KarateStudent>();
        }
    }
}