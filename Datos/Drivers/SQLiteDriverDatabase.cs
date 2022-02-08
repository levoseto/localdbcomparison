using Estructuras.Interfaces;
using LiteDB;

namespace Datos.Drivers
{
    public class SQLiteDriverDatabase : IDriverDatabase
    {
        public void Delete<T>(T element)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public object GetConnection()
        {
            throw new NotImplementedException();
        }

        public void Insert<T>(T element)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T element)
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(string element)
        {
        }
    }
}