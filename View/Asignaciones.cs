using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business;
using DataAccess;
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class Asignaciones : Form, ILanguageObserber
    {
        public Asignaciones()
        {
            InitializeComponent();

            //Machines m = new Machines();
            //UserService bldo
            UserService us = new UserService();
            //MachinesService ms = new MachinesService();

            List<User> listReparadores = new List<User>();
            List<User> temp = new List<User>();

            temp = us.GetAll();

            foreach (User user in temp)
            {
                if (user.Tipo == 1) //isReparador?
                {
                    listReparadores.Add(user);
                }
            }

            comboBox1.DataSource = listReparadores;
            comboBox1.DisplayMember = "name";
            Session.GetInstance.addObserber(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countHoras = 0;
            List<User_MachineModel> listaM = new List<User_MachineModel>();
            listaM = MachinesService.ListMachinesToRepair();
            User us = new User();
                us = (User)comboBox1.SelectedItem;

            listBox1.Items.Clear();
            foreach (User_MachineModel m in listaM)
            {
                if (m.Id_user == us.Id)
                {
                    countHoras += m.Time;
                    listBox1.Items.Add(m);
                }
            }
            textBox1.Text = countHoras.ToString();

        }

        #region Idioma
        public void updateLanguage(Language language)
        {
            foreach (Control control in Controls)
            {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;
                if (control.Controls.Count != 0)
                {
                    updateLanguageRecursiveControls(language, control.Controls);
                }
            }
        }
        private void Asignaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }

        public void updateLanguageRecursiveControls(Language language, Control.ControlCollection parent)
        {
            foreach (Control control in parent)
            {
                control.Text = language.Translations.Find(
                        (translation) => translation.Key.Equals(control.Tag)
                    )?.Translate ?? control.Text;

                if (control.Controls.Count != 0)
                {
                    updateLanguageRecursiveControls(language, control.Controls);
                }
            }
        }
        #endregion

        private void Approvals_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }
        private void Asignaciones_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
        }
        private void Asignaciones_Load(object sender, EventArgs e)
        {

            updateLanguage(Session.GetInstance.language);

            int countHoras = 0;
            List<User_MachineModel> listaM = new List<User_MachineModel>();
            listaM = MachinesService.ListMachinesToRepair();
            User us = new User();
            us = (User)comboBox1.SelectedItem;

            listBox1.Items.Clear();
            foreach (User_MachineModel m in listaM)
            {
                if (m.Id_user == us.Id)
                {
                    countHoras += m.Time;
                    listBox1.Items.Add(m);
                }
            }
            textBox1.Text = countHoras.ToString();
            listBox1.DisplayMember = "Id_Machine";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Machines m = new Machines();
                User_MachineModel um = new User_MachineModel();
                um = (User_MachineModel)listBox1.SelectedItem;
                MachineRepository mr = new MachineRepository();

                m = mr.listMachines().Where(x => x.Id_Machine == um.Id_machine).ToList().First();

                User u = new User();
                UserRepository userRepository = new UserRepository();
                u = userRepository.GetAll().Where(x => x.Id == m.Id_Client).ToList().First();

                textBox2.Text = u.UserName.ToString();
                textBox3.Text = m.Brand;
                textBox4.Text = m.Model;
                richTextBox2.Text = m.Description;
            }
            catch (Exception)
            {
            }
            
        }
    }
}
