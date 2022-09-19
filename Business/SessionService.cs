using Models;
using DataAccess;
using Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.exceptions;
using System.Windows.Forms;
using Models.language;

namespace Business
{
    public class SessionService
    {

        UserService userService = new UserService();
        LanguageService languageService = new LanguageService();
        Language lang = new Language();

        public void Login(User user)
        {
            Session session = Session.GetInstance;
            session.Login(user);

            

            session.language = languageService.GetLanguage(user.Language.Key);
        }

        public void Login(String name, String Password)
        {
            Crypt crypt = new Crypt();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(Password))
            {
                throw new LoginException();
            }
            List<User> lista = userService.GetAll();
            User usuario = lista.Where(x => x.Name== name).FirstOrDefault();
            UserRepository us = new UserRepository();

            lang = us.Get(name).Language;
            usuario.Language = lang;

            //Tengo que agregar lo del idioma por defecto para que se bugee esta mierda.

            if (usuario.Tries < 3)
            {
                if (crypt.Encrypt(Password) != usuario.Password)
                {
                    //Save the encryption for later usage (la bd)
                    string pw = crypt.Encrypt(Password);

                    us.addTries(usuario);

                    throw new LoginException();
                }

                Session.GetInstance.Login(usuario);
               
                usuario.Tries = 0;
                us.resetTries(usuario);
            }
            else
            {
                us.blockUser(usuario);
                MessageBox.Show("El usuario ha sido bloqueado por cantidad de intentos");
                throw new LoginException();
            }
        }

            public void Logout()
        {
            Session.GetInstance.Logout();
        }
    }
}
