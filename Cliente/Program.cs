using Estructuras;
using Negocio;
using System.Diagnostics;

var autosLite = new AutomovilNegocioLiteDB();
var autosSqlite = new AutomovilNegocioSQLite();
byte opcionMenu;

do
{
    Console.WriteLine($"Por favor seleccione una opción:\n" +
        $"1. Insertar elemento\n" +
        $"2. Actualizar elemento\n" +
        $"3. Eliminar elemento\n" +
        $"4. Listar todos los elementos\n" +
        $"5. Buscar por ID en colección ya obtenida\n" +
        $"6. Buscar por ID con definición de Query\n" +
        $"7. Insertar masivo foreach\n" +
        $"8. Insertar masivo bulk\n" +
        $"0. Salir");

    var opt = Console.ReadLine()!;
    opcionMenu = byte.Parse(opt);

    Stopwatch timerLiteDB, timerSQLite, timerGlobal;

    try
    {
        timerGlobal = Stopwatch.StartNew();

        switch (opcionMenu)
        {
            case 1:
                Console.WriteLine("Ingresa la marca: ");
                var marca = Console.ReadLine();
                Console.WriteLine("Ingresa el modelo:");
                var modelo = Console.ReadLine();
                Console.WriteLine("Ingrese el año del auto: ");
                var año = Console.ReadLine()!;
                int.TryParse(año, out int anioEntero);
                Console.WriteLine("Ingresa el No. de serie del auto: ");
                var serie = Console.ReadLine();

                var insertaAuto = new Automovil
                {
                    Marca = marca,
                    Modelo = modelo,
                    Año = anioEntero,
                    Serie = serie
                };

                timerLiteDB = Stopwatch.StartNew();

                Console.WriteLine(autosLite.InsertaAuto(insertaAuto)
                    ? "Auto insertado correctamente\n LiteDB"
                    : "Auto no pudo ser insertado\n en LiteDB");

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                Console.WriteLine(autosSqlite.InsertaAuto(insertaAuto)
                    ? "Auto insertado correctamente\n en SQLite"
                    : "Auto no pudo ser insertado\n en SQLite");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                break;

            case 2:
                break;

            case 3:
                Console.WriteLine("Ingresa el ID del objeto a eliminar: ");
                var guid = Console.ReadLine()!;
                Console.WriteLine($"Este es el id a eliminar: {guid}");

                timerLiteDB = Stopwatch.StartNew();

                if (autosLite.EliminarAutomovil(guid))
                {
                    Console.WriteLine($"Se ha eliminado el objeto con ID: {guid} en LiteDB");
                }
                else
                {
                    Console.WriteLine($"No se pudo eliminar el objeto debido a que este no existe. LiteDB");
                }

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                if (autosSqlite.EliminarAutomovil(guid))
                {
                    Console.WriteLine($"Se ha eliminado el objeto con ID: {guid} en SQLite");
                }
                else
                    Console.WriteLine($"No se pudo eliminar el objeto debido a que este no existe. SQLite");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                break;

            case 4:
                timerLiteDB = Stopwatch.StartNew();

                var todos = autosLite.Get();
                if (todos?.Count > 0)
                {
                    var contador = 0;
                    foreach (var item in todos)
                    {
                        contador++;
                        Console.WriteLine($"<----- Bloque SQLite {contador} ----->");
                        Console.WriteLine($"Object Id: {item.ID}");
                        Console.WriteLine($"Id Auto: {item.IdAuto}");
                        Console.WriteLine($"Marca: {item.Marca}");
                        Console.WriteLine($"Modelo: {item.Modelo}");
                        Console.WriteLine($"Año: {item.Año}");
                        Console.WriteLine($"VIN: {item.Serie}");
                        Console.WriteLine($"</----- Bloque SQLite {contador} ----->");
                    }
                }
                else
                {
                    Console.WriteLine("No hay datos a mostrar\n en LiteDB");
                }

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                var todosSQLite = autosSqlite.Get();
                if (todosSQLite?.Count > 0)
                {
                    var contador = 0;
                    foreach (var item in todosSQLite)
                    {
                        contador++;
                        Console.WriteLine($"<----- Bloque SQLite {contador} ----->");
                        Console.WriteLine($"Object Id: {item.ID}");
                        Console.WriteLine($"Id Auto: {item.IdAuto}");
                        Console.WriteLine($"Marca: {item.Marca}");
                        Console.WriteLine($"Modelo: {item.Modelo}");
                        Console.WriteLine($"Año: {item.Año}");
                        Console.WriteLine($"VIN: {item.Serie}");
                        Console.WriteLine($"</----- Bloque SQLite {contador} ----->");
                    }
                }
                else
                {
                    Console.WriteLine("No hay datos a mostrar\n");
                }

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                break;

            case 5:
                timerLiteDB = Stopwatch.StartNew();

                Console.WriteLine("Id para buscar el auto:");
                var stringId = int.Parse(Console.ReadLine()!);
                var itemAutoLiteDB = autosLite.ObtienePorIdEnColeccion(stringId);
                Console.WriteLine($"<----- Bloque LiteDB {stringId} ----->");
                Console.WriteLine($"Object Id: {itemAutoLiteDB.ID}");
                Console.WriteLine($"Id Auto: {itemAutoLiteDB.IdAuto}");
                Console.WriteLine($"Marca: {itemAutoLiteDB.Marca}");
                Console.WriteLine($"Modelo: {itemAutoLiteDB.Modelo}");
                Console.WriteLine($"Año: {itemAutoLiteDB.Año}");
                Console.WriteLine($"VIN: {itemAutoLiteDB.Serie}");
                Console.WriteLine($"</----- Bloque LiteDB {stringId} ----->");

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                var itemAutoSQLite = autosSqlite.ObtienePorIdEnColeccion(stringId);
                Console.WriteLine($"<----- Bloque SQLite {stringId} ----->");
                Console.WriteLine($"Object Id: {itemAutoSQLite.ID}");
                Console.WriteLine($"Id Auto: {itemAutoSQLite.IdAuto}");
                Console.WriteLine($"Marca: {itemAutoSQLite.Marca}");
                Console.WriteLine($"Modelo: {itemAutoSQLite.Modelo}");
                Console.WriteLine($"Año: {itemAutoSQLite.Año}");
                Console.WriteLine($"VIN: {itemAutoSQLite.Serie}");
                Console.WriteLine($"</----- Bloque SQLite {stringId} ----->");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");
                break;

            case 6:
                timerLiteDB = Stopwatch.StartNew();
                Console.WriteLine("Id para buscar el auto:");
                var stringId2 = int.Parse(Console.ReadLine()!);

                var itemAutoLiteDB2 = autosLite.ObtienePorIdEnQuery(stringId2);
                Console.WriteLine($"<----- Bloque LiteDB {stringId2} ----->");
                Console.WriteLine($"Object Id: {itemAutoLiteDB2.ID}");
                Console.WriteLine($"Id Auto: {itemAutoLiteDB2.IdAuto}");
                Console.WriteLine($"Marca: {itemAutoLiteDB2.Marca}");
                Console.WriteLine($"Modelo: {itemAutoLiteDB2.Modelo}");
                Console.WriteLine($"Año: {itemAutoLiteDB2.Año}");
                Console.WriteLine($"VIN: {itemAutoLiteDB2.Serie}");
                Console.WriteLine($"</----- Bloque LiteDB {stringId2} ----->");

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                var itemAutoSQLite2 = autosSqlite.ObtienePorIdEnQuery(stringId2);
                Console.WriteLine($"<----- Bloque SQLite {stringId2} ----->");
                Console.WriteLine($"Object Id: {itemAutoSQLite2.ID}");
                Console.WriteLine($"Id Auto: {itemAutoSQLite2.IdAuto}");
                Console.WriteLine($"Marca: {itemAutoSQLite2.Marca}");
                Console.WriteLine($"Modelo: {itemAutoSQLite2.Modelo}");
                Console.WriteLine($"Año: {itemAutoSQLite2.Año}");
                Console.WriteLine($"VIN: {itemAutoSQLite2.Serie}");
                Console.WriteLine($"</----- Bloque SQLite {stringId2} ----->");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                break;

            case 7:
                timerLiteDB = Stopwatch.StartNew();
                var stateLiteDB = autosLite.LlenaMasivoAutos();
                Console.WriteLine(stateLiteDB ? "Llenó los datos con foreach en LiteDB" : "No se pudo llenar la información a la BD LiteDB");

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                var stateSQLite = autosLite.LlenaMasivoAutos();
                Console.WriteLine(stateSQLite ? "Llenó los datos con foreach en SQLite" : "No se pudo llenar la información a la BD en SQLite");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");
                break;

            case 8:
                timerLiteDB = Stopwatch.StartNew();
                var stateLiteDB2 = autosLite.InsertaAutosMasivo();
                Console.WriteLine(stateLiteDB2 ? "Llenó los datos masivos con Bulk LiteDB" : "No se pudo llenar la información a la BD LiteDB");

                timerLiteDB.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");

                timerSQLite = Stopwatch.StartNew();

                var stateSQLite2 = autosSqlite.InsertaAutosMasivo();
                Console.WriteLine(stateSQLite2 ? "Llenó los datos masivos con Bulk SQLite" : "No se pudo llenar la información a la BD SQLite");

                timerSQLite.Stop();
                Console.WriteLine($"Tiempo total de operación LiteDB: {timerLiteDB.Elapsed}");
                break;
        }

        Console.WriteLine($"Tiempo transcurrido: {timerGlobal.Elapsed}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        opcionMenu = 100;
    }
} while (opcionMenu != 0);