using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CredentialManagement;

namespace Utiles
{
    public class CredentialManager
    {
        public string Username { get; set; }
        public string Password { get; set; }
        protected Credential cd = new Credential();

        public bool User()
        {
            //Casilla de correo
            //El user es el email completo: 'julian.marcos.lastra@accenture.com'
            try
            {
                cd.Target = "Diploma_Lastra";
                cd.Load();
                Username = cd.Username;
                Password = cd.Password;

                Clipboard.SetText(Password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
