using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Machines
    {
        public int Id_Client { get; set; }
        public int Id_User { get; set; }
        public string Reparation { get; set; }
        public int Id_Machine { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Elements { get; set; }
        public string Picture { get; set; } //base64
        public string Failure { get; set; }
        public bool isApproved {get;set;}
        public bool isReviewed{get;set;}
        public bool isPossibleToRepair {get;set;}
        public int Hours { get; set; }
    }
}
