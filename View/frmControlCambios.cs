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
    }
}
