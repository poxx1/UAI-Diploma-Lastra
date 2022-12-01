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
        public List<ControlCambiosModel> ListarControlCambios()
        {
            DigitoVerificadorRepository dg = new DigitoVerificadorRepository();
            var list = dg.ListarControlCambios();
            return list;
        }
        public List<DBUsers> ObtenerHashHorizontal()
        {
            List<DBUsers> usuarios = new List<DBUsers>();
            usuarios = ListdBUsers();

            try
            {
                foreach (DBUsers user in usuarios)
                {
                    //user.digitoVerificador = user.digitoVerificador;//DigitoVerificarUsuario(user);
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
        public List<DigitoVerificadorModel> ListarDigitoVertical()
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                List<DigitoVerificadorModel> lista = new List<DigitoVerificadorModel>();
                lista = userRepository.ListDigitoVertical();
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

            DigitoVerificadorService dgs = new DigitoVerificadorService();

            dBUsers = ObtenerHashHorizontal();
            digitos = ListarDigitoVerificadorHorizontal();

            bool check = true;
            List<bool> listaChecker= new List<bool>();

            if (digitos.Count > 0 && dBUsers.Count > 0)
            {
                //foreach (DBUsers user in dBUsers)
                //{
                //    foreach (DigitoVerificadorModel digito in digitos)
                //    {
                //        if(digito.digitoVerificador == user.digitoVerificador && digito.digitoVerificador == DigitoVerificarUsuario(user))
                //        {
                //            listaChecker.Add(true);
                //            break;
                //        }
                //        //else { MessageBox.Show($"El usuario {user.UserName} tiene un cambio no esperado en sus datos. Por favor contacte a un administrador."); }
                //    }
                //}

                foreach (DigitoVerificadorModel digito in digitos)
                {
                    try
                    {
                        var user = dBUsers.Where(x => x.id_dv.ToString() == digito.id_dv).ToList().First();
                        if (user.digitoVerificador == digito.digitoVerificador)
                        {
                            listaChecker.Add(true);
                        }
                        else
                        {
                            MessageBox.Show($"El usuario {user.UserName} tiene un cambio no esperado en sus datos. Por favor contacte a un administrador.");
                            listaChecker.Add(false);
                        }

                    }
                    catch (Exception ex)
                    {
                        var usuarioRecuperado = dgs.obtenerUsuario(digito.digitoVerificador);
                        MessageBox.Show($"El usuario {usuarioRecuperado.UserName} tiene un cambio no esperado en sus datos. Por favor contacte a un administrador.");
                        listaChecker.Add(false);
                    }
                }

                if (listaChecker.Contains(false) || listaChecker.Count != digitos.Count)
                {
                    check = false;
                    if(listaChecker.Count != digitos.Count) MessageBox.Show("La cantidad de usuarios no coincide con la cantidad de digitos verificados. Por favor contactar al administrador del sistema");
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
        public bool InsertDigitoVerificador(DigitoVerificadorModel dv)
        {
            try
            {
                List<DigitoVerificadorModel> digitos = new List<DigitoVerificadorModel>();
                DigitoVerificadorRepository dr = new DigitoVerificadorRepository();

                dr.InsertHorizontal(dv);

                dr.UpdateHorizontalUsuario(dv);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        public DBUsers obtenerUsuario(string hash)
        {
            //id + UserName +  Password + Email + key_idioma + tries + isBlocked + id_tipo
       
            string[] usuario = hash.Split(new string[] { "##" }, StringSplitOptions.None);

            DBUsers user = new DBUsers();
            user.ID = Int32.Parse(usuario[0]);
            user.UserName = usuario[1];
            user.Password = usuario[2];
            user.Email = usuario[3];
            user.Key_idioma = Int32.Parse(usuario[4]);
            user.Tries = Int32.Parse(usuario[5]);
            user.isBlocked = bool.Parse(usuario[6]);
            user.id_tipo = Int32.Parse(usuario[7]);

            return user;
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

                //MessageBox.Show(sinhashear);

                Crypt crypt = new Crypt();
                string hashada = crypt.Encrypt(sinhashear);

                //MessageBox.Show(hashada);

                //Verificar verticalmente tabla horizontal
                string sinhashearDVs = "";
                List<DigitoVerificadorModel> digitos = ListarDigitoVerificadorHorizontal();

                foreach (DigitoVerificadorModel digito in digitos)
                {
                    sinhashearDVs += digito.digitoVerificador;
                }

                //MessageBox.Show(sinhashearDVs);

                string hashadaDVs = crypt.Encrypt(sinhashearDVs);

                //MessageBox.Show(hashadaDVs);

                DigitoVerificadorRepository dr = new DigitoVerificadorRepository();

                DigitoVerificadorModel dm = new DigitoVerificadorModel();
                dm.id_dv = "1";
                dm.digitoVerificador = hashadaDVs;
                dr.UpdateVertical(dm);

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
            try
            {
                bool result = false;

                if (CompararDigitoVerificadorHorizontal()&& ComprarDigitoVertical())
                    result = true;


                return result;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool ComprarDigitoVertical()
        {
            try
            {
                var lista = ListarDigitoVertical();
                if (lista.First().digitoVerificador == ComprarDigitoVerticalVsHorizontal())
                {
                    return true;
                }
                MessageBox.Show("Error validando digito verificador Vertical. Se hicieron cambios en la base de datos posiblemente no deseados");
                return false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error validando digito verificador Vertical. Se hicieron cambios en la base de datos posiblemente no deseados");

                return false;
            }
        }
        public string ComprarDigitoVerticalVsHorizontal()
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

                //MessageBox.Show(sinhashear);

                Crypt crypt = new Crypt();
                string hashada = crypt.Encrypt(sinhashear);

                //MessageBox.Show(hashada);

                //Verificar verticalmente tabla horizontal
                string sinhashearDVs = "";
                List<DigitoVerificadorModel> digitos = ListarDigitoVerificadorHorizontal();

                foreach (DigitoVerificadorModel digito in digitos)
                {
                    sinhashearDVs += digito.digitoVerificador;
                }

                //MessageBox.Show(sinhashearDVs);

                string hashadaDVs = crypt.Encrypt(sinhashearDVs);

                //MessageBox.Show(hashadaDVs);

                DigitoVerificadorRepository dr = new DigitoVerificadorRepository();

                DigitoVerificadorModel dm = new DigitoVerificadorModel();
                dm.id_dv = "1";
                dm.digitoVerificador = hashadaDVs;

                return dm.digitoVerificador;
            }
            catch (Exception)
            {
                MessageBox.Show("error validando el vertical");
                return "error";
            }
        }
        public bool UpdateDigitoVerificadorHorizontalUsuario(DigitoVerificadorModel digito)
        {
            DigitoVerificadorRepository dr = new DigitoVerificadorRepository();
            dr.UpdateHorizontal(digito);
            return true;
        }
        public bool UpdateDigitoVerificadorVerticalUsuario()
        {
            verificarVerticalUsuarios();
            return true;
        }
        public DBUsers convertToDBUser(User user)
        {
            DBUsers newUser = new DBUsers();

            newUser.ID = user.Id;
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.isBlocked = user.isBlocked;
            newUser.id_tipo = user.Tipo;
            newUser.Tries = user.Tries;
            newUser.id_dv = user.id_dv;
            newUser.Key_idioma = 1;
            newUser.digitoVerificador = user.digitoVerificador;
            newUser.Email = user.Email;

            //Falta completar seguro

            return newUser;
        }
        public bool InsertarCambioDB(DBUsers user)
        {
            try
            {
                DigitoVerificadorRepository dr = new DigitoVerificadorRepository();
                ControlCambiosModel ccm = new ControlCambiosModel();
                List<ControlCambiosModel> lista = new List<ControlCambiosModel>();
                lista = ListarControlCambios();

                ccm.ID_Cambio = lista.Count + 1;
                ccm.DigitoVerificador = user.digitoVerificador;
                ccm.Usuario_Afectado = user.ID.ToString();
                ccm.Fecha = DateTime.Now.ToString("MM/dd/yyyy");

                dr.InsertarCambioDB(ccm);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}