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

        public bool InsertaAutosMasivo()
        {
            return _connection.InsertaAutomoviles();
        }

        public List<Automovil> Get()
        {
            return _connection.ObtieneTodos();
        }

        public Automovil ObtienePorIdEnColeccion(int id)
        {
            return _connection.GetById(id);
        }

        public Automovil ObtienePorIdEnQuery(int idAuto)
        {
            return _connection.GetByIdQuery(idAuto);
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