namespace Biblioteca
{
    public class Ejercicio3
    {
        public static corredor[] corredores { get; set; } = new corredor[20];

        public static corredor[] Fcorredores { get; set; } = null;
        public int count { get; set; } = 0;

        public Ejercicio3()
        {
            corredores[0] = new corredor(10, "Juan", 58);
            corredores[1] = new corredor(20, "Gabriel", 49);
            corredores[2] = new corredor(30, "Martin", 53);
            corredores[3] = new corredor(40, "Pedro Páramo", 55);
            corredores[4] = new corredor(50, "Carlos", 59);
            corredores[5] = new corredor(60, "Jeyco", 54);
            corredores[6] = new corredor(70, "Yahir", 51);
            corredores[7] = new corredor(80, "Soliz", 50);
            corredores[8] = new corredor(90, "Marvin", 60);
            corredores[9] = new corredor(100, "Alba", 57);
            count = 10;

            Fcorredores = (corredor[])corredores.Clone();   
        }

/// <summary>
/// Ordena los corredores de menor a mayor tiempo de llegada
/// usando Insertion Sort.
/// </summary>
public void InsertionSortByLlegada()
{
    int comparaciones = 0;
    int intercambios = 0;

    // Se procesa cada corredor desde el primer índice.
    for (int i = 0; i < count; i++)
    {
        // Se guarda el corredor que se va a insertar.
        corredor actual = corredores[i];

        // Se comienza comparando con el elemento anterior.
        int j = i - 1;

        // Se revisan los elementos que están a la izquierda.
        while (j >= 0)
        {
            comparaciones++;

            // Si el elemento anterior ya está en el orden correcto,
            // no es necesario seguir desplazando elementos.
            if (corredores[j].llegada <= actual.llegada)
            {
                break;
            }

            // Se desplaza el corredor mayor una posición a la derecha.
            corredores[j + 1] = corredores[j];

            j--;
            intercambios++;
        }

        // Se inserta el corredor en la posición correcta.
        corredores[j + 1] = actual;

        // Muestra el arreglo después de insertar el elemento actual.
        Console.WriteLine($"Iteración {i + 1}:");
        ListarCorredores();
        Console.WriteLine();
    }

    Console.WriteLine($"Comparaciones: {comparaciones}");
    Console.WriteLine($"Intercambios: {intercambios}");
}

        public void ListarCorredores()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(corredores[i]);
            }
        }

        public void ListarCorredoresDesordenada()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Fcorredores[i]);
            }
        }

    }

    public class corredor
    {
        public int id;
        public string name;
        public int llegada;

        public corredor(int id, string name, int llegada)
        {
            this.id = id;
            this.name = name;
            this.llegada = llegada;
        }

        public override string ToString()
        {
            return $"Name: {name}, Llegada: {llegada}";
        }
    }
}
