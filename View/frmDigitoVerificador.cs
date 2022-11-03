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

            us.DigitoVerificarUsuario(user);
        }
    }
}