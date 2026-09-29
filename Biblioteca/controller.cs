namespace Biblioteca
{
    public class controller
    {
        Biblioteca biblioteca = new Biblioteca();
        public void AgregarLibro()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del libro: *Ejemplo: 1,2,3...*");
                Console.WriteLine("*ERROR SI INGRESA UNO DUPLICADO*");
                byte id = Convert.ToByte(Console.ReadLine());
                Console.WriteLine("Ingrese el título del libro:");
                string titulo = Console.ReadLine();
                Book libro = new Book(id, titulo);
                bool result = biblioteca.AgregarLibro(libro);
                if(result) Console.WriteLine("Libro Agregado con Exito!!");
                else Console.WriteLine("Error intentelo de nuevo *Posible ID DUPLICADO");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return;
            }
        }

        public void ListarLibros()
        {
            Console.Clear();
            biblioteca.ListarLibros();
        }

        public void BuscarLibroPorId()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del libro a buscar:");
            byte id = Convert.ToByte(Console.ReadLine());
            Book libro = biblioteca.BuscarPorId(id);
            if (libro != null)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine(libro.ToString());
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public void ActualizarLibro()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del libro a actualizar:");
            byte id = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo título del libro:");
            string nuevoTitulo = Console.ReadLine();
            bool actualizado = biblioteca.Actualizar(id, nuevoTitulo);
            if (actualizado)
            {
                Console.WriteLine("Libro actualizado con éxito.");
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }

        public void EliminarLibro()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el ID del libro a eliminar:");
            byte id = Convert.ToByte(Console.ReadLine());
            bool eliminado = biblioteca.Eliminar(id);
            if (eliminado)
            {
                Console.WriteLine("Libro eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
        }
    }
}
