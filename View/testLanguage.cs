using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class testLanguage : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        UserService userService = new UserService();
   
        public testLanguage()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }

        private void testLanguage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }

        private void testLanguage_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

            PullData();
            fillCombo();
        }

        private void fillCombo()
        {
            LanguageService lg = new LanguageService();
            comboBox1.DataSource = lg.GetLanguagesForCombo();
            comboBox1.DisplayMember = "Name";
        }

        private DataTable dataTable = new DataTable();
        public void PullData()
        {
            LanguageService lg = new LanguageService();
            
            dataGridView1.DataSource = lg.GetLanguageDataTable(1);
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            LanguageService lg = new LanguageService();
            Language l = new Language();
          
            l.Name = textBox1.Text;

            int id =  lg.CreateLanguage(l.Name);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["id_idioma"].Value = id;
                //More code here
            }

            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            lg.InsertNewLanguage(dataTable, l.Name);
            MessageBox.Show("Idioma creado");

            userService = new UserService();
            Session.GetInstance.addObserber(this);

            (MdiParent as frmMain).cargarComboIdiomas(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LanguageService lg = new LanguageService();
            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            Language l = new Language();
            
            int id = 0;
            
            //l.ID = id;
            l.Name = textBox1.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                id = (int)row.Cells["id_idioma"].Value;
                break;
                //More code here
            }
            //cambiar a id
            lg.saveLanguage(dataTable, id);

            //var s = Session.GetInstance;
            //s.notifyObserbers((Language)comboBox1.SelectedItem);

            //Language language = (Language)((ToolStripMenuItem)sender).Tag;
            //Le seteo por default ESP
            LanguageService languageService = new LanguageService();
            
            Session.GetInstance.language = languageService.GetLanguage(Session.GetInstance.language.Name); //language.Name

            //Language language = (Language)((ToolStripMenuItem)sender).Tag;
            ////Le seteo por default ESP
            //Session.GetInstance.language = languageService.GetLanguage(language.Name); //language.Name

            //this.lblUsuario.Text = language.Name;

            MessageBox.Show("Cambios guardados");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language lang = new Language();
            lang = (Language)comboBox1.SelectedItem;
            int id = lang.ID;

            LanguageService lg = new LanguageService();

            dataGridView1.DataSource = lg.GetLanguageDataTable(id);
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
