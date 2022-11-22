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
using Models.DBModel;

namespace View
{
    public partial class frmDigitoVerificador : Form
    {
        public frmDigitoVerificador()
        {
            InitializeComponent();
            button2.Enabled = false;
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
            if (textBox1.Text == "asd")
            {
                button2.Enabled = true;
            }
            else label4.Text = "Error validando la clave de recuperacion";
        }

        private void frmDigitoVerificador_Load(object sender, EventArgs e)
        {

        }
    }
}