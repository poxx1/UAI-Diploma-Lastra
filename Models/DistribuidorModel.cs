using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DistribuidorModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double CotizacionDolar { get; set; }
        public List<StockModel> stockList { get; set; }
        public bool isActive { get; set; }
    }
}
