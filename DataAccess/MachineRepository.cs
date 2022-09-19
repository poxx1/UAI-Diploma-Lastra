using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Windows.Forms;
using Utiles;

namespace DataAccess
{
    public  class MachineRepository
    {
        public void SaveMachine(Machines machine)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into Machines
                            ([Id_Brand]
                            ,[Id_Model]
                            ,[Id_Color]
                            ,[Description]
                            ,[Elements]
                            ,[Picture]
                            ,[Failure]
                            ,[isRevisada]
                            ,[isApproved]
                            ,[Id_User]
                            ,[Id_Client]
                            ,[Reparation]
                            ,[possibleToRepair]
                            ,[Hours])
            
                        VALUES
                            ( @Id_Brand
                            , @Id_Model
                            , @Id_Color
                            , @Description
                            , @Elements
                            , @Picture
                            , @Failure
                            , @isRevisada
                            , @isApproved
                            , @Id_User
                            , @Id_Client
                            , @Reparation
                            , @possibleToRepair
                            , @Hours
                            )";


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                //cmd.Parameters.Add(new SqlParameter("Id_Machine", machine.Id_Machine));
                cmd.Parameters.Add(new SqlParameter("Id_Brand", machine.Brand));
                cmd.Parameters.Add(new SqlParameter("Id_Model", machine.Model));
                cmd.Parameters.Add(new SqlParameter("Id_Color", machine.Color));
                cmd.Parameters.Add(new SqlParameter("Description", machine.Description));
                cmd.Parameters.Add(new SqlParameter("Elements", machine.Elements));
                cmd.Parameters.Add(new SqlParameter("Picture", machine.Picture));
                cmd.Parameters.Add(new SqlParameter("Failure", machine.Failure));
                cmd.Parameters.Add(new SqlParameter("isRevisada", machine.isReviewed));
                cmd.Parameters.Add(new SqlParameter("isApproved", machine.isApproved));
                cmd.Parameters.Add(new SqlParameter("Id_User", machine.Id_User));
                cmd.Parameters.Add(new SqlParameter("Id_Client", machine.Id_Client));
                cmd.Parameters.Add(new SqlParameter("Reparation", machine.Reparation));
                cmd.Parameters.Add(new SqlParameter("possibleToRepair", machine.isPossibleToRepair));
                cmd.Parameters.Add(new SqlParameter("Hours", machine.Hours));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");

