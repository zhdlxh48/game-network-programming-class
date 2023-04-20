using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Week5_201813086_UPDATE
    {
        public static void Run(string oldEmail, string newEmail)
        {
            var connStr = "Server=localhost;Database=gamedb;Uid=root;Pwd=RealTjshd*499";
            var conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                var sqlStr = "UPDATE Players SET email = '" + newEmail + "' where email = '" + oldEmail + "';";
                var cmd = new MySqlCommand(sqlStr, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("email: " + reader["email"] + " / nickname: " + reader["nickname"] + " / passwd: " + reader["passwd"]);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
