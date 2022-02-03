using Datos;
using Estructuras;

namespace Negocio
{
    public class AutomovilNegocio
    {
        private readonly DBConnection Connection;

        public AutomovilNegocio()
        {
            Connection = new DBConnection();
        }

        public bool LlenaMasivoAutos()
        {
            return Connection.LlenaMasivoAutos();
        }

        public List<Automovil> Get()
        {
            return Connection.Get();
        }

        public void InsertaAuto(Automovil automovil)
        {
            Connection.InsertAutomovil(automovil);
        }
    }
}