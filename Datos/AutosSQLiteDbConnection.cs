using Datos.Drivers;
using Datos.Helpers;
using Estructuras;
using SQLite;

namespace Datos
{
    public class AutosSQLiteDbConnection
    {
        private readonly SQLiteDriverDatabase _driverDb;

        public AutosSQLiteDbConnection()
        {
            _driverDb = new SQLiteDriverDatabase(@"E:\Git\LiteDB\Examples\AutosSQLite.db");
        }

        public List<Automovil> ObtieneTodos()
        {
            try
            {
                using (var db = _driverDb.GetConnection() as SQLiteConnection)
                {
                    return db?.Table<Automovil>().ToList()!;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Automovil GetById(int id)
        {
            try
            {
                var todos = ObtieneTodos();
                return todos.FirstOrDefault(item => item.IdAuto == id)!;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public Automovil GetByIdQuery(int idAuto)
        {
            try
            {
                using (var db = _driverDb.GetConnection() as SQLiteConnection)
                {
                    return db?.Table<Automovil>().FirstOrDefault(auto => auto.IdAuto == idAuto)!;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertaAutomoviles()
        {
            try
            {
                var coleccionAutos = JsonMapperHelper.LeeElementoDesdeArchivo<List<Automovil>>("Autos.json");
                if (!(coleccionAutos?.Count > 0)) return false;

                _driverDb.InsertAll(coleccionAutos);
                return true;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public bool LlenaMasivoAutos()
        {
            var contador = 0;

            try
            {
                var coleccionAutos = JsonMapperHelper.LeeElementoDesdeArchivo<List<Automovil>>("Autos.json");
                if (!(coleccionAutos?.Count > 0)) return false;
                foreach (var item in coleccionAutos)
                {
                    var automovil = new Automovil
                    {
                        Año = item.Año,
                        IdAuto = item.IdAuto,
                        Marca = item.Marca,
                        Modelo = item.Modelo,
                        Serie = item.Serie,
                    };

                    if (InsertAutomovil(automovil)) contador++;
                }

                return contador > 0;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public bool InsertAutomovil(Automovil automovil)
        {
            try
            {
                _driverDb.Insert(automovil);
                return true;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public bool ActualizaAutomovil(Automovil automovil)
        {
            try
            {
                _driverDb.Update(automovil);
                return true;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }

        public bool EliminarAutomovil(string objectId)
        {
            try
            {
                _driverDb.Delete<Automovil>(objectId);
                return true;
            }
            catch (Exception ex)
            {
                throw ex.GetBaseException();
            }
        }
    }
}