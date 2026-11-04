using System.Net.Http.Headers;

namespace Biblioteca
{
    public class Biblioteca
    {
        public static Book[] books { get; set; } = new Book[20];
        public static Book[] Fbooks { get; set; } = null;
        public int count { get; set; } = 0;

        public Biblioteca()
        {
            books[0] = new Book(10, "El Quijote");
            books[1] = new Book(20, "Cien años de soledad");
            books[2] = new Book(30, "Rayuela");
            books[3] = new Book(40, "Pedro Páramo");
            books[4] = new Book(50, "La sombra del viento");
            books[5] = new Book(60, "El amor en los tiempos del cólera");
            books[6] = new Book(70, "Ficciones");
            books[7] = new Book(80, "La ciudad y los perros");
            books[8] = new Book(90, "Crónica de una muerte anunciada");
            books[9] = new Book(100, "El túnel");
            count = 10;

            Fbooks = (Book[])(books.Clone());
        }

        public bool AgregarLibro(Book libro) // O(1)
        {
            if (count == books.Length)
            {
                Console.WriteLine("La biblioteca ha alcanzado su capacidad maxima");
                return false;
            }

            if (BuscarIndice(libro.Id ?? -1) != -1) return false; // O(n) validación de ID duplicado

            books[count] = libro;
            count++;
            return true;
// Incrementar la cantidad de libros después de agregar uno nuevo para no sobreescribir el último libro agregado
        }

        public void BubbleSortByTitulo() // O(n^2)
        {
            int comparaciones = 0;
            int intercambios = 0;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    comparaciones++;

                    if (string.Compare(books[j].Titulo, books[j + 1].Titulo) > 0)
                    {
                        Book temporal = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temporal;

                        intercambios++;
                    }
                }

                Console.WriteLine($"Iteración {i + 1}:");
                ListarLibros();
                Console.WriteLine();
            }

            Console.WriteLine($"Comparaciones: {comparaciones}");
            Console.WriteLine($"Intercambios: {intercambios}");
        }

        public void BubbleSortById()
        {
            int comparaciones = 0;
            int intercambios = 0;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    comparaciones++;

                    if (books[j].Id > books[j + 1].Id)
                    {
                        Book temporal = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temporal;

                        intercambios++;
                    }
                }

                Console.WriteLine($"Iteración {i + 1}:");
                ListarLibros();
                Console.WriteLine();
            }

            Console.WriteLine($"Comparaciones: {comparaciones}");
            Console.WriteLine($"Intercambios: {intercambios}");
        }

        public void ListarLibros() // O(n)
        {
            Console.WriteLine("Libros:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i].ToString());
            }
        }

        public void ListarLibrosDesordenada() // O(n)
        {
            Console.WriteLine("Libros desordenados:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(books[i].ToString());
            }
        }

        public Book BuscarPorId(int? id) // O(n)
        {
            int i = BuscarIndice(id);
            return i == -1 ? null : books[i];
        }

        public bool Actualizar(int id, string nuevoTitulo) // O(n)
        {
            int i = BuscarIndice(id); // O(n)
            if (i == -1) return false;

            books[i].Titulo = nuevoTitulo; // O(1)
            return true;
        }

        private int BuscarIndice(int? id) // O(n)
        {
            for (int i = 0; i < count; i++)
                if (books[i].Id == id) return i;
            return -1;
        }

        public bool Eliminar(int id) // O(n)
        {
            int i = BuscarIndice(id);
            if (i == -1) return false;

            for (int j = i; j < count - 1; j++)
            {
                books[j] = books[j + 1];
            }
            books[count - 1] = null;
            count--;
            return true;
        }
    }


    public class Book
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? autor { get; set; }
        public int? anioPublicacion { get; set; } = 0;

        public Book(int? id, string? titulo, string? autor = null, int? anioPublicacion = null)
        {
            Id = id;
            Titulo = titulo;
            this.autor = autor;
            this.anioPublicacion = anioPublicacion;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Autor: {autor}";
        }
    }
}
