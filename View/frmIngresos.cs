using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmIngresos : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;

        public frmIngresos()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Machines machine = new Machines();
                User client = (User)comboBox1.SelectedItem;

                User fixer = new User();
                UserService userService = new UserService();
                fixer = userService.Get("Dummy");

                bool isValidData = true;

                #region Regex
                if (tb_Marca.Text == "" || rtb_Failures.Text == "" || rtb_Elements.Text == "" || rtb_Description.Text == "" || tb_Modelo.Text == "")
                    isValidData = false;
                #endregion

                if (isValidData)
                {

                machine.Brand = tb_Marca.Text;
                machine.Picture = "lafoto";
                machine.Failure = rtb_Failures.Text;
                
                machine.Id_Machine = new Random().Next(1,100); //Deberia ya estar el autoID
                machine.Elements = rtb_Elements.Text;
                machine.Description = rtb_Description.Text;
                //machine.Failure = rtb_Failures.Text;
                //Color de la BD por ID
                ColorModel id = (ColorModel)comboBox3.SelectedItem;
                machine.Color = id.id_color.ToString();//comboBox3.Text;
                machine.Model = tb_Modelo.Text;
                machine.isApproved = false;
                machine.isReviewed = false;
                machine.Id_Client = client.Id;
                machine.isPossibleToRepair = false;
                machine.Reparation = "No se reviso";
                machine.Hours = 0;
                machine.Id_User = fixer.Id; //Se la asigno al admin y despues la cambio

                MachinesService ms = new MachinesService();

                if (!ms.CheckIfExist(machine))
                { MessageBox.Show("Maquina Ingresada"); ms.Save(machine); }
                else { MessageBox.Show("La maquina ya existe"); }

                }
                else { MessageBox.Show("Revise los datos que ingreso"); }
            }
            catch (FormatException) //sysFormat
            {
                MessageBox.Show("No c pudo ingresar la maquina, hay un problema con el formato");
                //throw sysFormat;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Remito de entrada generado");
        }

        private void frmIngresos_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

            UserService us = new UserService();
            List<User> users = new List<User>();
            foreach (User user in us.GetAll())
            {
                if (user.Tipo == 2)
                    users.Add(user);
            }
            comboBox1.DataSource = users;
            comboBox1.DisplayMember = "Name";

            MachinesService ms = new MachinesService();
            List<ColorModel> colors = ms.GetAllColors();
                
            foreach (ColorModel color in colors)
            {
                comboBox3.Items.Add(color);
            }
            comboBox3.DisplayMember = "desc";
        }

        private void frmIngresos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Session.GetInstance.removeObserber(this);
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

    }
}
