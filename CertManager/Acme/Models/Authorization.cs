using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertManager.Acme.Models
{
    public class Authorization
    {
        public string Status { get; set; }

        public DateTime Expires { get; set; }

        public Identifier Identifier { get; set; }

        public Challenge[] Challenges { get; set; } 

        public int[][] Combinations { get; set; } 
    }
}
