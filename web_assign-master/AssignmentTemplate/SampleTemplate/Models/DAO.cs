using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.Configuration;
using System.IO;

namespace SampleTemplate.Models
{
    public class DAO
    {
        SqlConnection conn;
        public string message = "";

        public void Connection ()
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["conStringLocal"].ConnectionString);
        }
        //public int Insert ()
        #region User
        //Method for inserting data to Database
        public int Insert(UserModel user)
        {
            //count shows the number of affected rows
            int count = 0;
            SqlCommand cmd;
            string password;
            Connection();
            cmd = new SqlCommand("uspInsertUserTable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first", user.FirstName);
            cmd.Parameters.AddWithValue("@last", user.LastName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@user", user.Username);
            cmd.Parameters.AddWithValue("@renew", DateTime.Now.AddDays(30));
            password = Crypto.HashPassword(user.Password);
            message = password;
            cmd.Parameters.AddWithValue("@pass", password);

            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return count;
        }

        //Method for checking login
        public string CheckLogin(UserModel user)
        {
            string firstName = null;
            SqlCommand cmd;
            SqlDataReader reader;
            string password;
            Connection();
            cmd = new SqlCommand("uspCheckLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email", user.Email);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    password = reader["Pass"].ToString();
                    if (Crypto.VerifyHashedPassword(password, user.Password))
                    {
                        firstName = reader["FirstName"].ToString();
                    }

                }
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            catch (FormatException ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return firstName;
        }
        #endregion

        #region Games
        public List<Game> ShowAllGames()
        {
            List<Game> gamelist = new List<Game>();
            SqlCommand cmd;
            SqlDataReader reader;
            //Calling connection method to establish connection string
            Connection();
            cmd = new SqlCommand("uspAllGames", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game();
                    game.DatePublished = DateTime.Parse(reader["DatePublished"].ToString());
                    game.Developer = reader["Developer"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.Title = reader["Title"].ToString();
                    game.Price = decimal.Parse(reader["Price"].ToString());
                    game.Genre = reader["Genre"].ToString();
                    gamelist.Add(game);
                }
            }
            catch (SqlException ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return gamelist;
        }        
        #endregion
        
    }
}