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
    public partial class frmLanguage : Form, ILanguageObserber
    {
        //PermissionsService permissionsService;
        //Family seleccion;
        public frmLanguage()
        {
            InitializeComponent();
        }

        private void frmLanguage_Load(object sender, EventArgs e)
        {
            updateLanguage(Session.GetInstance.language);

        }

        private void frmLanguage_FormClosed(object sender, FormClosedEventArgs e)
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

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            string nombreNuevoIdioma = textBox58.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Guardo en la BD el nuevo idioma

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Guardo los cambios del idioma en la bd
        }
    }
}
