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

namespace View
{
    public partial class frmActualizarUsuario : Form, ILanguageObserber
    {
        public frmActualizarUsuario()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }
        private void frmActualizarUsuario_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
        }
        private void frmActualizarUsuario_Load(object sender, EventArgs e)
        {
            UserRepository ur = new UserRepository();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ur.ListDBUsers();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Esta seguro que desea actualizar el usuario?", "Restaurar", MessageBoxButtons.OKCancel);
            if (response == DialogResult.OK)
            {
                try
                {
                    var user = (DBUsers)dataGridView1.CurrentRow.DataBoundItem;
                    UserRepository ur = new UserRepository();
                    ur.updateUser(user);
                    //Updateo el digitoVerificador en la tabla de usuarios y en la tabla de horizontal y vertical.
                    label1.Text = "Se updateo el usuario";

                    DigitoVerificadorModel dv = new DigitoVerificadorModel();
                    DigitoVerificadorService dg = new DigitoVerificadorService();
                    DigitoVerificadorRepository dr = new DigitoVerificadorRepository();

                    dv.digitoVerificador = dg.DigitoVerificarUsuario(user);
                    dv.id_dv = user.id_dv.ToString();
                    //dv.digitoVerificador = user.digitoVerificador;

                    dg.UpdateDigitoVerificadorHorizontalUsuario(dv);
                    dr.UpdateHorizontalUsuario(dv);
                    dg.UpdateDigitoVerificadorVerticalUsuario();

                    dg.InsertarCambioDB(user);

                    Logger log = new Logger();
                    log.LogData("Cambio en usuario",$"Se modifico el usuario {user.UserName}", "Error");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else label1.Text = "No se updateo el usuario";
        }

         private void frmActualizarUsuario_FormClosed(object sender, FormClosedEventArgs e)
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
