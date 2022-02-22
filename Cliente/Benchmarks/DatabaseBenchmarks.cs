using BenchmarkDotNet.Attributes;
using Negocio;

namespace Cliente.Benchmarks
{
    [MemoryDiagnoser]
    public class DatabaseBenchmarks
    {
        private AutomovilNegocioLiteDB autosLite = new AutomovilNegocioLiteDB();
        private AutomovilNegocioSQLite autosSqlite = new AutomovilNegocioSQLite();

        // Insert Bulk
        [Benchmark]
        public void MideInsertBulkLiteDB()
        {
            autosLite.InsertaAutosMasivo();
        }

        [Benchmark]
        public void MideInsertBulkSQLite()
        {
            autosSqlite.InsertaAutosMasivo();
        }
    }
}