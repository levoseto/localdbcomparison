namespace Datos.Drivers
{
    using Estructuras.Interfaces;
    using LiteDB;

    public class LiteDbDriverDatabase : IDriverDatabase
    {
        private readonly string _collectionName;
        private readonly string _connectionString;

        public LiteDbDriverDatabase(string connectionString, string collectionName)
        {
            _connectionString = connectionString;
            _collectionName = collectionName;
        }

        public void Delete<T>(T element)
        {
            try
            {
                var guid = element?.GetType().GUID;
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(_collectionName);
                col?.Delete(guid);
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
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