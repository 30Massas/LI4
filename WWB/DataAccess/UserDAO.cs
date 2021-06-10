using System;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WorldWideBasketball.Models;

namespace WorldWideBasketball.DataAccess
{
	public class UserDAO
	{

        private Connection connection = new Connection();

        public bool isValid(Account account)
        {
            this.connection.open();
            string query = "select * from [Utilizador] where Email='" + account.Email + "' and Password='" + account.Password + "'";
            SqlDataReader dr = this.connection.executeReader(query);

            if (dr.Read())
            {
                dr.Close();
                this.connection.close();
                return true;
            }
            else
            {
                dr.Close();
                this.connection.close();
                return false;
            }
        }

        public int Insert(Account account)
        {
            if (account.Email == null || account.Email == "" || !account.Email.Contains("@"))
            {
                return -1;
            }

            if (account.Password != account.ConfirmPassword)
            {
                return 2;
            }

            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime localDate = DateTime.Now;
            if (localDate < account.Data)
                return 8;

            TimeSpan span = localDate - account.Data;
            
            

            // Because we start at year 1 for the Gregorian
            // calendar, we must subtract a year here.
            int years = (zeroTime + span).Year - 1;

            if (years < 18 || years > 100)
            {
                return 8;
            }

            // 1, where my other algorithm resulted in 0.
            Console.WriteLine("Yrs elapsed: " + years);

            this.connection.open();

            string query = "select * from [Utilizador] where Email='" + account.Email + "'";
            SqlDataReader dr = this.connection.executeReader(query);
            if (dr.Read())
            {
                Console.WriteLine("User já Existente");
                dr.Close();
                this.connection.close();
                return 7;
            }
            else
            {
                dr.Close();
                Console.WriteLine("Registering ...");
                query = "Insert into [Utilizador] VALUES('" + account.Username + "', '" + account.Password + "', '" + account.Data + "', '" + account.Email + "', '" + account.Name + "');";
                try
                {
                    this.connection.executeQuery(query);
                    Console.WriteLine("Sucesso");
                    this.connection.close();
                    return 1;
                }
                catch (SqlException)
                {
                    Console.WriteLine("Erro no Registo");
                    this.connection.close();
                    return 6;
                }

            }
        }
	}
}

