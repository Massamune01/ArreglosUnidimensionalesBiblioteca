namespace Biblioteca
{
    public class Ejercicio2
    {
        public static producto[] productos { get; set; } = new producto[20];
        public static producto[] Fproductos { get; set; } = null;
        public int count { get; set; } = 0;

        public Ejercicio2()
        {
            productos[0] = new producto(1, "Cuaderno", 50);
            productos[1] = new producto(2, "Lápiz", 10);
            productos[2] = new producto(3, "Borrador", 15);
            productos[3] = new producto(4, "Regla", 25);
            productos[4] = new producto(5, "Pluma", 20);
            productos[5] = new producto(6, "Marcadores", 80);
            productos[6] = new producto(7, "Carpeta", 45);
            productos[7] = new producto(8, "Mochila", 350);
            productos[8] = new producto(9, "Calculadora", 250);
            productos[9] = new producto(10, "Tijeras", 35);

            Fproductos = (producto[])productos.Clone();
            count = 10;
        }

        /// <summary>
        /// Ordena los productos de menor a mayor precio usando Selection Sort.
        /// </summary>
        /// <param name="productos">Arreglo de productos que se va a ordenar.</param>
        public void SelectionSort(producto[] productos)
        {
            int comparaciones = 0;
            int intercambios = 0;

            // La posición i representa el lugar que se va a ordenar.
            for (int i = 0; i < count - 1; i++)
            {
                // Al principio se supone que el elemento actual es el menor.
                int indiceMenor = i;

                // Se busca el producto más barato en la parte desordenada.
                for (int j = i + 1; j < count; j++)
                {
                    comparaciones++;

                    // Si se encuentra un precio menor, se guarda su índice.
                    if (productos[j].price < productos[indiceMenor].price)
                    {
                        indiceMenor = j;
                    }
                }

                // Solo se intercambia si se encontró un elemento menor.
                if (indiceMenor != i)
                {
                    producto temporal = productos[i];
                    productos[i] = productos[indiceMenor];
                    productos[indiceMenor] = temporal;

                    intercambios++;
                }

                // Muestra el arreglo después de colocar el menor elemento.
                Console.WriteLine($"Iteración {i + 1}:");
                ListarProductos(productos);
                Console.WriteLine();
            }

            Console.WriteLine($"Comparaciones: {comparaciones}");
            Console.WriteLine($"Intercambios: {intercambios}");
        }

        public void ListarProductos() // O(n)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(productos[i]);
            }
        }

        public void ListarProductosDesordenada() // O(n)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Fproductos[i]);
            }
        }

        public void ListarProductos(producto[] productos)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(productos[i]);
            }
        }


    }

    public class producto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public producto(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"ID: {id}, Nombre: {name}, Precio: ${price}";
        }
    }
}
