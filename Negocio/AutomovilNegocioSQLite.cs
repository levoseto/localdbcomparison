﻿using Datos;
using Estructuras;

namespace Negocio
{
    public class AutomovilNegocioSQLite
    {
        private readonly AutosSQLiteDbConnection _connection;

        public AutomovilNegocioSQLite()
        {
            _connection = new AutosSQLiteDbConnection();
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
            return _connection.InsertAutomovil(automovil);
        }

        public bool EliminarAutomovil(string objectId)
        {
            return _connection.EliminarAutomovil(objectId);
        }
    }
}