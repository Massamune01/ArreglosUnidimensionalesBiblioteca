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

        public void BuscarLibroPorId(int? busqueda = null)
        {
            if(busqueda >= 0)
            {
                Book flibro = biblioteca.BuscarPorId(busqueda);
                if (flibro != null)
                {
                    Console.WriteLine("Libro encontrado:");
                    Console.WriteLine(flibro.ToString());
                }
            }

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

        public int? BinarySearchById(Book[] books, int count, int id)
        {
            if (!validateInput(books, count, id))
            {
                return null;
            }

            int cantidadcomparaciones = 0;
            int iteracion = 1;
            int left = 0;
            int right = count - 1;

            Console.WriteLine("Iteración | left | right | middle | ID central | Decisión");

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (books[middle] is null)
                {
                    cantidadcomparaciones++;
                    Console.WriteLine(
                        $"{iteracion,9} | {left,4} | {right,5} | {middle,6} | {"—",10} | Posición vacía; se detiene la búsqueda");
                    Console.WriteLine("Comparaciones: " + cantidadcomparaciones);
                    return null;
                }

                int? idCentral = books[middle].Id;
                cantidadcomparaciones++;

                if (idCentral is null)
                {
                    Console.WriteLine(
                        $"{iteracion,9} | {left,4} | {right,5} | {middle,6} | {"null",10} | ID central nulo; no se puede continuar");
                    Console.WriteLine("Comparaciones: " + cantidadcomparaciones);
                    return null;
                }

                if (idCentral == id)
                {
                    Console.WriteLine(
                        $"{iteracion,9} | {left,4} | {right,5} | {middle,6} | {idCentral,10} | Encontrado");
                    Console.WriteLine("Comparaciones: " + cantidadcomparaciones);
                    return middle;
                }

                if (id < idCentral.Value)
                {
                    right = middle - 1;
                    Console.WriteLine(
                        $"{iteracion,9} | {left,4} | {right + 1,5} | {middle,6} | {idCentral,10} | ID buscado menor; right = {right}");
                }
                else
                {
                    left = middle + 1;
                    Console.WriteLine(
                        $"{iteracion,9} | {left - 1,4} | {right,5} | {middle,6} | {idCentral,10} | ID buscado mayor; left = {left}");
                }

                iteracion++;
            }

            Console.WriteLine("Comparaciones: " + cantidadcomparaciones);
            return null;
        }

        private bool validateInput(Book[] books, int count, int id)
        {
            if (books is null)
            {
                Console.WriteLine("El arreglo de libros es nulo.");
                return false;
            }

            if (count <= 0)
            {
                Console.WriteLine("No hay libros en la biblioteca.");
                return false;
            }

            if (count > books.Length)
            {
                Console.WriteLine("La cantidad de libros supera el tamaño del arreglo.");
                return false;
            }

            if (id < 0)
            {
                Console.WriteLine("El ID no puede ser negativo.");
                return false;
            }

            return true;
        }
    }
}
