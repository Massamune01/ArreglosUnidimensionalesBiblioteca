using System.Net.Http.Headers;

namespace Biblioteca
{
    public class Biblioteca
    {
        public static Book[] libros { get; set; } = new Book[20];
        public int cantidadLibros { get; set; } = 0;

        public Biblioteca()
        {
            libros[0] = new Book(1, "El Quijote");
            libros[1] = new Book(2, "Cien años de soledad");
            libros[2] = new Book(3, "Rayuela");
            libros[3] = new Book(4, "Pedro Páramo");
            libros[4] = new Book(5, "La sombra del viento");
            libros[5] = new Book(6, "El amor en los tiempos del cólera");
            libros[6] = new Book(7, "Ficciones");
            libros[7] = new Book(8, "La ciudad y los perros");
            libros[8] = new Book(9, "Crónica de una muerte anunciada");
            libros[9] = new Book(10, "El túnel");
            cantidadLibros = 10;
        }

        public bool AgregarLibro(Book libro) // O(1)
        {
            if (cantidadLibros == libros.Length)
            {
                Console.WriteLine("La biblioteca ha alcanzado su capacidad maxima");
                return false;
            }

            if (BuscarIndice(libro.Id) != -1) return false; // O(n) validación de ID duplicado

            libros[cantidadLibros] = libro;

            cantidadLibros++;
            return true;
// Incrementar la cantidad de libros después de agregar uno nuevo para no sobreescribir el último libro agregado
        }

        public void ListarLibros() // O(n)
        {
            for (int i = 0; i < cantidadLibros; i++)
            {
                Console.WriteLine(libros[i].ToString());
            }
        }
        public Book BuscarPorId(int id) // O(n)
        {
            int i = BuscarIndice(id);
            return i == -1 ? null : libros[i];
        }

        public bool Actualizar(int id, string nuevoTitulo) // O(n)
        {
            int i = BuscarIndice(id); // O(n)
            if (i == -1) return false;

            libros[i].Titulo = nuevoTitulo; // O(1)
            return true;
        }

        private int BuscarIndice(int id) // O(n)
        {
            for (int i = 0; i < cantidadLibros; i++)
                if (libros[i].Id == id) return i;
            return -1;
        }

        public bool Eliminar(int id) // O(n)
        {
            int i = BuscarIndice(id);
            if (i == -1) return false;

            for (int j = i; j < cantidadLibros - 1; j++)
            {
                libros[j] = libros[j + 1];
            }
            libros[cantidadLibros - 1] = null;
            cantidadLibros--;
            return true;
        }
    }


    public class Book
    {
        public byte Id { get; set; }
        public string Titulo { get; set; }

        public Book(byte id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}";
        }
    }
}
