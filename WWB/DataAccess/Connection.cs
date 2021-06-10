using System;
using System.Data.SqlClient;
namespace WorldWideBasketball.DataAccess
{
    public class Connection
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;


        public Connection()
        {
        }

        private void connectionString()
        {
            //con.ConnectionString = "Data Source=DESKTOP-08IE2T4;Initial Catalog=WWB;Integrated Security=True";
            //con.ConnectionString = "data source=127.0.0.1,1433; Database=WWB; User ID=SA;Password=MyPassword.1;";
            con.ConnectionString = "Data Source=DESKTOP-8CRGERR;Initial Catalog=WWB;Integrated Security=True";
        }

        public void open()
        {
            connectionString();
            this.con.Open();

            com.Connection = this.con;
        }

        public void close()
        {
            this.con.Close();
        }

        public SqlDataReader executeReader(string query)
        {
            this.com.CommandText = query;
            this.dr = this.com.ExecuteReader();
            return this.dr;
        }

        public void executeQuery(string query)
        {
            this.com.CommandText = query;
            this.com.ExecuteNonQuery();
        }

       
       
    }
}
