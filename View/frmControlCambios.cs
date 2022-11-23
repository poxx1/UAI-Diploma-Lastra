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
using Models.DBModel;
using Utiles;

namespace View
{
    public partial class frmControlCambios : Form
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
                DigitoVerificadorService ds = new DigitoVerificadorService();
                ControlCambiosModel cambio = (ControlCambiosModel)dataGridView1.CurrentRow.DataBoundItem;
                //DBUsers usuarioRecuperado = ds.recuperarUsuario(cambio.change_data);
                Crypt cr = new Crypt();
                string stringlara = cr.Decrypt("KQOn+5zThKs8L1Eyms69Qz/dJ495pO7E9ibDCc6mh9rCiMm5dS3ch77YM2O9YGKs");

                UserRepository ur = new UserRepository();
                ur.updateUser(ds.obtenerUsuario(stringlara));
                label1.Text = "Se restauro correctamente el usuario al estado original";
            }
            catch (Exception ex)
            {
                label1.Text = "Error restaurando el usuario";
                MessageBox.Show(ex.Message);
            }            //Current item o como verga sea
        }
    }
}
