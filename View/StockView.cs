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

        private void StockView_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            StockService ss = new StockService();
            dataGridView1.DataSource = ss.listStock();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                StockModel item = new StockModel();
                item.Name = tbNombre.Text;
                item.Descripcion = tbDescripcion.Text;
                item.Quantity = Int32.Parse(tbCantidad.Text);

                if (item.Quantity > 0)
                {
                    StockService ss = new StockService();
                    if (ss.addStock(item)) MessageBox.Show("Agrega2");
                    else MessageBox.Show("No se pudo agregar, error en la consulta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La quedo: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                StockModel item = new StockModel();
                item.Name = tbNombre.Text;
                item.Descripcion = tbDescripcion.Text;
                item.Quantity = Int32.Parse(tbCantidad.Text);

                if (item.Quantity > 0)
                {
                    StockService ss = new StockService();
                    if (ss.addStock(item)) MessageBox.Show("Actualiza2");
                    else MessageBox.Show("No se pudo agregar, error en la consulta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La quedo: {ex.Message}");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                StockModel item = new StockModel();
                item.Name = tbNombre.Text;
                item.Descripcion = tbDescripcion.Text;
                item.Quantity = Int32.Parse(tbCantidad.Text);

                if (item.Quantity > 0)
                {
                    StockService ss = new StockService();
                    if (ss.addStock(item)) MessageBox.Show("Elimina2");
                    else MessageBox.Show("No se pudo agregar, error en la consulta.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"La quedo: {ex.Message}");
            }
        }
    }
}
