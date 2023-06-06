using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Class1
    {
        Class2 obj = new Class2();

        

        public bool CreateUser(string username, string password, string email)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@un", username),
                new SqlParameter("@ps", password),
                new SqlParameter("@em", email)
            };

            try
            {
                obj.ExecuteNonQuery("spCreateUser", parameters);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@un", username),
                new SqlParameter("@ps", password)
            };

            DataTable dataTable = obj.ExecuteQuery("spGetUser", parameters);

            return dataTable.Rows.Count > 0;
        }

        public bool CreateDestination(string destinationName, DateTime departureDate, DateTime returnDate, string transportType, string hotelName, decimal price)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@DestinationName", destinationName),
                new SqlParameter("@DepartureDate", departureDate),
                new SqlParameter("@ReturnDate", returnDate),
                new SqlParameter("@TransportType", transportType),
                new SqlParameter("@HotelName", hotelName),
                new SqlParameter("@Price", price)
            };

            try
            {
                obj.ExecuteNonQuery("spCreateDestination", parameters);
                return true;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50000)
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw ex;
                }
            }
        }

        public DataTable GetDestinations()
        {
            return obj.ExecuteQuery("spGetDestinations", null);
        }

    }
}
