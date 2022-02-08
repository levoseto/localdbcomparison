using LiteDB;

namespace Estructuras.Interfaces
{
    public interface IBsonDefinition
    {
        void InsertAll(List<BsonDocument> elements);

        T GetBy<T>(BsonExpression expression);

        List<T> GetCollectionBy<T>(BsonExpression expression);
    }
}