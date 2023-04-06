using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Practice
{
    public class TestDB
    {
        public static void Run()
        {
            var connStr = "Server=localhost;Database=testdb;Uid=root;Pwd=root";
            var conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                var sqlStr = "INSERT INTO test VALUES (10, 'IronMan');";
                //var sqlStr = "DELETE FROM test WHERE Name = 'WonderWoman'";
                var cmd = new MySqlCommand(sqlStr, conn);
                cmd.ExecuteNonQuery();

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
