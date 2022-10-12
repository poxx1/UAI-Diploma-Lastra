using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utiles;

namespace DataAccess
{
    public class StockRepository
    {
        public List<StockModel> listStock()
        {
            SqlConnection connection = ConnectionSingleton.getConnection();
            List<StockModel> list = new List<StockModel>();

            try
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                var sql = $@"select * from [Stock]";

                cmd.CommandText = sql;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StockModel mm = new StockModel();
                    mm.Id = reader.GetInt32((reader.GetOrdinal("ID")));
                    mm.Quantity = reader.GetInt32((reader.GetOrdinal("Quantity")));
                    mm.StockLimit = reader.GetInt32((reader.GetOrdinal("StockLimit")));
                    mm.MiniumStock = reader.GetInt32(reader.GetOrdinal("MiniumStock"));
                    mm.Name = reader.GetString(reader.GetOrdinal("Name"));
                    mm.Descripcion = reader.GetString(reader.GetOrdinal("Description"));

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
        public bool addItem(StockModel item)
        {
            try
            {
                SqlConnection connection = ConnectionSingleton.getConnection();
                connection.Open();
                string query = $@"INSERT into [Stock]
                            ([Name]
                            ,[Description]
                            ,[Quantity])            
                        VALUES
                            ( @Name
                            , @Description
                            , @Quantity
                             )";


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;

                cmd.Parameters.Add(new SqlParameter("Name", item.Name));
                cmd.Parameters.Add(new SqlParameter("Description", item.Descripcion));
                cmd.Parameters.Add(new SqlParameter("Quantity", item.Quantity));

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
    }
}
