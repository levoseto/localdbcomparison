using Datos.Drivers;
using Datos.Helpers;
using Estructuras;
using Estructuras.Interfaces;
using System.Text.Json;

namespace Datos
{
    public class DBConnection
    {
        private readonly IDriverDatabase DriverDB;

        public DBConnection()
        {
            DriverDB = new LiteDBDriverDatabase(@"C:\Git\LiteDB\Examples\Autos.db");
        }

        public List<Automovil> Get()
        {
            return DriverDB.GetAll<Automovil>();
        }

        public bool InsertAutomovil(Automovil automovil)
        {
            try
            {
                DriverDB.Insert(automovil);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool LlenaMasivoAutos()
        {
            int contador = 0;

            try
            {
                var coleccionAutos = JsonMapperHelper.LeeElementoDesdeArchivo<List<Automovil>>("Autos.json");
                if (coleccionAutos?.Count > 0)
                {
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

                    if (contador > 0)
                        return true;

                    return false;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}