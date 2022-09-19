using System;
using System.Windows.Forms;
using Business;
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmReparaciones : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        public frmReparaciones()
        {
            InitializeComponent();
            cargarMaquinas();
            Session.GetInstance.addObserber(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Calcula las horas y se la pasa a aprobaciones. La marco como revisada.
            Machines m = new Machines();
            MachinesService ms = new MachinesService();
            m = getCurrent();

            m.isPossibleToRepair = false;
            m.isReviewed = true;
            m.Reparation = "Imposible arreglar";

            ms.Review(m);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Calcula las horas y se la pasa a aprobaciones. La marco como revisada.
                if (int.Parse(textBox1.Text) > 0 && richTextBox1.Text != "")
                {
                    Machines m = new Machines();
                    MachinesService ms = new MachinesService();
                    m = getCurrent();

                    m.Reparation = richTextBox1.Text;

                    m.isPossibleToRepair = true;
                    m.isReviewed = true;

                    m.Hours = int.Parse(textBox1.Text);

                    ms.Review(m);
                    MessageBox.Show("Maquina presupuestada");

                }
                else
                {
                    MessageBox.Show("No se puede presupestar si no ingresa la cantidad de horas");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presupuestar la maquina. Contacte al administrador");
                throw ex;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = getCurrent().Reparation.ToString();
            Machines m = getCurrent();
            textBox1.Text = m.Hours.ToString();
        }
        private void cargarMaquinas()
        {
            MachinesService ms = new MachinesService();
            comboBox1.DataSource = null;
            comboBox1.DataSource = ms.GetAll();
            comboBox1.DisplayMember = "Id_Machine";
            richTextBox1.Text = getCurrent().Reparation.ToString(); 
            textBox1.Text = getCurrent().Hours.ToString();
            //comboBox1.Text = getCurrent().Id_Machine.ToString();
        }

        private Machines getCurrent()
        {
            Machines m = new Machines();
            m = (Machines)comboBox1.SelectedItem;
            if (m.isReviewed == true) { checkBox1.Checked = true; button1.Enabled = false;
                button2.Enabled = false;
            }
            else { checkBox1.Checked = false;
                button1.Enabled = true;
                button2.Enabled = true;

            }

            return m;
        }

        #region Idioma
        public void updateLanguage(Language language)
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
        #endregion

        private void frmReparaciones_Load(object sender, EventArgs e)
        {   
            updateLanguage(Session.GetInstance.GetLanguage());
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button1.Enabled = true;
        }

        private void Approvals_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }
    }
}
