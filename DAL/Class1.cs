using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class Class2
    {

               public static string connectionString = "Data Source=DESKTOP-OCJ8U5N\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
             SqlConnection connection=new SqlConnection(connectionString);

            public void Open()
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }

            public void Close()
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            public int ExecuteNonQuery(string storedProcedureName, SqlParameter[] parameters)
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                Open();
                int result = command.ExecuteNonQuery();
                Close();

                return result;
            }

            public DataTable ExecuteQuery(string storedProcedureName, SqlParameter[] parameters)
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                Open();
                adapter.Fill(dataTable);
                Close();

                return dataTable;
            }
        }

}
