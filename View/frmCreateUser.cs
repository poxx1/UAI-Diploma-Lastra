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
using Utiles;

namespace View
{
    public partial class frmCreateUser : Form, ILanguageObserber
    {
        PermissionsService permissionsService;
        //Family seleccion;

        public frmCreateUser()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
            permissionsService = new PermissionsService();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                UserService us = new UserService();
                Crypt crypt = new Crypt();
                bool isValidData = true;

                #region Regex
                if (!Regex.IsMatch(textBox1.Text, "^([a-zA-Z]+$)")) //Letters only
                    isValidData = false;
                if (!Regex.IsMatch(textBox2.Text, "^([a-zA-Z]+$)")) //Letters only
                    isValidData = false;
                if (!Regex.IsMatch(textBox3.Text, "^([0-9]+$)"))//Numbers only
                    isValidData = false;
                if (!Regex.IsMatch(textBox6.Text, "^([0-9]+$)"))//Numbers only
                    isValidData = false;
                #endregion

                #region asignaciones
                if (isValidData)
                {

                user.Name = textBox1.Text;
                user.LastName = textBox2.Text;
                user.Dni = textBox3.Text;
                user.UserName = textBox4.Text;

                user.Password = crypt.Encrypt(textBox5.Text);
                user.Email = textBox8.Text;
                user.Phone = textBox6.Text;
                user.Adress = textBox7.Text;
                user_typeModel id = (user_typeModel)comboBox1.SelectedItem;
                user.Tipo = id.id;
                user.Language = (Models.language.Language)comboBox2.SelectedItem;
                user.isBlocked = false;
                user.Tries = 0;
                //user.Permissions Le clavo el default
                #endregion

                //pregunto si existe el nombre de usuario y el dni
                if (!us.CheckIfExist(user) && !us.CheckIfExistUserName(user))
                {
                    us.Save(user);
                    MessageBox.Show("c creo el usuario");
                }
                else
                {
                    MessageBox.Show("No c pudo crear el usuario, ya existe");
                }

                }
                else { MessageBox.Show("Hay errores en los datos ingresados"); }
            }
            catch (FormatException)//sysFormat
            {
                MessageBox.Show("No c pudo crear el usuario, hay un problema con el formato");
                //throw sysFormat;
            }
            catch (Exception )//ex
            {
                MessageBox.Show("No c pudo crear el usuario");
                //throw ex;
            }
        }

        private void frmCreateUser_Load(object sender, EventArgs e)
        {

            updateLanguage(Session.GetInstance.language);

            UserService us = new UserService();
            LanguageService lg = new LanguageService();
            comboBox1.DataSource = us.GetAllTypes();
            comboBox1.DisplayMember = "desc";
            comboBox2.DataSource = lg.GetLanguagesForCombo();
            comboBox2.DisplayMember = "name";
        }

        private void frmCreateUser_FormClosed(object sender, FormClosedEventArgs e)
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
