using System;
using System.Drawing;
using System.Security.Principal;
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
   ;
            try
            {
                sessionService.Login(textBox1.Text, textBox2.Text);              
                this.Hide();
                new frmMain(this).Show();

                Logger log = new Logger();
                log.LogData("Log-in", "El usuario se logueo correctamente","Informacion");
            }
            catch (Exception ex)
            {
                button1.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show(ex.Message);

                //Logger log = new Logger();
                //log.LogData("Log-in", "El usuario no se logueo correctamente");
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

            try
            {
                DBChecker db = new DBChecker();
                if (db.dbExists()) { }
                else
                {
                    MessageBox.Show("Se esta creando la base de datos, espere 5 minutos para poder interactuar");

                    //BackupRestoreService backupRestoreService = new BackupRestoreService();
                    //string path1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extras\Inicial.bak";

                    //backupRestoreService.restoreBackup($"EXEC[store_restore] @path = '{path1}'");
                    //label3.ForeColor = Color.Green;
                    //label3.Text = "Se restauro la base de datos correctamente";

                    MessageBox.Show("Corriendo script para crear db");
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extras\createDB.sql";
                    db.CreateDB(db.readScript(path));

                    Thread.Sleep(5000);

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

                    Utiles.CredentialManager cm = new CredentialManager();

                if (cm.User())
                {
                    bool isAdmin = false;
                    using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                    }

                    if (isAdmin) { } // re molsta esta verga MessageBox.Show("Como es admin se copio la clave al clipboard."); }
                    else
                    { //MessageBox.Show("No tiene permisos para poder obtener la clave"); }
                    }
                }
                
                //Digito verificar
                DigitoVerificadorService us = new DigitoVerificadorService();
                if (us.dobleVerificacion())
                {

                }
                else 
                {
                    this.Hide();
                    button1.Enabled = false;
                    //MessageBox.Show("Debido al error de verificacion no puede iniciar sesion.");
                    frmDigitoVerificador frmDigitoVerificador = new frmDigitoVerificador();
                    frmDigitoVerificador.Show();       
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de la DB. Se intento crear pero algo fallo" + ex);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Se deben seguir las siguientes reglas a la hora de crear una contraseña: \r\n 1. Debe contar con al menos 8 caracteres. \r\n 2. No debe contener solo letras \r\n NOTA: Todo usuario que incumpla las politicas mencionadas sera penado por la compania.","Politicas olbigatorias",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
