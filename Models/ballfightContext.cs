using BallFight.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;



namespace ballfight.Models
{
    public class ballfightContext
    {

        


        public string ConnectionString { get; set; }

            public ballfightContext(string connectionString)
            {
                this.ConnectionString = connectionString;
            }

            private MySqlConnection GetConnection()
            {

                return new MySqlConnection(ConnectionString);
            }



        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user;", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                           // id = Convert.ToInt32(reader["user_id"]),
                            name = reader["name"].ToString(),
                            email = reader["email"].ToString(),
                           //password = reader["password"].ToString()
                        });
                    }
                }

                conn.Close();
            }
            return list;
        }


        public void createUser(string name, string email, string password)
        {


            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    MySqlCommand command = new MySqlCommand("insert into user(name, email, password) values(@val1, @val2, sha1(@val3));", con);
                    command.Parameters.AddWithValue("@val1", name);
                    command.Parameters.AddWithValue("@val2", email);
                    command.Parameters.AddWithValue("@val3", password);
                    command.Prepare();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }



        public User Login(string email, string password) {

            
            using (MySqlConnection con = GetConnection())
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE email=@email AND password =sha1(@password) limit 1;", con);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        return new User { id = int.Parse(rdr["user_id"].ToString()), name = rdr["name"] .ToString(), email = rdr["email"].ToString(), password= rdr["password"].ToString() };
                    }

                }
                catch 
                {
                    
                }
                
                finally
                {
                    con.Close();
                }
            }

           
            return null;
        }


        public List<Player> GetAllPlayers()
        {
            List<Player> playerList = new List<Player>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from playerdata", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        playerList.Add(new Player()
                        {
                          /*  Player_id = Convert.ToInt32(reader["Player_id"]),
                            Team_id = Convert.ToInt32(reader["Team_id"]),
                            Player_Name = reader["Player_Name"].ToString(),*/
                            PTS = Convert.ToInt32(reader["PTS"]),
                            REB = Convert.ToInt32(reader["REB"]),
                            AST = Convert.ToInt32(reader["AST"]),
                            BLK = Convert.ToInt32(reader["BLK"]),
                            GP = Convert.ToInt32(reader["GP"]),
                            three_PM = Convert.ToInt32(reader["three_PM"]),
                            three_PA = Convert.ToInt32(reader["three_PA"]),
                            FTM = Convert.ToInt32(reader["FTM"]),
                            FTA = Convert.ToInt32(reader["FTA"]),
                            STL = Convert.ToInt32(reader["STL"]),
                        });
                    }
                }
            }
            return playerList;

        }

    }
}
