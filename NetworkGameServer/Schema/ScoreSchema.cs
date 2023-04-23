using System;
using NetworkGameServer.Enum;
using NetworkGameServer.Interface;

namespace NetworkGameServer.Schema
{
    public class ScoreSchema : ISchema
    {
        private string _email;

        private float _time;
        private float _score;
        
        public string ConvertQuery(QueryType type)
        {
            switch (type)
            {
                case QueryType.Insert:
                    return $"INSERT INTO score VALUES ('{_email}', {_time}, {_score});";
                case QueryType.Update:
                case QueryType.Delete:
                case QueryType.Select:
                default:
                    return String.Empty;
            }
        }
    }
}