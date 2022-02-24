using Estructuras.Interfaces;

namespace Datos.Drivers
{
    public class RealmDriverDatabase : IDriverDatabase
    {
        public RealmDriverDatabase()
        {
        }

        public void Delete<T>(string element)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            try
            {
                using (var db = GetConnection() as Realms.Realm)
                {
                    return new List<T>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetConnection()
        {
            return Realms.Realm.GetInstance();
        }

        public void Insert<T>(T element)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T element)
        {
            throw new NotImplementedException();
        }
    }
}