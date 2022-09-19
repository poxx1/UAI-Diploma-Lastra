using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Utiles;

namespace DataAccess
{
    public class UserRepository
    {
        PermissionsRepository permisosRepository;
        LanguageRepository languageRepository;

        public UserRepository()
        {
            permisosRepository = new PermissionsRepository();
            languageRepository = new LanguageRepository();
        }
        public void Create(User user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand cmd;
                try
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = $@"INSERT INTO [dbo].[Users]
                                    ([UserName]
                                    ,[Password]
                                    ,[Email]
                                    ,[key_idioma]
                                    ,[isBlocked]
                                    ,[Tries]
                                    ,[id_tipo])
                                    VALUES
                                    (@UserName
                                    ,@Password
                                    ,@Email
                                    ,@key_idioma
                                    ,@isBlocked
                                    ,@Tries
                                    ,@Tipo
                                     )";

                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new SqlParameter("UserName", user.UserName));
                    cmd.Parameters.Add(new SqlParameter("Password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("key_idioma", user.Language.ID));
                    cmd.Parameters.Add(new SqlParameter("isBlocked", user.isBlocked));
                    cmd.Parameters.Add(new SqlParameter("Tries", user.Tries));
                    cmd.Parameters.Add(new SqlParameter("Tipo", user.Tipo));

                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.CommandText = $@"select * from Users where UserName = @Name;";
                    cmd.Parameters.Add(new SqlParameter("Name", user.UserName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    user.Id = int.Parse(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString());
                    reader.Close();

                    cmd = new SqlCommand();
                    cmd.CommandText = $@"INSERT INTO [dbo].[usuario_data]
                                   ([id_usuario]
                                    ,[nombre]
                                    ,[apellido]
                                    ,[telefono]
                                    ,[direccion]
                                    ,[dni])
                                    VALUES
                                    (@id
                                    ,@nombre
                                    ,@apellido
                                    ,@telefono  
                                    ,@direccion
                                    ,@dni
                                    )";

                    cmd.Connection = connection;
                    cmd.Transaction = transaction;
                    cmd.Parameters.Add(new SqlParameter("id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("nombre", user.Name));
                    cmd.Parameters.Add(new SqlParameter("apellido", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("telefono", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("direccion", user.Adress));
                    cmd.Parameters.Add(new SqlParameter("dni", user.Dni));

                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    connection.Close();

                }
                catch
                {
                    transaction.Rollback();
                    connection.Close();
                    throw;
                }
                SavePermissions(user);

            }
            catch
            {
                throw;
            }
        }

        public bool CheckIfExistUserName(User user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select UserName from Users where UserName = '{user.UserName}'";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<string>();

                while (reader.Read())
                {

                    try
                    {
                        string username = (string)reader.GetValue(reader.GetOrdinal("UserName"));

                        lista.Add(username);
                    }
                    catch (Exception)
                    {
                        //Si aca salta la exception es porque no habia nada en la tabla
                    }
                  
                }

                reader.Close();
                connection.Close();

                if (lista.Count == 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer la lista de tipos de usuario");
                throw ex;
            }

        }

        public bool CheckIfExist(User user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select id_usuario from usuario_data where dni = {user.Dni}";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<int>();

                while (reader.Read())
                {
                    try
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id_usuario"));

                        lista.Add(id);
                    }
                    catch(Exception)
                    {
                        //Si aca salta la exception es porque no habia nada en la tabla
                    }
                }

                reader.Close();
                connection.Close();

                if(lista.Count == 0)
                return false;
                else
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer la lista de tipos de usuario");
                throw ex;
            }

            //return false;
        }

        public List<user_typeModel> GetAllTypes()
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from usuario_tipo;";

                cmd.CommandText = sql;

                var reader = cmd.ExecuteReader();

                var lista = new List<user_typeModel>();

                while (reader.Read())
                {
                    user_typeModel user = new user_typeModel()
                    {
                        id = int.Parse(reader.GetValue(reader.GetOrdinal("Id_tipo")).ToString()),
                        desc = reader.GetValue(reader.GetOrdinal("Tipo_desc")).ToString(),
                    };
                    lista.Add(user);
                }

                reader.Close();
                connection.Close();

                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al traer la lista de tipos de usuario");
                throw ex;
            }
        }

        public User Get(String Name)
        {
            User user = null;
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = $@"select * from Users u inner join usuario_data ud on u.id_usuario = ud.id_usuario  where UserName = @UserName;";
                cmd.Parameters.Add(new SqlParameter("UserName", Name));

                SqlDataReader reader = cmd.ExecuteReader();

                int idLanguaje = 0;
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = int.Parse(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString()),
                        Name= reader.GetValue(reader.GetOrdinal("UserName")).ToString(),
                        Password = reader.GetValue(reader.GetOrdinal("Password")).ToString(),
                        Email = reader.GetValue(reader.GetOrdinal("Email")).ToString(),
                        LastName = reader.GetValue(reader.GetOrdinal("apellido")).ToString(),
                        UserName = reader.GetValue(reader.GetOrdinal("nombre")).ToString(),
                        Adress = reader.GetValue(reader.GetOrdinal("direccion")).ToString(),
                        Phone = reader.GetValue(reader.GetOrdinal("telefono")).ToString(),
                        Dni = reader.GetValue(reader.GetOrdinal("dni")).ToString(),
                        isBlocked = reader.GetBoolean(reader.GetOrdinal("isBlocked")),
                        Tries = int.Parse(reader.GetValue(reader.GetOrdinal("Tries")).ToString())
                    };
                    idLanguaje = int.Parse(reader.GetValue(reader.GetOrdinal("key_idioma")).ToString());
                }

