using Negocio;

namespace Cliente
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var autos = new AutomovilNegocio();
            byte opcion = 0;

            do
            {
                Console.WriteLine($"Por favor seleccione una opción:\n" +
                    $"1. Insertar elemento\n" +
                    $"2. Actualizar elemento" +
                    $"3. Eliminar elemento\n" +
                    $"4. Listar todos los elementos\n" +
                    $"5. Insertar masivo\n" +
                    $"100. Salir");

                var opt = Console.ReadLine();
                opcion = byte.Parse(opt);

                switch (opcion)
                {
                    case 1:
                        autos.InsertaAuto();
                        break;

                    case 4:
                        var todos = autos.Get();
                        var contador = 0;
                        foreach (var item in todos)
                        {
                            contador++;
                            Console.WriteLine($"-----Bloque-----{contador}");
                            Console.WriteLine(item.ID);
                            Console.WriteLine(item.Marca);
                            Console.WriteLine(item.Modelo);
                            Console.WriteLine(item.Año);
                            Console.WriteLine(item.Serie);
                            Console.WriteLine($"-----Bloque-----{contador}");
                        }

                        break;

                    case 5:
                        var estado = autos.LlenaMasivoAutos();
                        if (estado)
                        {
                            Console.WriteLine("Lleno los datos");
                        }
                        else
                        {
                            Console.WriteLine("No se pudo llenar la información a la BD");
                        }
                        break;
                }
            } while (opcion != 100);
        }
    }
}