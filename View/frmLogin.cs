using System;
using System.Threading;
using System.Windows.Forms;
using Business;
using Utiles;

namespace View
{
    public partial class frmLogin : Form
    {
        SessionService sessionService;

        public frmLogin()
        {
            InitializeComponent();
            sessionService = new SessionService();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sessionService.Login(textBox1.Text, textBox2.Text);
                this.Hide();
                new frmMain(this).Show();      
            }
            catch (Exception ex)
            {
                button1.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);

            }
            finally
            {
                clearForm();
            }
        }


        private  void clearForm()
        {
            //textBox1.Clear();
            //textBox2.Clear();
            textBox1.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Se deben seguir las siguientes reglas a la hora de crear una contraseña: \r\n 1. Debe contar con al menos 8 caracteres. \r\n 2. No debe contener solo letras \r\n NOTA: Todo usuario que incumpla las politicas mencionadas sera penado por la compania.","Politicas olbigatorias",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
