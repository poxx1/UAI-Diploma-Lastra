using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModel
{
    public class DBUsers
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Key_idioma { get; set; }
        public int Tries { get; set; }
        public bool isBlocked { get; set; }
        public int id_tipo { get; set; }
        public int id_dv { get; set; } //Will be set after hashing.
        public string digitoVerificador { get; set; } //Will be set after hashing.
    }
}
