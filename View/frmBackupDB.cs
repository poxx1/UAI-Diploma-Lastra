using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;

namespace View
{
    public partial class frmBackupDB : Form
    {
        public frmBackupDB()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //La query:  Backup database Student to disk = 'E:/test.bak'
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;

            //Foreach item in dir fill combobox.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extras\Backup\";

            comboBox3.Items.Clear();

            DirectoryInfo d = new DirectoryInfo(path); //

            FileInfo[] Files = d.GetFiles("*.bak"); //all backups

            foreach (FileInfo file in Files)
            {
                comboBox3.Items.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Estas seguro que queres restaurar el backup?","Cuidado!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                try
                {
                    BackupRestoreService backupRestoreService = new BackupRestoreService();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extras\Backup\" + comboBox3.SelectedItem;

                    backupRestoreService.restoreBackup($"EXEC[store_restore] @path = '{path}'");
                    label3.ForeColor = Color.Green;
                    label3.Text = "Se restauro la base de datos correctamente";

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error restaurando la db");
                }
                Console.WriteLine("Evita que se rompa el codigo por el try adentro del if");
            }
            else
            {
                label3.ForeColor = Color.Yellow;
                label3.Text = "Se freno la accion de restaurar.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Backup
            if (folderBrowserDialog1.SelectedPath != null)
            {
                BackupRestoreService backupRestoreService = new BackupRestoreService();
                //backupRestoreService.makeBackup($"EXEC[updateTicket] @ticket_ID = N'" + ticketNumber + "', @time_Alerted = N'" + DateTime.Now + "', @ticket_Priority = N'" + ticketPriority + "'" = '{folderBrowserDialog1.SelectedPath}'");
                string today = DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
                //MessageBox.Show(today);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extras\Backup\" + today + ".bak";

                backupRestoreService.makeBackup($"EXEC[store_backup] @path = '{path}'");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmBackupDB_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(System.Environment.MachineName + @"\SQLEXPRESS");
            comboBox2.Items.Add("campo");
        }
    }
}
