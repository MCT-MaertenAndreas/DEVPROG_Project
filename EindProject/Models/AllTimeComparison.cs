using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    public class AllTimeComparison
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }

        public AllTimeComparison(string a1, string a2, string a3)
        {
            this.A1 = a1;
            this.A2 = a2;
            this.A3 = a3;
        }
    }
}