                reader.Close();
                connection.Close();

                if (user != null)
                {
                    permisosRepository.FillUserComponents(user);
                    user.Language = languageRepository.GetLanguage(idLanguaje);
                }

                return user;
            }
            catch
            {
                throw;
            }
        }
        public List<User> GetAll()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            connection.Open();
            var cmd = new SqlCommand();
            cmd.Connection = connection;

            var sql = $@"select * from Users u left join usuario_data ud on ud.id_usuario = u.id_usuario;";

            cmd.CommandText = sql;

            var reader = cmd.ExecuteReader();

            var lista = new List<User>();

            while (reader.Read())
            {
                User user = new User()
                {
                    Id = int.Parse(reader.GetValue(reader.GetOrdinal("id_usuario")).ToString()),
                    Name= reader.GetValue(reader.GetOrdinal("UserName")).ToString(),
                    Password = reader.GetValue(reader.GetOrdinal("Password")).ToString(),
                    Email = reader.GetValue(reader.GetOrdinal("Email")).ToString(),
                    LastName = reader.GetValue(reader.GetOrdinal("apellido")).ToString(),
                    UserName = reader.GetValue(reader.GetOrdinal("nombre")).ToString(),
                    Adress = reader.GetValue(reader.GetOrdinal("direccion")).ToString(),
                    Phone = reader.GetValue(reader.GetOrdinal("telefono")).ToString(),
                    Dni = reader.GetValue(reader.GetOrdinal("dni")).ToString(),
                    Tries = int.Parse(reader.GetValue(reader.GetOrdinal("Tries")).ToString()),
                    isBlocked = reader.GetBoolean(reader.GetOrdinal("isBlocked")),
                    Tipo = int.Parse(reader.GetValue(reader.GetOrdinal("id_tipo")).ToString())
                };
                lista.Add(user);
            }

            reader.Close();
            connection.Close();

            //vinculo los usuarios con las patentes y familias que tiene configuradas.
            foreach (var user in lista)
            {
                permisosRepository.FillUserComponents(user);
            }

            return lista;
        }
        public void SavePermissions(User user)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = $@"delete from usuarios_permisos where id_usuario=@id;";
                cmd.Parameters.Add(new SqlParameter("id", user.Id));
                cmd.ExecuteNonQuery();

                foreach (var item in user.Permissions)
                {
                    cmd = new SqlCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = $@"insert into usuarios_permisos (id_usuario,id_permiso) values (@id_usuario,@id_permiso) "; ;
                    cmd.Parameters.Add(new SqlParameter("id_usuario", user.Id));
                    cmd.Parameters.Add(new SqlParameter("id_permiso", item.Id));

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdatePassword(User user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set Password = @password where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));
                cmd.Parameters.Add(new SqlParameter("Password", user.Password));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void updateUser(User user)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();

            SqlTransaction transaction;
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd;

                    string query = $@"UPDATE [dbo].[Users]
                   SET [Email] = @Email
                        ,[UserName] = @UserName
                      where id_usuario =@id
                    ";

                    cmd = new SqlCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.Parameters.Add(new SqlParameter("id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("UserName", user.Name));

                    cmd.ExecuteNonQuery();

                    query = $@"UPDATE [dbo].[usuario_data]
                               SET 
                                   [nombre] = @nombre
                                  ,[apellido] = @apellido
                                  ,[telefono] = @telefono
                                  ,[direccion] = @direccion
                                  ,[dni] = @dni
                                  where id_usuario =@id
                                ";

                    cmd = new SqlCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.Parameters.Add(new SqlParameter("id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("nombre", user.Name));
                    cmd.Parameters.Add(new SqlParameter("telefono", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("apellido", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("direccion", user.Adress));
                    cmd.Parameters.Add(new SqlParameter("dni", user.Dni));

                    cmd.ExecuteNonQuery();
                    transaction.Commit();

                    connection.Close();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void addTries(User user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set Tries = @tries where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));
                cmd.Parameters.Add(new SqlParameter("tries", user.Tries + 1));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void resetTries(User user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set Tries = 0 where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));


                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void blockUser(User user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set isBlocked = 1 where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));


                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
        public void unblockUser(User user)
        {

            SqlConnection connection = ConnectionSingleton.getConnection();
            try
            {
                connection.Open();
                string query = $@"update Users set Blocked = 0 where id_usuario =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.Parameters.Add(new SqlParameter("id", user.Id));


                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                connection.Close();
                throw;
            }
        }
    }
}