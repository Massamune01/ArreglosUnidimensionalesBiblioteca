namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            controller controller = new controller();
            bool run = true;
            while (run)
            {

                Console.WriteLine("====== SISTEMA DE BIBLIOTECA ======");
                Console.WriteLine(""""
                    1. Agregar libro
                    2. Listar libros
                    3. Buscar libro por ID
                    4. Actualizar libro
                    5. Eliminar libro
                    0. Salir
                
                    """");

               
                Console.WriteLine("Seleccione una opción:");

                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        controller.AgregarLibro();
                        break;
                    case 2:
                        controller.ListarLibros();
                        break;
                    case 3:
                        controller.BuscarLibroPorId();
                        break;
                    case 4:
                        controller.ActualizarLibro();
                        break;
                    case 5:
                        controller.EliminarLibro();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del sistema...");
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                        break;
                }


            }
        }
    }
}
