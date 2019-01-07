using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaratePortal.Models.PersonKarate
{
    public class BranchChief : Coach
    {
        private string nationalRole;
        public string NationalRole
        {
            get { return nationalRole; }
            set
            {
                if ((value == string.Empty) || (value == null))
                    nationalRole = "Empty";
                else
                    nationalRole = value;
            }
        }
        private string nameBranch;
        public string NameBranch
        {
            get { return nameBranch; }
            set
            {
                if ((value == string.Empty) || (value == null))
                    nameBranch = "Empty";
                else
                    nameBranch = value;
            }
        }
    }
}