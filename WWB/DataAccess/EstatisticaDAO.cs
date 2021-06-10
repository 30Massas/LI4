using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WorldWideBasketball.Models;

namespace WorldWideBasketball.DataAccess
{
    public class EstatisticaDAO
    {

        private Connection connection = new Connection();

        public Estatistica getEstatisticaByID(int id)
        {
            this.connection.open();
            string query = "select * from [Estatisticas] where Equipa_Id = '"+id+"';";

            SqlDataReader dr = this.connection.executeReader(query);

            Estatistica e = null;

            if (dr.Read())
            {
                e = ReadSingleRow((IDataRecord)dr);
            }
            dr.Close();
            this.connection.close();

            return e;
        }
        private Estatistica ReadSingleRow(IDataRecord record)
        {
            return new Estatistica(Int32.Parse(record[0].ToString()),
                                Int32.Parse(record[1].ToString()),
                                Int32.Parse(record[2].ToString()),
                                Int32.Parse(record[3].ToString()),
                                Int32.Parse(record[4].ToString()),
                                Int32.Parse(record[5].ToString()),
                                Int32.Parse(record[6].ToString())
                                );

        }

    }


}
