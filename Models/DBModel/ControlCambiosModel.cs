using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModel
{
    public class ControlCambiosModel
    {
        public int id_change { get; set; }
        public string change_date { get; set; }
        public string change_data { get; set; }
        public string change_userAffected { get; set; }
    }
}