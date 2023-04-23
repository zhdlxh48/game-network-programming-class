using NetworkGameServer.Enum;
using NetworkGameServer.Interface;

namespace NetworkGameServer.Schema
{
    public class UserSchema : ISchema
    {
        private string _nick;
        
        private string _email;
        private string _passwd;
        
        public UserSchema(string nick, string email, string passwd)
        {
            _nick = nick;
            _email = email;
            _passwd = passwd;
        }
        
        public string ConvertQuery(QueryType type)
        {
            switch (type)
            {
                case QueryType.Insert:
                    return $"INSERT INTO user VALUES ('{_email}', '{_passwd}', '{_nick}');";
                case QueryType.Update:
                case QueryType.Delete:
                case QueryType.Select:
                default:
                    return string.Empty;
            }
        }
    }
}