                throw ex;
            }
        }

        public bool CheckIfExist(Machines machine)
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            //List<Machines> list = new List<Machines>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select Id_Machine from Machines where Id_Machine = {machine.Id_Machine.ToString()}";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<int> list = new List<int>();

                //Machines machine = new Machines();
                while (reader.Read())
                {
                    //User_MachineModel mm = new User_MachineModel();
                    int id = int.Parse(reader.GetString(reader.GetOrdinal("Id_Maquina")));
                    list.Add(id);
                }

                reader.Close();
                connection.Close();

                if (list.Count > 0)
                {
                    return true;
                }
                else { return false; }     

                //return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error validando existencia");
                connection.Close();
                throw e;
            }
        }

        public List<User_MachineModel> listMachinesToRepair()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            //List<Machines> list = new List<Machines>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"SELECT * from Reparador";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<User_MachineModel> list = new List<User_MachineModel>();

                //Machines machine = new Machines();
                while (reader.Read())
                {
                    User_MachineModel mm = new User_MachineModel();
                    mm.Id_machine = int.Parse(reader.GetString(reader.GetOrdinal("Id_Maquina")));
                    mm.Id_user = int.Parse(reader.GetString(reader.GetOrdinal("Id_User")));
                    mm.Time = int.Parse(reader.GetString(reader.GetOrdinal("Horas")));

                    list.Add(mm);
                }

                reader.Close();
                connection.Close();

                return list;
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
        }

        public List<ColorModel> listColors()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            //List<Machines> list = new List<Machines>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"SELECT * from Colors";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                List<ColorModel> list = new List<ColorModel>();

                //Machines machine = new Machines();
                while (reader.Read())
                {
                    ColorModel color = new ColorModel();
                    color.id_color = int.Parse(reader.GetString(reader.GetOrdinal("Id_Color")));
                    color.desc = reader.GetString(reader.GetOrdinal("Color_Desc"));

                    list.Add(color);
                }

                reader.Close();
                connection.Close();

                return list;
            }
            catch (Exception e)
            {
                connection.Close();
                MessageBox.Show("Error");
                throw e;
            }
        }

        public void LoadMachine()
        {
            
        }

        public void DeleteMachine()
        { 
            
        }
        
        public List<Machines> listMachines()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            List<Machines> list = new List<Machines>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"SELECT * from Machines";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                //Machines machine = new Machines();
                while (reader.Read())
                {
                    Machines machine = new Machines();

                    machine.Id_Machine = reader.GetInt32(reader.GetOrdinal("Id_Machine"));
                    machine.Description = reader.GetString(reader.GetOrdinal("Description"));
                    machine.Color = reader.GetString(reader.GetOrdinal("Id_Color"));
                    machine.Elements = reader.GetString(reader.GetOrdinal("Elements"));
                    machine.Brand = reader.GetString(reader.GetOrdinal("Id_Brand"));
                    machine.Picture = reader.GetString(reader.GetOrdinal("Picture"));
                    machine.Failure = reader.GetString(reader.GetOrdinal("Failure"));
                    machine.Model = reader.GetString(reader.GetOrdinal("Id_Model"));
                    machine.isApproved = (reader.GetBoolean(reader.GetOrdinal("isApproved")));
                    machine.isPossibleToRepair = (reader.GetBoolean(reader.GetOrdinal("possibleToRepair")));
                    machine.isReviewed = (reader.GetBoolean(reader.GetOrdinal("isRevisada")));
                    machine.Id_Client = Int32.Parse(reader.GetString(reader.GetOrdinal("Id_Client")));
                    machine.Id_User = Int32.Parse(reader.GetString(reader.GetOrdinal("Id_User")));
                    machine.Reparation = reader.GetString(reader.GetOrdinal("Reparation"));
                    machine.Hours = Int32.Parse(reader.GetString(reader.GetOrdinal("Hours")));

                    list.Add(machine);
                }

                reader.Close();
                connection.Close();

                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error");

                connection.Close();
                throw e;
            }
        }

        public void Approval(Machines machine)
        {
            //UPDATE Machines SET isApproved = @isApproved where Id_Machine = @Id_Machine
           try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"UPDATE Machines SET isApproved = @isApproved, Id_User = @Id_User where Id_Machine = @Id_Machine";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Id_Machine", machine.Id_Machine));
                cmd.Parameters.Add(new SqlParameter("Id_User", machine.Id_User));
                cmd.Parameters.Add(new SqlParameter("isApproved", machine.isApproved));

                cmd.ExecuteNonQuery();
                connection.Close();

                //Segunda parte

           

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");

                throw ex;
            }
        }

        public void Assing(Machines machine)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();

                connection = ConnectionSingleton.getConnection();
                connection.Open();

                string query = $@"INSERT into reparador
                            ([Id_Maquina]                  
                            ,[Id_User]
                            ,[Horas])
                        VALUES
                            (@Id_Maquina
                            , @Id_User
                            , @Horas
                            )";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Id_Maquina", machine.Id_Machine));
                cmd.Parameters.Add(new SqlParameter("Id_User", machine.Id_User));
                cmd.Parameters.Add(new SqlParameter("Horas", machine.Hours));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la maquina y el horario a la BD");
                throw ex;
            }
        }
        public void Review(Machines machine)
        {
            //UPDATE Machines SET isRevisada = isRevisada, Reparation = @Reparation, possibleToRepair = @possibleToRepair where Id_Machine = @Id_Machine
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"UPDATE Machines SET isRevisada = @isRevisada, Reparation = @Reparation, 
                    possibleToRepair = @possibleToRepair, Hours = @Hours where Id_Machine = @Id_Machine";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Id_Machine", machine.Id_Machine));
                cmd.Parameters.Add(new SqlParameter("isRevisada", machine.isReviewed));
                cmd.Parameters.Add(new SqlParameter("Reparation", machine.Reparation));
                cmd.Parameters.Add(new SqlParameter("possibleToRepair", machine.isPossibleToRepair));
                cmd.Parameters.Add(new SqlParameter("Hours", machine.Hours));

                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");

                throw ex;
            }
        }
    }
}
