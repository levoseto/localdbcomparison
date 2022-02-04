using Datos.Drivers;
using Datos.Helpers;
using Estructuras;
using Estructuras.Interfaces;
using LiteDB;

namespace Datos
{
    public class AutosDbConnection
    {
        private readonly IDriverDatabase _driverDb;

        public AutosDbConnection()
        {
            _driverDb = new LiteDbDriverDatabase(@"C:\Git\LiteDB\Examples\Autos.db", nameof(Automovil));
        }

        public List<Automovil> Get()
        {
            return _driverDb.GetAll<Automovil>();
        }

        public bool InsertAllAutomovil()
        {
            try
            {
                var coleccionAutos = JsonMapperHelper.LeeElementoDesdeArchivo<List<Automovil>>("Autos.json");
                if (!(coleccionAutos?.Count > 0)) return false;

                List<BsonDocument> autosAInsertar = new List<BsonDocument>();

                coleccionAutos.ForEach(automovil =>
                {
                    BsonDocument autoDoc = new BsonDocument();
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

        public bool InsertAutomovil(Automovil automovil)
        {
            try
            {
                automovil.IdAuto = MaxIdAInsertar();
                _driverDb.Insert(automovil);
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

        private long MaxIdAInsertar()
        {
            var max = Get()?.Count > 0 ? Get().Max(auto => auto.IdAuto) : 0;
            return max + 1;
        }
    }
}