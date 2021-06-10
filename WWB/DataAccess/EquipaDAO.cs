using System;
using System.Collections.Generic;
using WorldWideBasketball.Models;
using System.Data.SqlClient;
using System.Data;

namespace WorldWideBasketball.DataAccess
{
    public class EquipaDAO
    {
        private Connection connection = new Connection();

        public List<Equipa> getEquipasLike(string name)
        {
            string query = "select * from [Equipa] where Nome Like '%" + name + "%';";
            return getAllTeamsByQuery(query);
        }

        public List<Equipa> getEquipasByLeage(int leagueID)
        {
            string query = "select * from [Equipa] where Liga_Id='"+ leagueID + "';";
            return getAllTeamsByQuery(query);   
        }

        public Dictionary<int,string> getStringEquipasByLeague(int idLeague)
        {

            Dictionary<int, string> dictNames = new Dictionary<int, string>();
            this.connection.open();
            SqlDataReader dr = this.connection.executeReader("select Id,Nome from [Equipa] where Liga_Id='" + idLeague + "';");
            while (dr.Read())
            {
                dictNames.Add(Int32.Parse( ((IDataRecord)dr)[0].ToString()), ((IDataRecord)dr)[1].ToString());
            }
            dr.Close();
            this.connection.close();
            return dictNames;

        }

        public Equipa getEquipaById(int id)
        {
            this.connection.open();
            string query = "select * from [Equipa] where id='" + id + "';";
            SqlDataReader dr = this.connection.executeReader(query);
            Equipa e = null;
            if (dr.Read())
            {
                e = ReadSingleRow((IDataRecord)dr);
            }
            dr.Close();
            this.connection.close();
            return e;
        }
        private List<Equipa> getAllTeamsByQuery(string query)
        {
            List<Equipa> lista = new List<Equipa>();
            this.connection.open();
            SqlDataReader dr = this.connection.executeReader(query);

            while (dr.Read())
            {
                Equipa e = ReadSingleRow((IDataRecord)dr);
                if (!lista.Contains(e))
                    lista.Add(e);
            }
            dr.Close();
            this.connection.close();
            lista.Sort();
            return lista;
        }

        private Equipa ReadSingleRow(IDataRecord record)
        {
            return new Equipa(Int32.Parse(record[0].ToString()), record[1].ToString(), record[2].ToString(),Int32.Parse(record[3].ToString()));
        }
    }
}
