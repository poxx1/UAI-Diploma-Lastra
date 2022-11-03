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
    public partial class frmBitacora : Form
    {
        List<LogModel> listOfLogs;
        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            Logger log = new Logger();
            listOfLogs = log.ListLogs();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOfLogs;

            dateTimePicker1.MaxDate = DateTime.Now;           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yy";

            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yy";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//El tolist del orto hacia que no funcione el LINQ porque guardaba lalista vacia el estupido.
            if (rbUsuario.Checked) dataGridView1.DataSource = listOfLogs.Where(x => x.UserID == int.Parse(comboBox1.Text)).ToList();
            if (rbFecha.Checked) dataGridView1.DataSource = listOfLogs.Where(x => DateTime.Parse(x.Fecha) >= dateTimePicker1.Value).Where(x => DateTime.Parse(x.Fecha) < dateTimePicker1.Value).ToList();
            if (rbAmbos.Checked) dataGridView1.DataSource = listOfLogs.Where(x => x.Fecha == dateTimePicker1.Text).Where(x => x.UserID == Int32.Parse(comboBox1.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOfLogs;
        }
    }
}
