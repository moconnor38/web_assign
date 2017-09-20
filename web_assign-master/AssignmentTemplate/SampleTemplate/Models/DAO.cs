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
            cmd.Parameters.AddWithValue("@renew", user.Renew.ToString());
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


        public int AddToLibrary(string email, string gamename)
        {
            int count = 0;
            SqlCommand cmd;

            Connection();

            cmd = new SqlCommand("uspInsertGameIntoMemberLibrary", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@gamename", gamename);


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

        public List<Game> ShowLibraryGames(string email)
        {
            List<Game> gamelist = new List<Game>();
            SqlCommand cmd;
            SqlDataReader reader;
            //Calling connection method to establish connection string
            Connection();
            cmd = new SqlCommand("uspDisplayMemberLibrary", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game();
                    game.Title = reader["GameName"].ToString();

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

        public List<UserModel> SearchMember(string search)
        {
            List<UserModel> userList = new List<UserModel>();

            int count = 0;

            SqlDataReader reader;
            Connection();
            SqlCommand cmd = new SqlCommand("uspSearchMember", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", search);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UserModel user = new UserModel();

                    user.Username = reader["UserName"].ToString();
                    //game.Developer = reader["Developer"].ToString();
                    //game.Genre = reader["Genre"].ToString();
                    //game.Publisher = reader["Publisher"].ToString();
                    //game.GameImage = reader["GameImage"].ToString();
                    //game.DatePublished = DateTime.Parse(reader["DateReleased"].ToString());

                    userList.Add(user);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return userList;
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
            cmd = new SqlCommand("uspAllGames1", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game();
                    game.Title = reader["GameName"].ToString();
                    //game.Developer = reader["Developer"].ToString();
                    game.Genre = reader["Genre"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.DatePublished = DateTime.Parse(reader["DateReleased"].ToString());
                    
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


        public List<Game> ShowAllGames1()
        {
            List<Game> gamelist = new List<Game>();
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
                    Game game = new Game();
                    game.DatePublished = DateTime.Parse(reader["DateReleased"].ToString());
                    game.Developer = reader["Developer"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.Title = reader["GameName"].ToString();
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


        public List<Game> BrowseByGenre(string genre)
        {
            List<Game> gameList = new List<Game>();

            int count = 0;

            SqlDataReader reader;
            Connection();
            SqlCommand cmd = new SqlCommand("uspBrowseGames", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Genre", genre);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game();

                    game.Title = reader["GameName"].ToString();
                    //game.Developer = reader["Developer"].ToString();
                    game.Genre = reader["Genre"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.DatePublished = DateTime.Parse(reader["DateReleased"].ToString());

                    gameList.Add(game);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return gameList;
        }



        public List<Game> SearchGame(string search)
        {
            List<Game> gameList = new List<Game>();

            int count = 0;

            SqlDataReader reader;
            Connection();
            SqlCommand cmd = new SqlCommand("uspSearch", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", search);
            try
            {
                conn.Open();
                count = cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Game game = new Game();

                    game.Title = reader["GameName"].ToString();
                    //game.Developer = reader["Developer"].ToString();
                    game.Genre = reader["Genre"].ToString();
                    game.Publisher = reader["Publisher"].ToString();
                    game.GameImage = reader["GameImage"].ToString();
                    game.DatePublished = DateTime.Parse(reader["DateReleased"].ToString());

                    gameList.Add(game);
                }
            }
            catch (Exception ex)
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

    }
}