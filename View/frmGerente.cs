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
using DataAccess;
using Models;
using Models.interfaces;
using Models.language;
using Utiles;

namespace View
{
    public partial class frmGerente : Form , ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        UserService userService = new UserService();
        public frmGerente()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void frmGerente_Load(object sender, EventArgs e)
        {
            Actualizar();
            updateLanguage(Session.GetInstance.language);
            dataGridView1.ForeColor = Color.Black;
        }

        private void frmGerente_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Session.GetInstance.removeObserber(this);
            }
            catch (Exception) { }
        }
        private void Actualizar()
        {
            try
            {
                MachinesService ms = new MachinesService();
                int counter1 = ms.GetAll().Count;
                int counter2 = ms.GetAll().Count;

                //Load Maquinas sin aprobar
                listBox1.DataSource = null;

                List<Machines> machines = new List<Machines>();

                foreach (Machines m in ms.GetAll())
                {
                    if (!m.isApproved == true)
                    {
                        machines.Add(m);
                        counter1--;
                    }
                }

                progressBar1.Maximum = ms.GetAll().Count;
                progressBar2.Maximum = ms.GetAll().Count;

                listBox1.DataSource = machines;

                //DataGridView

                List<ReporteMaquinas> listMaquinas = new List<ReporteMaquinas>();
                ReporteMaquinas rp = new ReporteMaquinas();


                UserRepository userRepository = new UserRepository();


                foreach (Machines maquina in machines)
                {

                    try
                    {
                        User u = new User();
                        rp = new ReporteMaquinas();

                        u = userRepository.GetAll().Where(x => x.Id == maquina.Id_Client).ToList().First();
                        rp.Cliente = u.UserName.ToString();
                        rp.ID_Maquina = maquina.Id_Machine;
                        rp.Modelo = maquina.Model;
                        rp.Marca = maquina.Brand;
                        rp.Falla = maquina.Failure;
                        rp.Descripcion = maquina.Description;

                        listMaquinas.Add(rp);
                    }
                    catch (Exception) { }
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = listMaquinas;

                //Load Maquinas sin revisar

                listBox2.DataSource = null;

                List<Machines> machines2 = new List<Machines>();

                foreach (Machines m in ms.GetAll())
                {
                    if (!m.isReviewed == true)
                    {
                        machines2.Add(m);
                        counter2--;
                    }
                }

                listBox2.DataSource = machines2;

                listBox1.DisplayMember = "Id_Machine";
                listBox2.DisplayMember = "Id_Machine";
                progressBar1.Value = counter1;
                progressBar2.Value = counter2;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos");
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Actualizar();
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
                MessageBox.Show("Cerra el formulario boludo");// Que la chupe este form de mierda
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

        private void button2_Click(object sender, EventArgs e)
        {
            PDFConverter pdf = new PDFConverter();
            pdf.ConvertToPdf(dataGridView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //Help.ShowHelp(this, System.Reflection.Assembly.GetEntryAssembly().Location+@"\Proyecto.chm"); //, "content.html"
        }
        private void frmGerente_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path+ @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            Machines m = new Machines();
            m = (Machines)listBox2.SelectedItem;

            User u = new User();
            UserRepository userRepository = new UserRepository();
            u = userRepository.GetAll().Where(x => x.Id == m.Id_Client).ToList().First();

            textBox2.Text = u.UserName.ToString();
            textBox3.Text = m.Brand;
            textBox4.Text = m.Model;
            richTextBox2.Text = m.Description;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Machines m = new Machines();
            m = (Machines)listBox1.SelectedItem; 
            User u = new User();
            UserRepository userRepository = new UserRepository();
            u = userRepository.GetAll().Where(x => x.Id == m.Id_Client).ToList().First();

            textBox2.Text = u.UserName.ToString();
            textBox3.Text = m.Brand;
            textBox4.Text = m.Model;
            richTextBox2.Text = m.Description;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}