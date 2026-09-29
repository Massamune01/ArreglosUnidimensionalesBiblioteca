# Análisis de Complejidad y Limitaciones del Arreglo

Catálogo de libros implementado con un arreglo de tamaño fijo (capacidad de **20 libros**) y un contador `cantidad` que indica cuántas posiciones están realmente ocupadas. Sea **n** la cantidad de libros registrados.

## 1. Análisis de complejidad Big O

### Resumen

| Operación | Mejor caso | Caso promedio | Peor caso |
|---|---|---|---|
| Agregar | O(1) | O(1) | O(n)* |
| Listar | O(n) | O(n) | O(n) |
| Buscar por ID | O(1) | O(n) | O(n) |
| Actualizar | O(1) | O(n) | O(n) |
| Eliminar | O(1) | O(n) | O(n) |

\* Con un arreglo de tamaño fijo, agregar es O(1) mientras haya espacio. El O(n) aparece si se valida que el ID no esté repetido, o si se redimensiona el arreglo (ver sección 2).

### Agregar

Se escribe el libro directamente en la posición `libros[cantidad]` y se incrementa el contador. Es un acceso directo por índice, por lo que la complejidad es **O(1)**. Si además se valida que el ID no exista, se suma una búsqueda lineal y el total pasa a **O(n)**.

### Listar

Es necesario recorrer los `n` libros registrados una sola vez para mostrarlos. La complejidad es **O(n)** en todos los casos, ya que siempre se visitan todos los elementos.

### Buscar

Se realiza una **búsqueda lineal**: se compara el ID de cada libro con el buscado hasta encontrarlo.

- **Mejor caso:** el libro está en la primera posición, **O(1)**.
- **Peor caso:** el libro está al final o no existe, se revisan los `n` elementos, **O(n)**.

Si el arreglo estuviera ordenado por ID, se podría usar búsqueda binaria con complejidad **O(log n)**, pero mantener el orden haría más costosa la inserción.

### Actualizar

Primero se debe localizar el libro (búsqueda lineal, **O(n)**) y luego se modifican sus datos (**O(1)**). Total: **O(n) + O(1) = O(n)**.

### Eliminar

Se busca el libro (**O(n)**) y luego se desplazan una posición a la izquierda todos los elementos siguientes para no dejar huecos (**O(n)**). Total: **O(n) + O(n) = O(n)**.

- **Mejor caso:** eliminar el último libro, no hay desplazamiento.
- **Peor caso:** eliminar el primero, se desplazan `n - 1` elementos.

## 2. Limitación del arreglo

### ¿Qué sucede al registrar el libro número 21?

El arreglo se creó con capacidad para 20 elementos, con índices válidos del 0 al 19. Al intentar guardar el libro 21 se accede a la posición 20, que no existe, eso producira el error `IndexOutOfRangeException` en C# y tumba todo sino se procesa correctamente:

```csharp
libros[20] = new Book(21, "Nuevo libro"); // IndexOutOfRangeException
```

El programa lanza una excepción `IndexOutOfRangeException` y el libro no se registra. Si no se controla con una validación previa (`if (cantidad == libros.Length)`) o con un `try/catch`,