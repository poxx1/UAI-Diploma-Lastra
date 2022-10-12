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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Estas seguro que queres restaurar el backup?","Cuidado!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Se restauro la base de datos correctamente";
            }
            else
            {
                label3.ForeColor = Color.Yellow;
                label3.Text = "Se freno la accion de restaurar.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.SelectedPath != null)
            {
                BackupRestoreService backupRestoreService = new BackupRestoreService();
                backupRestoreService.makeBackup($"Backup database campo to disk = '{folderBrowserDialog1.SelectedPath}'");
            }
        }
    }
}
