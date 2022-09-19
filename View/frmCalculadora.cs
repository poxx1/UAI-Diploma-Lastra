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
using Models;
using Models.interfaces;
using Models.language;

namespace View
{
    public partial class frmCalculadora : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        UserService userService = new UserService();
        public frmCalculadora()
        {
            InitializeComponent();
            Session.GetInstance.addObserber(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox1.Text != "0" && textBox2.Text != "" && !textBox1.Text.Contains('-') && !textBox2.Text.Contains('-'))
                {
                    float a = float.Parse(textBox1.Text);
                    float b = float.Parse(textBox2.Text);
                    float c = a * b;
                    label4.Text = c.ToString();
                }
                else
                {
                    MessageBox.Show("No incluir 0s, campos vacios ni numeros negativos en la cuenta");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo realizar el calculo, revisar los datos ingresados");
            }
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

        }
        private void frmCalculadora_FormClosed(object sender, FormClosedEventArgs e)
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
