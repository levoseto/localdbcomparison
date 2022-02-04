using Datos;
using Estructuras;

namespace Negocio
{
    public class AutomovilNegocio
    {
        private readonly AutosDbConnection _connection;

        public AutomovilNegocio()
        {
            _connection = new AutosDbConnection();
        }

        public bool LlenaMasivoAutos()
        {
            return _connection.LlenaMasivoAutos();
        }

        public bool LlenaMasivoAutos2()
        {
            return _connection.InsertAllAutomovil();
        }

        public List<Automovil> Get()
        {
            return _connection.Get();
        }

        public bool InsertaAuto(Automovil automovil)
        {
            try
            {
                return _connection.InsertAutomovil(automovil);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}