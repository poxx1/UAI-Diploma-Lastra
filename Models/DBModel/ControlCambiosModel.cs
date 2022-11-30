using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModel
{
    public class ControlCambiosModel
    {
        public int ID_Cambio { get; set; }
        public string Fecha { get; set; }
        public string DigitoVerificador { get; set; }
        public string Usuario_Afectado { get; set; }
    }
}