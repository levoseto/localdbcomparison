using Estructuras;
using Estructuras.Interfaces;
using SQLite;

namespace Datos.Drivers
{
    public class SQLiteDriverDatabase : IDriverDatabase, ISQLiteDefinition
    {
        private readonly string _connectionString;

        public SQLiteDriverDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> GetAll<T>()
        {
            try
            {
                using (var db = GetConnection() as SQLiteConnection)
                {
                    //db?.Table<T>().ToList();
                }
                return new List<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetConnection()
        {
            var databasePath = _connectionString;
            return new SQLiteConnection(databasePath);
        }

        public void Insert<T>(T element)
        {
            try
            {
                using (var db = GetConnection() as SQLiteConnection)
                {
                    db?.CreateTable<T>();
                    db?.Insert(element);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update<T>(T element)
        {
            try
            {
                using (var db = GetConnection() as SQLiteConnection)
                {
                    db?.Update(element);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete<T>(string element)
        {
            try
            {
                using (var db = GetConnection() as SQLiteConnection)
                {
                    db?.Delete(element);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertAll<T>(List<T> elements)
        {
            try
            {
                using (var db = GetConnection() as SQLiteConnection)
                {
                    db?.CreateTable<Automovil>();
                    db?.InsertAll(elements);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}