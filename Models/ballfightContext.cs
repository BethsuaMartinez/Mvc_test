using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ballfight.Models
{
    public class ballfightContext
    {

        //private MySqlConnection con = new MySqlConnection(@"server=localhost;userid=root;password=root;database=school");


        public string ConnectionString { get; set; }

            public ballfightContext(string connectionString)
            {
                this.ConnectionString = connectionString;
            }

            private MySqlConnection GetConnection()
            {

                return new MySqlConnection(ConnectionString);
            }



        public List<userModel> GetAllUsers()
        {
            List<userModel> list = new List<userModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user;", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new userModel()
                        {
                           // id = Convert.ToInt32(reader["user_id"]),
                            name = reader["name"].ToString(),
                            email = reader["email"].ToString(),
                            password = reader["password"].ToString()
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
                    MySqlCommand command = new MySqlCommand("insert into user(name, email, password) values(@val1, @val2, @val3);", con);
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


    }
}
