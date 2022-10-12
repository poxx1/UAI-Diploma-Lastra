using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace View
{
    public partial class StockView : Form
    {
        public StockView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StockModel stock = new StockModel();
        
        }
    }
}
