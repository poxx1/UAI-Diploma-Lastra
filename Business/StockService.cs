using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Models;

namespace Business
{
    public class StockService
    {
        public List<StockModel> listStock()
        {
            StockRepository sr = new StockRepository();
            return sr.listStock();
        }

        public bool addStock(StockModel item)
        {
            StockRepository sr = new StockRepository();
            return sr.addItem(item);
        }
    }
}
