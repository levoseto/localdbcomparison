using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras.Interfaces
{
    public interface IBsonDefinition
    {
        void InsertAll(List<BsonDocument> elements);

        T GetBy<T>(BsonExpression expression);

        List<T> GetCollectionBy<T>(BsonExpression expression);
    }
}