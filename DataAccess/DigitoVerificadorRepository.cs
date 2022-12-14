using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Models.DBModel;
using Utiles;

namespace DataAccess
{
    public class DigitoVerificadorRepository
    {
        //PermissionsRepository permisosRepository;
        //LanguageRepository languageRepository;

        public void UpdateVertical(DBUsers user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set digitoverificador = @digitoverificador where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.ID));
                cmd.Parameters.Add(new SqlParameter("digitoverificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void UpdateHorizontal(DigitoVerificadorModel user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update DigitoVerificador set digitoVerificador = @digitoverificador where id_dv = @id";
                //Esto anda mal porque los ID no coinciden, entonces no updatea una verga
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoverificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public bool UpdateHorizontalUsuario(DigitoVerificadorModel user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set digitoverificador = @digitoverificador where id_dv = @id";
                //Esto anda mal porque los ID no coinciden, entonces no updatea una verga
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoverificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public List<ControlCambiosModel> ListarControlCambios()
        {        
            SqlConnection connection = ConnectionSingleton.getConnection();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"SELECT * from ControlCambios";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<ControlCambiosModel> list = new List<ControlCambiosModel>();

                //Machines machine = new Machines();
                while (reader.Read())
                {
                    ControlCambiosModel mm = new ControlCambiosModel();              
                    mm.ID_Cambio = int.Parse(reader.GetString(reader.GetOrdinal("id_change")));
                    mm.Fecha = reader.GetString(reader.GetOrdinal("change_date"));
                    mm.DigitoVerificador = reader.GetString(reader.GetOrdinal("change_data"));
                    mm.Usuario_Afectado = reader.GetString(reader.GetOrdinal("change_userAffected"));

                    list.Add(mm);
                }

                reader.Close();
                connection.Close();

                return list;
            }
            catch (Exception e)
            {
                connection.Close();
                MessageBox.Show(e.Message);
                return new List<ControlCambiosModel>();
                //throw e;
            }
            
        }
        public void UpdateVertical(DigitoVerificadorModel user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update DigitoVerificadorVertical set digitoVerificador = @digitoverificador where id_dv_v =@id_dv_v";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id_dv_v", "1"));
                cmd.Parameters.Add(new SqlParameter("digitoVerificador", user.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public bool InsertHorizontal(DigitoVerificadorModel digitoVerificadorModel)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into [DigitoVerificador]
                            ([id_dv]
                            ,[digitoVerificador]
                            )            
                        VALUES
                            ( @id_dv
                            , @digitoVerificador                        
                             )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("id_dv", digitoVerificadorModel.id_dv));
                cmd.Parameters.Add(new SqlParameter("digitoVerificador", digitoVerificadorModel.digitoVerificador));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
                //throw ex;
            }
        }

        public bool InsertarCambioDB(ControlCambiosModel user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into [ControlCambios]
                            ([id_change]
                            ,[change_data]
                            ,[change_date]
                            ,[change_userAffected]
                            )            
                        VALUES
                            ( @id_change
                            , @change_data                        
                            , @change_date                        
                            , @change_userAffected                        
                             )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("id_change", user.ID_Cambio));
                cmd.Parameters.Add(new SqlParameter("change_data", user.DigitoVerificador));
                cmd.Parameters.Add(new SqlParameter("change_date", user.Fecha));
                cmd.Parameters.Add(new SqlParameter("change_userAffected", user.Usuario_Afectado));

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
                //throw ex;
            }
        }
    }
}
