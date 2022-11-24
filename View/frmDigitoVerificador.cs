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

namespace View
{
    public partial class frmDigitoVerificador : Form
    {
        public frmDigitoVerificador()
        {
            InitializeComponent();
            button2.Enabled = false;
             button5.Enabled = false;
            label4.Text = "Debido a un error en la verificacion del DV, debe realizar una accion";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DigitoVerificadorService us = new DigitoVerificadorService();

            DBUsers user = new DBUsers();
            user.UserName = "admin";
            user.Password = "MyQce23+1e0="; //O era 1234 idk
            user.Email = "julianlastra.kz@gmail.com";
            user.Key_idioma = 1;
            user.Tries = 0;
            user.isBlocked = false;
            user.id_tipo = 0;

            //MessageBox.Show(us.DigitoVerificarUsuario(user));

            if (us.CompararDigitoVerificadorHorizontal()) {
                MessageBox.Show("Se valido correctamente el digito verificador");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "MyQce23+1e0=")
            {
                button2.Enabled = true;
                button5.Enabled = true;
            }
            else label4.Text = "Error validando la clave de recuperacion";
        }

        private void frmDigitoVerificador_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Validar cambios
            DialogResult result = MessageBox.Show("", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                DigitoVerificadorService ds = new DigitoVerificadorService();
                DigitoVerificadorRepository dr = new DigitoVerificadorRepository();
                //Verifico todos los usuarios horizontalmente.
                //Listo los usuarios.

                //Updateo los usuarios con su nuevo digito verificador.
                foreach (DBUsers user in ds.ListdBUsers())
                {
                    string digito = ds.DigitoVerificarUsuario(user);
                    
                    foreach (DigitoVerificadorModel model in ds.ListarDigitoVerificadorHorizontal())
                    {
                        if (model.id_dv == user.id_dv.ToString())
                        {
                            model.digitoVerificador = digito;
                            dr.UpdateHorizontalUsuario(model);
                            dr.UpdateHorizontal(model);
                        }
                    }
                }

                //Verifico todos los usuarios verticalmente.
                ds.verificarVerticalUsuarios();

                //Reviso de nuevo que este todo ok.
                if (ds.dobleVerificacion())
                {
                    MessageBox.Show("Se validaron los usuarios");
                    this.Hide();
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name == "frmLogin")
                        {
                            foreach (Control control in frm.Controls)
                            {
                                control.Enabled = true;
                            }
                        }
                    }
                }
                else MessageBox.Show("No se pudieron validar los usuarios. Se recomienda restaurara la DB.");
            }
            else 
            {
                label4.Text = "Eligio no validar los cambios.";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Restaurar DB
            DialogResult result = MessageBox.Show("", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                frmBackupDB frm = new frmBackupDB();
                frm.Show();
            }
            else
            {
                label4.Text = "Eligio no restaurar la db.";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Para utilizar la clave desde el credential manager debe ser administrador, si lo es, su clave se encuentra en su clipboard, haga control + v sobre la casilla de texto y pegue la clave obtenida.");
        }
    }
}