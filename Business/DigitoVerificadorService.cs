﻿using System;
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
        public List<DBUsers> ObtenerHashHorizontal()
        {
            List<DBUsers> usuarios = new List<DBUsers>();
            usuarios = ListdBUsers();

            try
            {
                foreach (DBUsers user in usuarios)
                {
                    user.digitoVerificador = DigitoVerificarUsuario(user);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error digitoverificando");
                MessageBox.Show(ex.Message);
                return new List<DBUsers>();
            }

            return usuarios;
        }
        public List<DigitoVerificadorModel> ListarDigitoVerificadorHorizontal()
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                List<DigitoVerificadorModel> lista = new List<DigitoVerificadorModel>();
                lista = userRepository.ListDigitoVerificadorHorizontal();
                return lista;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error trayendo datos desde la BD");
                MessageBox.Show(ex.Message);
                return new List<DigitoVerificadorModel>();
            }
        }
        public bool CompararDigitoVerificadorHorizontal()
        {
            List<DBUsers> dBUsers = new List<DBUsers>();
            List<DigitoVerificadorModel> digitos = new List<DigitoVerificadorModel>();

            dBUsers = ObtenerHashHorizontal();
            digitos = ListarDigitoVerificadorHorizontal();

            bool check = true;
            List<bool> listaChecker= new List<bool>();

            if (digitos.Count > 0 && dBUsers.Count > 0)
            {
                foreach (DBUsers user in dBUsers)
                {
                    foreach (DigitoVerificadorModel digito in digitos)
                    {
                        if(digito.digitoVerificador == user.digitoVerificador)
                        {
                            listaChecker.Add(true);
                            break;
                        }
                    }
                }
                    
                if (listaChecker.Contains(false) || listaChecker.Count != digitos.Count)
                {
                    check = false;
                    MessageBox.Show("Hay un item que no concuerda con la verificacion");
                }
            }
            else {
                MessageBox.Show("Error trayendo datos para verificar usuario, listas vacias");
                return false;
            }

            if (check) return true;
            else
            {
                MessageBox.Show("Error en la verificacion de los digitos");
                return false;
            }
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
        public bool verificarVerticalUsuarios()
        {
            try
            {
                //Verificar verticalmente usuarios
                string sinhashear = "";
                List<DBUsers> usuarios = ObtenerHashHorizontal();
                foreach (DBUsers user in usuarios)
                {
                    sinhashear += user.digitoVerificador + "##";
                }

                MessageBox.Show(sinhashear);

                Crypt crypt = new Crypt();
                string hashada = crypt.Encrypt(sinhashear);

                MessageBox.Show(hashada);

                //Verificar verticalmente tabla horizontal
                string sinhashearDVs = "";
                List<DigitoVerificadorModel> digitos = ListarDigitoVerificadorHorizontal();

                foreach (DigitoVerificadorModel digito in digitos)
                {
                    sinhashearDVs += digito.digitoVerificador;
                }

                MessageBox.Show(sinhashearDVs);

                string hashadaDVs = crypt.Encrypt(sinhashearDVs);

                MessageBox.Show(hashadaDVs);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculando el digito vertical");
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool dobleVerificacion()
        {
            bool result = false;

            if (verificarVerticalUsuarios() && CompararDigitoVerificadorHorizontal())
                result = true;

            return result;
        }
        public bool UpdateDigitoVerificadorHorizontalUsuario()
        {

            return true;
        }
        public bool UpdateDigitoVerificadorVerticalUsuario()
        {

            return true;
        }

        public DBUsers convertToDBUser(User user)
        {
            DBUsers newUser = new DBUsers();

            newUser.ID = user.Id;
            newUser.UserName = user.UserName;
            newUser.isBlocked = user.isBlocked;
            newUser.id_tipo = user.Tipo;
            newUser.Tries = user.Tries;
            newUser.id_dv = 1;
            newUser.Key_idioma = 1;
            newUser.Email = user.Email;

            return newUser;
        }
    }
}