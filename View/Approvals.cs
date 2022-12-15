﻿using System;
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
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class Approvals : Form, ILanguageObserber
    {
        public Approvals()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
            cargarMaquinas();
        }

        private void Approvals_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

        }
        private void Approvals_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string path = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("View.exe", "");
            Help.ShowHelp(this, path + @"\Extras\Proyecto.chm"); //, "content.html"
            //MessageBox.Show(path);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Calcula las horas y se la pasa a aprobaciones. La marco como revisada.
            Machines m = new Machines();
            MachinesService ms = new MachinesService();
            m = getCurrent();

            m.isApproved = false;

            ms.Approval(m);

            MessageBox.Show("Maquina desaprobada");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ds = MessageBox.Show("Realmente desea que la maquina sea reparada por alguien?", "", MessageBoxButtons.OKCancel);
            if (ds == DialogResult.OK)
            {
                MessageBox.Show("La maquina va a ser asignada al reparador con menor carga horaria");
                Machines m = new Machines();
                MachinesService ms = new MachinesService();
                m = getCurrent();

                m.isApproved = true;

                ms.AssingToEmployee(m);

                MessageBox.Show("Maquina aprobada y asignada a un usuario");
            }
            else { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cargarMaquinas()
        {
            MachinesService ms = new MachinesService();
            comboBox1.DataSource = null;
            comboBox1.DataSource = ms.GetAll();
            comboBox1.DisplayMember = "Id_Machine";

//            comboBox1.DisplayMember = getCurrent().Id_Machine.ToString();
        }

        private Machines getCurrent()
        {
            Machines m = new Machines();
            m = (Machines)comboBox1.SelectedItem;
            if (m.isApproved == true) { checkBox1.Checked = true; } else { checkBox1.Checked = false; }
            return m;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Machines m = new Machines();

            m = (Machines)comboBox1.SelectedItem;

            User u = new User();

            UserRepository userRepository = new UserRepository();
            u = userRepository.GetAll().Where(x => x.Id == m.Id_Client).ToList().First();

            textBox2.Text = u.UserName.ToString();
            textBox3.Text = m.Brand;
            textBox4.Text = m.Model;
            richTextBox2.Text = m.Description;
            richTextBox3.Text = m.Failure;
            textBox1.Text = m.Hours.ToString();

            if (m.isApproved == true) { checkBox1.Checked = true; button1.Enabled = false;
                button2.Enabled = false;
            }
            else { checkBox1.Checked = false; button1.Enabled = true;
                button2.Enabled = true;
            }

            if(m.isReviewed !=true)
            {
                checkBox1.Checked = true; button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                //checkBox1.Checked = false; button1.Enabled = true;
                //button2.Enabled = true;
            }

            richTextBox1.Text = m.Reparation;
            getCurrent();
        }
        public void updateLanguage(Language language)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
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

        private void Approvals_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
