using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ReporteMaquinas
    {
        public string Cliente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int ID_Maquina { get; set; }
        public string Descripcion { get; set; }
        public string Falla { get; set; }
    }
}
