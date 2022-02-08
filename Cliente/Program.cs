using Estructuras;
using Negocio;

var autos = new AutomovilNegocioLiteDB();
byte opcion;

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

    try
    {
        var opt = Console.ReadLine()!;
        opcion = byte.Parse(opt);

        switch (opcion)
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

                Console.WriteLine(autos.InsertaAuto(insertaAuto)
                    ? "Auto insertado correctamente\n"
                    : "Auto no pudo ser insertado\n");
                break;

            case 2:
                break;

            case 3:
                Console.WriteLine("Ingresa el ID del objeto a eliminar: ");
                var guid = Console.ReadLine()!;
                Console.WriteLine($"Este es el id a eliminar: {guid}");
                if (autos.EliminarAutomovil(guid))
                {
                    Console.WriteLine($"Se ha eliminado el objeto con ID: {guid}");
                }
                else
                    Console.WriteLine($"No se pudo eliminar el objeto debido a que este no existe.");

                break;

            case 4:
                var todos = autos.Get();
                if (todos?.Count > 0)
                {
                    var contador = 0;
                    foreach (var item in todos)
                    {
                        contador++;
                        Console.WriteLine($"<----- Bloque {contador} ----->");
                        Console.WriteLine($"Object Id: {item.ID}");
                        Console.WriteLine($"Id Auto: {item.IdAuto}");
                        Console.WriteLine($"Marca: {item.Marca}");
                        Console.WriteLine($"Modelo: {item.Modelo}");
                        Console.WriteLine($"Año: {item.Año}");
                        Console.WriteLine($"VIN: {item.Serie}");
                        Console.WriteLine($"</----- Bloque {contador} ----->");
                    }
                }
                else
                {
                    Console.WriteLine("No hay datos a mostrar\n");
                }

                break;

            case 5:
                Console.WriteLine("Id para buscar el auto:");
                var stringId = int.Parse(Console.ReadLine()!);
                var itemAuto = autos.ObtienePorIdEnColeccion(stringId);
                Console.WriteLine($"<----- Bloque {stringId} ----->");
                Console.WriteLine($"Object Id: {itemAuto.ID}");
                Console.WriteLine($"Id Auto: {itemAuto.IdAuto}");
                Console.WriteLine($"Marca: {itemAuto.Marca}");
                Console.WriteLine($"Modelo: {itemAuto.Modelo}");
                Console.WriteLine($"Año: {itemAuto.Año}");
                Console.WriteLine($"VIN: {itemAuto.Serie}");
                Console.WriteLine($"</----- Bloque {stringId} ----->");
                break;

            case 6:
                Console.WriteLine("Id para buscar el auto:");
                var stringId2 = int.Parse(Console.ReadLine()!);
                var itemAuto2 = autos.ObtienePorIdEnQuery(stringId2);
                Console.WriteLine($"<----- Bloque {stringId2} ----->");
                Console.WriteLine($"Object Id: {itemAuto2.ID}");
                Console.WriteLine($"Id Auto: {itemAuto2.IdAuto}");
                Console.WriteLine($"Marca: {itemAuto2.Marca}");
                Console.WriteLine($"Modelo: {itemAuto2.Modelo}");
                Console.WriteLine($"Año: {itemAuto2.Año}");
                Console.WriteLine($"VIN: {itemAuto2.Serie}");
                Console.WriteLine($"</----- Bloque {stringId2} ----->");
                break;

            case 7:
                var state = autos.LlenaMasivoAutos();
                Console.WriteLine(state ? "Llenó los datos con foreach" : "No se pudo llenar la información a la BD");
                break;

            case 8:
                var state2 = autos.InsertaAutosMasivo();
                Console.WriteLine(state2 ? "Llenó los datos masivos con Bulk" : "No se pudo llenar la información a la BD");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        opcion = 100;
    }
} while (opcion != 0);