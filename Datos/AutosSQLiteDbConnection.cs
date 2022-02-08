using Datos.Drivers;
using Datos.Helpers;
using Estructuras;

namespace Datos
{
    public class AutosSQLiteDbConnection
    {
        private readonly SQLiteDriverDatabase _driverDb;

        public AutosSQLiteDbConnection()
        {
            _driverDb = new SQLiteDriverDatabase(@"C:\Git\LiteDB\Examples\AutosSQLite.db", nameof(Automovil));
        }

        public List<Automovil> ObtieneTodos()
        {
            return _driverDb.GetAll<Automovil>();
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
                //return _driverDb.GetBy<Automovil>(expresionABuscar);
                return new Automovil();
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
                        //ID = ObjectId.NewObjectId(),
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
                //automovil.IdAuto = MaxIdAInsertar();
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

        private int MaxIdAInsertar()
        {
            var max = ObtieneTodos()?.Count > 0 ? ObtieneTodos().Max(auto => auto.IdAuto) : 0;
            return max + 1;
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