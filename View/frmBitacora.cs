using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmBitacora : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        UserService userService = new UserService();
        List<LogModel> listOfLogs;
        public frmBitacora()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }
        private void frmBitacora_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
        }
        private void frmBitacora_Load(object sender, EventArgs e)
        {
            Logger log = new Logger();
            UserService us = new UserService();
            listOfLogs = log.ListLogs();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOfLogs;

            comboBox1.DataSource = null;
            comboBox1.DataSource = us.GetAll();
            comboBox1.DisplayMember = "Name";

            dateTimePicker1.MaxDate = DateTime.Now;           
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yy";

            dateTimePicker2.MaxDate = DateTime.Now;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yy";

            comboBox2.Items.Add("Informacion");
            comboBox2.Items.Add("Warning");
            comboBox2.Items.Add("Error");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//El tolist del orto hacia que no funcione el LINQ porque guardaba lalista vacia el estupido.
            try
            {
                DateTime fechaDesde = dateTimePicker1.Value.AddDays(-1);
                DateTime fechaHasta = dateTimePicker2.Value; //.AddDays(1);

                //Por usuario
                if (rbUsuario.Checked)
                {
                    User user = (User)comboBox1.SelectedItem;
                    dataGridView1.DataSource = listOfLogs.Where(x => x.UserID == int.Parse(user.Id.ToString())).ToList();
                }
                if (rbFecha.Checked) //Fecha
                {
                    var list = (listOfLogs.Where(x => (DateTime.Parse(x.Fecha)) >= fechaDesde)).ToList();
                    dataGridView1.DataSource = list.Where(x => (DateTime.Parse(x.Fecha)) <= fechaHasta).ToList();
                }
                //Por prioridad
                if (radioButton1.Checked) dataGridView1.DataSource = listOfLogs.Where(x => x.Priority == comboBox2.SelectedItem.ToString()).ToList();

                //Por todos
                if (rbAmbos.Checked)
                {
                    var list = (listOfLogs.Where(x => (DateTime.Parse(x.Fecha)) >= fechaDesde)).ToList();
                    var list2 = list.Where(x => (DateTime.Parse(x.Fecha)) <= fechaHasta).ToList();
                    User user = (User)comboBox1.SelectedItem;
                    var list3 = list2.Where(x => x.UserID == int.Parse(user.Id.ToString())).ToList();
                    dataGridView1.DataSource = list3.Where(x => x.Priority == comboBox2.SelectedItem.ToString()).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error aplicando el filtro");
                MessageBox.Show(ex.Message);  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listOfLogs;
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void frmBitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }

        public void updateLanguage(Language language)
        {
            try
            {
                foreach (Control control in Controls)
                {
                    control.Text = language.Translations.Find(
                            (translation) => translation.Key.Equals(control.Tag)
                        )?.Translate ?? control.Text;
                    if (control.Controls.Count != 0)
                    {
                        updateLanguageRecursiveControls(language, control.Controls);
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(""); Que la chupe este form de mierda
            }
        }
        public void updateLanguageRecursiveControls(Language language, Control.ControlCollection parent)
        {
            foreach (Control control in parent)
            {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;

                if (control.Controls.Count != 0)
                {
                    updateLanguageRecursiveControls(language, control.Controls);
                }
            }
        }
    }
}
