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

namespace View
{
    public partial class frmActualizarUsuario : Form
    {
        public frmActualizarUsuario()
        {
            InitializeComponent();
        }

        private void frmActualizarUsuario_Load(object sender, EventArgs e)
        {
            UserRepository ur = new UserRepository();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ur.ListDBUsers();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult response = MessageBox.Show("Esta seguro que desea restaurar el usuario?", "Restaurar", MessageBoxButtons.OKCancel);
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
    }
}
