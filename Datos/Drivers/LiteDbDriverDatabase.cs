namespace Datos.Drivers
{
    using Estructuras.Interfaces;
    using LiteDB;
    using System.Diagnostics;

    public class LiteDbDriverDatabase : IDriverDatabase, IBsonDefinition
    {
        private readonly string _collectionName;
        private readonly string _connectionString;

        public LiteDbDriverDatabase(string connectionString, string collectionName)
        {
            _connectionString = connectionString;
            _collectionName = collectionName;
        }

        public void Delete<T>(string objectId)
        {
            try
            {
                var guid = new ObjectId(objectId);
                Debug.WriteLine($"Que es: {guid}");
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName);
                var resultado = col?.Delete(guid);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public void DeleteBy<T>(BsonExpression expression)
        {
            var search = GetBy<T>(expression);

            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T> GetAll<T>()
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName)!;
                return col.Query().ToList();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public T GetBy<T>(BsonExpression expression)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName)!;
                return col.FindOne(expression)!;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public List<T> GetCollectionBy<T>(BsonExpression expression)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName)!;
                return col.Find(expression)!.ToList();
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public object GetConnection()
        {
            return new LiteDatabase(_connectionString);
        }

        public void InsertAll(List<BsonDocument> elements)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection(_collectionName);
                col?.InsertBulk(elements);
            }
            catch (Exception e)
            {
                throw e.GetBaseException();
            }
        }

        public void Insert<T>(T element)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName);
                _ = col?.Insert(element);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public void Update<T>(T element)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName);
                col?.Update(element);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}