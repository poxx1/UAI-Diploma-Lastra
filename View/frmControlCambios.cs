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
                    string stringlara = cr.Decrypt(cambio.DigitoVerificador);

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
        private void frmControlCambios_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
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

        private void button2_Click(object sender, EventArgs e)
        {
            ControlCambiosModel cambio = (ControlCambiosModel)dataGridView1.CurrentRow.DataBoundItem;
            DigitoVerificadorService ds = new DigitoVerificadorService();
            Crypt crypt = new Crypt();
            var user = ds.obtenerUsuario(crypt.Decrypt(cambio.DigitoVerificador.ToString()));
            MessageBox.Show("Informacion del usuario: \r\n"+user.UserName + "\r\n" + user.Email + "\r\n" + user.id_tipo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Todo el quilombo
                ControlCambiosModel cambio = (ControlCambiosModel)dataGridView1.CurrentRow.DataBoundItem;
                DigitoVerificadorService ds = new DigitoVerificadorService();
                Crypt crypt = new Crypt();
                DBUsers user = ds.obtenerUsuario(crypt.Decrypt(cambio.DigitoVerificador.ToString()));

                //Usuario anterior
                textBox1.Text = user.ID.ToString();
                textBox2.Text = user.UserName;
                textBox3.Text = user.Password;
                textBox4.Text = user.Email;
                textBox5.Text = user.Key_idioma.ToString();
                textBox6.Text = user.Tries.ToString();
                if (user.isBlocked) textBox7.Text = "Esta bloqueado";
                else textBox7.Text = "No esta bloqueado";
                textBox8.Text = user.id_tipo.ToString();

                //Usuario actual
                DBUsers actual = new DBUsers();
                UserRepository ur = new UserRepository();
                var lista = ur.ListDBUsers();

                actual = (DBUsers)lista.Where(x => x.ID == user.ID).ToList().First();

                textBox16.Text = actual.ID.ToString();
                textBox15.Text = actual.UserName;
                textBox14.Text = actual.Password;
                textBox13.Text = actual.Email;
                textBox12.Text = actual.Key_idioma.ToString();
                textBox11.Text = actual.Tries.ToString();
                if (actual.isBlocked) textBox10.Text = "Esta bloqueado";
                else textBox10.Text = "No esta bloqueado";
                textBox9.Text = actual.id_tipo.ToString();

                //Diferencias
                if (textBox1.Text != textBox16.Text) label2.ForeColor = Color.Red; else label2.ForeColor = Color.Green;
                if (textBox2.Text != textBox15.Text) label3.ForeColor = Color.Red; else label3.ForeColor = Color.Green;
                if (textBox3.Text != textBox14.Text) label4.ForeColor = Color.Red; else label4.ForeColor = Color.Green;
                if (textBox4.Text != textBox13.Text) label5.ForeColor = Color.Red; else label5.ForeColor = Color.Green;
                if (textBox5.Text != textBox12.Text) label6.ForeColor = Color.Red; else label6.ForeColor = Color.Green;
                if (textBox6.Text != textBox11.Text) label7.ForeColor = Color.Red; else label7.ForeColor = Color.Green;
                if (textBox7.Text != textBox10.Text) label8.ForeColor = Color.Red; else label8.ForeColor = Color.Green;
                if (textBox8.Text != textBox9.Text) label9.ForeColor = Color.Red; else label9.ForeColor = Color.Green;
            }
            catch (Exception) { }
        }
    }
}
