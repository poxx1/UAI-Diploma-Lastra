using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utiles;
using Models.DBModel;
using DataAccess;
using System.Windows.Forms;

namespace Business
{
    public class DigitoVerificadorService
    {
        public List<DBUsers> ListdBUsers()
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.ListDBUsers();
        }
        public string DigitoVerificarUsuario(DBUsers usuario)
        {
            Crypt cr = new Crypt();

            //id + UserName +  Password + Email + key_idioma + tries + isBlocked + id_tipo
            string rowSinHashear = $"{usuario.ID}" + "##" +
                $"{usuario.UserName}" + "##" +
                $"{usuario.Password}" + "##" +
                $"{usuario.Email}" + "##" +
                $"{usuario.Key_idioma}" + "##" + //mepa que no va esto
                $"{usuario.Tries}" + "##" +
                $"{usuario.isBlocked}" + "##" +
                $"{usuario.id_tipo}";

            return cr.Encrypt(rowSinHashear); 
        }

        public string recuperarUsuario(List<DBUsers> usuariosDB)
        {
            //id + UserName +  Password + Email + key_idioma + tries + isBlocked + id_tipo
            foreach (DBUsers usuario in usuariosDB)
            {

                string[] oneLineUser = usuario.digitoVerificador.Split(new string[] { "##" }, StringSplitOptions.None);

                if (usuario.digitoVerificador == DigitoVerificarUsuario(usuario))
                {
                    //Todo correcto rey
                }
                else
                {
                    MessageBox.Show("Alguien toqueteo la bd y se mando una cagada.");
                    throw new Exception("Error con el digito verificador");
                }
            }

            return "";
        }
    }
}
