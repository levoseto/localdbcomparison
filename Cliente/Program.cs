using Estructuras;
using Negocio;
using System.Diagnostics;

var autosLite = new AutomovilNegocioLiteDB();
var autosSqlite = new AutomovilNegocioSQLite();
byte opcionDriver, opcionMenu;

do
{
    Console.WriteLine($"Por favor seleccione una opción:\n" +
        $"1. LiteDB \n" +
        $"2. SQLite \n" +
        $"0. Salir");

    opcionDriver = byte.Parse(Console.ReadLine()!);

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

    var timer = Stopwatch.StartNew();

    try
    {
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

                if (opcionDriver == 1)
                {
                    Console.WriteLine(autosLite.InsertaAuto(insertaAuto)
                        ? "Auto insertado correctamente\n LiteDB"
                        : "Auto no pudo ser insertado\n en LiteDB");
                }
                else
                {
                    Console.WriteLine(autosSqlite.InsertaAuto(insertaAuto)
                        ? "Auto insertado correctamente\n en SQLite"
                        : "Auto no pudo ser insertado\n en SQLite");
                }

                break;

            case 2:
                break;

            case 3:
                Console.WriteLine("Ingresa el ID del objeto a eliminar: ");
                var guid = Console.ReadLine()!;
                Console.WriteLine($"Este es el id a eliminar: {guid}");
                if (opcionDriver == 1)
                {
                    if (autosLite.EliminarAutomovil(guid))
                    {
                        Console.WriteLine($"Se ha eliminado el objeto con ID: {guid} en LiteDB");
                    }
                    else
                        Console.WriteLine($"No se pudo eliminar el objeto debido a que este no existe. LiteDB");
                }
                else
                {
                    if (autosSqlite.EliminarAutomovil(guid))
                    {
                        Console.WriteLine($"Se ha eliminado el objeto con ID: {guid} en SQLite");
                    }
                    else
                        Console.WriteLine($"No se pudo eliminar el objeto debido a que este no existe. SQLite");
                }

                break;

            case 4:
                if (opcionDriver == 1)
                {
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
                        Console.WriteLine("No hay datos a mostrar\n");
                    }
                }
                else
                {
                    var todos = autosSqlite.Get();
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
                        Console.WriteLine("No hay datos a mostrar\n");
                    }
                }

                break;

            case 5:
                Console.WriteLine("Id para buscar el auto:");
                var stringId = int.Parse(Console.ReadLine()!);
                if (opcionDriver == 1)
                {
                    var itemAuto = autosLite.ObtienePorIdEnColeccion(stringId);
                    Console.WriteLine($"<----- Bloque LiteDB {stringId} ----->");
                    Console.WriteLine($"Object Id: {itemAuto.ID}");
                    Console.WriteLine($"Id Auto: {itemAuto.IdAuto}");
                    Console.WriteLine($"Marca: {itemAuto.Marca}");
                    Console.WriteLine($"Modelo: {itemAuto.Modelo}");
                    Console.WriteLine($"Año: {itemAuto.Año}");
                    Console.WriteLine($"VIN: {itemAuto.Serie}");
                    Console.WriteLine($"</----- Bloque LiteDB {stringId} ----->");
                }
                else
                {
                    var itemAuto = autosSqlite.ObtienePorIdEnColeccion(stringId);
                    Console.WriteLine($"<----- Bloque SQLite {stringId} ----->");
                    Console.WriteLine($"Object Id: {itemAuto.ID}");
                    Console.WriteLine($"Id Auto: {itemAuto.IdAuto}");
                    Console.WriteLine($"Marca: {itemAuto.Marca}");
                    Console.WriteLine($"Modelo: {itemAuto.Modelo}");
                    Console.WriteLine($"Año: {itemAuto.Año}");
                    Console.WriteLine($"VIN: {itemAuto.Serie}");
                    Console.WriteLine($"</----- Bloque SQLite {stringId} ----->");
                }
                break;

            case 6:
                Console.WriteLine("Id para buscar el auto:");
                var stringId2 = int.Parse(Console.ReadLine()!);
                if (opcionDriver == 2)
                {
                    var itemAuto2 = autosLite.ObtienePorIdEnQuery(stringId2);
                    Console.WriteLine($"<----- Bloque LiteDB {stringId2} ----->");
                    Console.WriteLine($"Object Id: {itemAuto2.ID}");
                    Console.WriteLine($"Id Auto: {itemAuto2.IdAuto}");
                    Console.WriteLine($"Marca: {itemAuto2.Marca}");
                    Console.WriteLine($"Modelo: {itemAuto2.Modelo}");
                    Console.WriteLine($"Año: {itemAuto2.Año}");
                    Console.WriteLine($"VIN: {itemAuto2.Serie}");
                    Console.WriteLine($"</----- Bloque LiteDB {stringId2} ----->");
                }
                else
                {
                    var itemAuto2 = autosSqlite.ObtienePorIdEnQuery(stringId2);
                    Console.WriteLine($"<----- Bloque SQLite {stringId2} ----->");
                    Console.WriteLine($"Object Id: {itemAuto2.ID}");
                    Console.WriteLine($"Id Auto: {itemAuto2.IdAuto}");
                    Console.WriteLine($"Marca: {itemAuto2.Marca}");
                    Console.WriteLine($"Modelo: {itemAuto2.Modelo}");
                    Console.WriteLine($"Año: {itemAuto2.Año}");
                    Console.WriteLine($"VIN: {itemAuto2.Serie}");
                    Console.WriteLine($"</----- Bloque SQLite {stringId2} ----->");
                }
                break;

            case 7:
                if (opcionDriver == 1)
                {
                    var state = autosLite.LlenaMasivoAutos();
                    Console.WriteLine(state ? "Llenó los datos con foreach en LiteDB" : "No se pudo llenar la información a la BD LiteDB");
                }
                else
                {
                    var state = autosLite.LlenaMasivoAutos();
                    Console.WriteLine(state ? "Llenó los datos con foreach en SQLite" : "No se pudo llenar la información a la BD en SQLite");
                }
                break;

            case 8:
                if (opcionDriver == 1)
                {
                    var state2 = autosLite.InsertaAutosMasivo();
                    Console.WriteLine(state2 ? "Llenó los datos masivos con Bulk LiteDB" : "No se pudo llenar la información a la BD LiteDB");
                    break;
                }
                else
                {
                    var state2 = autosSqlite.InsertaAutosMasivo();
                    Console.WriteLine(state2 ? "Llenó los datos masivos con Bulk SQLite" : "No se pudo llenar la información a la BD SQLite");
                    break;
                }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        opcionDriver = 100;
    }

    timer.Stop();
    Console.WriteLine($"Tiempo transcurrido: {timer.Elapsed}");

    //do
    //{
    //} while (opcionMenu != 0);
} while (opcionDriver != 0);