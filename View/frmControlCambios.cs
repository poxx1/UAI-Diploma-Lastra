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
using Models.DBModel;
using Models.interfaces;
using Models.language;
using Utiles;

namespace View
{
    public partial class frmControlCambios : Form, ILanguageObserber
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
            try
            {
                DialogResult response = MessageBox.Show("Esta seguro que desea restaurar el usuario?", "Restaurar", MessageBoxButtons.OKCancel);
                if (response == DialogResult.OK)
                {
                    DigitoVerificadorService ds = new DigitoVerificadorService();
                    ControlCambiosModel cambio = (ControlCambiosModel)dataGridView1.CurrentRow.DataBoundItem;
                    //DBUsers usuarioRecuperado = ds.recuperarUsuario(cambio.change_data);
                    Crypt cr = new Crypt();
                    string stringlara = cr.Decrypt(cambio.change_data);

                    UserRepository ur = new UserRepository();
                    ur.updateUser(ds.obtenerUsuario(stringlara));

                    //>> Falta updatear estos dos perro
                    //ds.UpdateDigitoVerificadorHorizontalUsuario(); 
                    //ds.UpdateDigitoVerificadorVerticalUsuario();

                    label1.Text = "Se restauro correctamente el usuario al estado original";
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Error restaurando el usuario";
                MessageBox.Show(ex.Message);
            }            //Current item o como verga sea
        }

        private void frmControlCambios_Load(object sender, EventArgs e)
        {
            Session.GetInstance.addObserber(this);
        }

        private void frmControlCambios_FormClosed(object sender, FormClosedEventArgs e)
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
