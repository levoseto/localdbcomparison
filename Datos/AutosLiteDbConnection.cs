using Datos.Drivers;
using Datos.Helpers;
using Estructuras;
using LiteDB;

namespace Datos
{
    public class AutosLiteDbConnection
    {
        private readonly LiteDbDriverDatabase _driverDb;

        public AutosLiteDbConnection()
        {
            _driverDb = new LiteDbDriverDatabase(@"C:\Git\LiteDB\Examples\AutosLiteDB.db", nameof(Automovil));
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
                var expresionABuscar = Query.EQ("idAuto", idAuto);
                return _driverDb.GetBy<Automovil>(expresionABuscar);
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

                List<BsonDocument> autosAInsertar = new List<BsonDocument>();

                coleccionAutos.ForEach(automovil =>
                {
                    BsonDocument autoDoc = new BsonDocument();
                    autoDoc["IdAuto"] = automovil.IdAuto;
                    autoDoc["Marca"] = automovil.Marca;
                    autoDoc["Modelo"] = automovil.Modelo;
                    autoDoc["Año"] = automovil.Año;
                    autoDoc["Serie"] = automovil.Serie;
                    autosAInsertar.Add(autoDoc);
                });

                _driverDb.InsertAll(autosAInsertar);
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