using NetworkGameServer.Enum;

namespace NetworkGameServer.Interface
{
    public interface ISchema
    {
        string ConvertQuery(QueryType type);
    }
}