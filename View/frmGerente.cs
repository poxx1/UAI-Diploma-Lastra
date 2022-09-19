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
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmGerente : Form, ILanguageObserber
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

        }
        private void frmGerente_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
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
            Actualizar();
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
            catch (Exception ex)
            {
                throw ex;
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
