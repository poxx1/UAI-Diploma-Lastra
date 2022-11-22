using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Models.DBModel;

namespace View
{
    public partial class frmControlCambios : Form
    {
        public frmControlCambios()
        {

            DigitoVerificadorService ds = new DigitoVerificadorService();
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds.ListarControlCambios();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DigitoVerificadorService ds = new DigitoVerificadorService();
            ds.recuperarUsuario((DBUsers)dataGridView1.SelectedCells);
            //Current item o como verga sea
        }
    }
}
