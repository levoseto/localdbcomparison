using LiteDB;

namespace Estructuras.Interfaces
{
    public interface IDriverDatabase
    {
        object GetConnection();

        List<T> GetAll<T>();

        void Insert<T>(T element);

        void Update<T>(T element);

        void Delete<T>(T element);
    }
}