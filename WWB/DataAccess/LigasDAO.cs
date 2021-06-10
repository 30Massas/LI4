using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WorldWideBasketball.Models;
namespace WorldWideBasketball.DataAccess
{
    public class LigasDAO

    {
        private Connection connection = new Connection();


        public Dictionary<string,List<Liga>> getAllLigas()
        {
            Dictionary<string, List<Liga>> dict = new Dictionary<string, List<Liga>>();

            this.connection.open();
            string query = "select * from [Liga];";
            SqlDataReader dr = this.connection.executeReader(query);

            // Call Read before accessing data.
            while (dr.Read())
            {
                Liga l = ReadSingleRow((IDataRecord)dr);
                if (!dict.ContainsKey(l.Localizacao))
                {
                    List<Liga> list = new List<Liga>();
                    list.Add(l);
                    dict.Add(l.Localizacao, list);
                }
                else
                {
                    dict[l.Localizacao].Add(l);
                }
            }
            dr.Close();
            this.connection.close();
            return dict;
        }

        public List<Liga> getLigasByCountry(string country)
        {
            List<Liga> ligas = new List<Liga>();
            this.connection.open();
            string query1 = "select * from [Liga] where Localizacao='" + country + "';";

            SqlDataReader dr = this.connection.executeReader(query1);
            
            while (dr.Read())
            {
                Liga l = ReadSingleRow((IDataRecord)dr);
                if (!ligas.Contains(l))
                    ligas.Add(l);
            }
            dr.Close();
            this.connection.close();
            return ligas;
        }

        public List<Liga> getLigasLike(string key)
        {
            List<Liga> ligas = new List<Liga>();

            this.connection.open();
            string query1 = "select * from [Liga] where Nome Like '%" + key + "%';";

            SqlDataReader dr = this.connection.executeReader(query1);
            
            while (dr.Read())
            {
                Liga l = ReadSingleRow((IDataRecord)dr);
                if (!ligas.Contains(l))
                    ligas.Add(l);
            }
            dr.Close();
            this.connection.close();
            return ligas;
        }

        public Liga getLigaById(int id)
        {
            this.connection.open();
            Console.WriteLine("[LigasDAO]: " + id);
            string query = "select * from [Liga] where id='" + id + "';";
            SqlDataReader dr = this.connection.executeReader(query);
            Liga r = null;
            if (dr.Read())
            {
                Console.WriteLine((IDataRecord)dr);
                r = ReadSingleRow((IDataRecord)dr);
            }
            dr.Close();
            this.connection.close();
            return r;
        }

        private Liga ReadSingleRow(IDataRecord record)
        {
            return new Liga(Int32.Parse(record[0].ToString()), record[1].ToString(), record[2].ToString());

        }
    }
}