using System;
using System.Threading;
using MySql.Data.MySqlClient;
using NetworkGameServer.Enum;
using NetworkGameServer.Interface;

namespace NetworkGameServer.Services
{
    public class Database
    {
        private readonly string _addr = "localhost";

        private readonly string _db = "testdb";

        private readonly string _userId = "root";
        private readonly string _passwd = "root";

        private string _connStr;
        
        public Database(string addr, string db, string userId, string passwd)
        {
            _addr = addr;
            _db = db;
            _userId = userId;
            _passwd = passwd;
            
            _connStr = $"Server={_addr};Database={_db};Uid={_userId};Pwd={_passwd}";
        }

        public void Insert(ISchema schema)
        {
            var thread = new Thread(Insert);
            thread.IsBackground = true;
            thread.Start(schema);
        }

        private void Insert(object obj)
        {
            var schema = obj as ISchema;
            
            try
            {
                using (var conn = new MySqlConnection(_connStr))
                {
                    conn.Open();

                    var cmd = new MySqlCommand(schema.ConvertQuery(QueryType.Insert), conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}