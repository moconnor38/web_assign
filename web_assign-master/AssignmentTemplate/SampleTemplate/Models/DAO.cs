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

        #region Books
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

        public List<Game1> ShowAllGames1()
        {
            List<Game1> gameList = new List<Game1>();
            SqlCommand cmd;
            SqlDataReader reader;
            //Calling connection method to establish connection string
            Connection();
            cmd = new SqlCommand("SELECT * FROM Game1", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            try
            {

                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game1 game = new Game1();
                    game.DatePublished = DateTime.Parse(reader["DatePublished"].ToString());
                    game.Developer = reader["Developer"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.Title = reader["Title"].ToString();
                    game.Price = decimal.Parse(reader["Price"].ToString());
                    game.Genre = reader["Genre"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    using (MemoryStream ms = new MemoryStream((byte[])reader["GameImage"]))
                    {
                        //game.GameImage= ms.ToArray(); not sure why this isn't working, must ask Shazia
                    }

                    gameList.Add(game);
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

            return gameList;
        }
        #endregion

        #region Transaction
        public int AddTransaction(string transactionId, DateTime date, decimal totalprice, string email)
        {
            int count = 0;
            SqlCommand cmd;

            Connection();

            cmd = new SqlCommand("uspInsertTransactionTable", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", transactionId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@price", totalprice);

            cmd.Parameters.AddWithValue("@email", email);

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

        public int AddTransactionItem(string transactionId, ItemModel item)
        {
            int count = 0;
            SqlCommand cmd;

            Connection();

            cmd = new SqlCommand("uspTransactionItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@tranId", transactionId);
            cmd.Parameters.AddWithValue("@id", item.ItemId);

            cmd.Parameters.AddWithValue("@quantity", item.Quantity);


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
        #endregion


    }
}