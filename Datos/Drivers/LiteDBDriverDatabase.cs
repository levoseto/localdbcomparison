using Estructuras.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Drivers
{
    public class LiteDBDriverDatabase : IDriverDatabase
    {
        public string Collection { get; set; }
        public string ConnectionString { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public LiteDBDriverDatabase(string connectionString) => ConnectionString = connectionString;

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void Delete<T>(T element)
        {
            try
            {
                var guid = element?.GetType().GUID;
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(Collection);
                col?.Delete(guid);
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
                var col = db?.GetCollection<T>(Collection);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                return col.Query().ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object GetConnection()
        {
            return new LiteDatabase(ConnectionString);
        }

        public void Insert<T>(T element)
        {
            try
            {
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(Collection);
                _ = col?.Insert(element);
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
                using var db = GetConnection() as LiteDatabase;
                var col = db?.GetCollection<T>(Collection);
                col?.Update(element);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}