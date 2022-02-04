using Estructuras;
using Negocio;

var autos = new AutomovilNegocio();
byte opcion;
do
{
    Console.WriteLine($"Por favor seleccione una opción:\n" +
        $"1. Insertar elemento\n" +
        $"2. Actualizar elemento\n" +
        $"3. Eliminar elemento\n" +
        $"4. Listar todos los elementos\n" +
        $"5. Insertar masivo foreach\n" +
        $"6. Insertar masivo bulk\n" +
        $"0. Salir");

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
            long.TryParse(año, out long anioEntero);
            Console.WriteLine("Ingresa el nó de serie del auto: ");
            var serie = Console.ReadLine();

            var insertaAuto = new Automovil
            {
                Marca = marca,
                Modelo = modelo,
                Año = anioEntero,
                Serie = serie
            };

            Console.WriteLine(autos.InsertaAuto(insertaAuto)
                ? "Auto insertado correctamente"
                : "Auto no pudo ser insertado");
            break;

        case 4:
            var todos = autos.Get();
            var contador = 0;
            foreach (var item in todos)
            {
                contador++;
                Console.WriteLine($"-----Bloque-----{contador}");
                Console.WriteLine($"Object Id: {item.ID}");
                Console.WriteLine($"Marca: {item.Marca}");
                Console.WriteLine($"Modelo: {item.Modelo}");
                Console.WriteLine($"Año: {item.Año}");
                Console.WriteLine($"VIN: {item.Serie}");
                Console.WriteLine($"-----Bloque-----{contador}");
            }

            break;

        case 5:
            var state = autos.LlenaMasivoAutos();
            Console.WriteLine(state ? "Llenó los datos con foreach" : "No se pudo llenar la información a la BD");
            break;

        case 6:
            var state2 = autos.LlenaMasivoAutos2();
            Console.WriteLine(state2 ? "Llenó los datos masivos con Bulk" : "No se pudo llenar la información a la BD");
            break;
    }
} while (opcion != 0);