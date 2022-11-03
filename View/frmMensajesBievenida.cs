using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utiles;

namespace View
{
    public partial class frmMensajesBievenida : Form
    {
        public frmMensajesBievenida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Busca el archivo Json que queres leer";
            openFileDialog1.InitialDirectory = @"\D:\Diploma-Lastra\Extras";
            var text = openFileDialog1.ShowDialog();
            //var texto = openFileDialog1.OpenFile();   
            //el path boludo
            JsonWork jw = new JsonWork();
            comboBox1.DataSource = null;
            comboBox1.DataSource = jw.DeserializarMensaje(jw.ReadJson(openFileDialog1.FileName));
            comboBox1.DisplayMember = "mensaje";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = @"\D:\Diploma-Lastra\Extras";
            var result = saveFileDialog1.ShowDialog();
            saveFileDialog1.Dispose();
        }
    }
}
