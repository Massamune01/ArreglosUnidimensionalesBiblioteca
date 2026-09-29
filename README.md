# An�lisis de Complejidad y Limitaciones del Arreglo

Cat�logo de libros implementado con un arreglo de tama�o fijo (capacidad de **20 libros**) y un contador `cantidad` que indica cu�ntas posiciones est�n realmente ocupadas. Sea **n** la cantidad de libros registrados.

## 1. An�lisis de complejidad Big O

### Resumen

| Operaci�n | Mejor caso | Caso promedio | Peor caso |
|---|---|---|---|
| Agregar | O(1) | O(1) | O(n)* |
| Listar | O(n) | O(n) | O(n) |
| Buscar por ID | O(1) | O(n) | O(n) |
| Actualizar | O(1) | O(n) | O(n) |
| Eliminar | O(1) | O(n) | O(n) |

\* Con un arreglo de tama�o fijo, agregar es O(1) mientras haya espacio. El O(n) aparece si se valida que el ID no est� repetido, o si se redimensiona el arreglo (ver secci�n 2).

### Agregar

Se escribe el libro directamente en la posici�n `libros[cantidad]` y se incrementa el contador. Es un acceso directo por �ndice, por lo que la complejidad es **O(1)**. Si adem�s se valida que el ID no exista, se suma una b�squeda lineal y el total pasa a **O(n)**.

### Listar

Es necesario recorrer los `n` libros registrados una sola vez para mostrarlos. La complejidad es **O(n)** en todos los casos, ya que siempre se visitan todos los elementos.

### Buscar

Se realiza una **b�squeda lineal**: se compara el ID de cada libro con el buscado hasta encontrarlo.

- **Mejor caso:** el libro est� en la primera posici�n, **O(1)**.
- **Peor caso:** el libro est� al final o no existe, se revisan los `n` elementos, **O(n)**.

Si el arreglo estuviera ordenado por ID, se podr�a usar b�squeda binaria con complejidad **O(log n)**, pero mantener el orden har�a m�s costosa la inserci�n.

### Actualizar

Primero se debe localizar el libro (b�squeda lineal, **O(n)**) y luego se modifican sus datos (**O(1)**). Total: **O(n) + O(1) = O(n)**.

### Eliminar

Se busca el libro (**O(n)**) y luego se desplazan una posici�n a la izquierda todos los elementos siguientes para no dejar huecos (**O(n)**). Total: **O(n) + O(n) = O(n)**.

- **Mejor caso:** eliminar el �ltimo libro, no hay desplazamiento.
- **Peor caso:** eliminar el primero, se desplazan `n - 1` elementos.

## 2. Limitaci�n del arreglo

### �Qu� sucede al registrar el libro n�mero 21?

El arreglo se cre� con capacidad para 20 elementos, con �ndices v�lidos del 0 al 19. Al intentar guardar el libro 21 se accede a la posici�n 20, que no existe, eso producira el error `IndexOutOfRangeException` en C# y tumba todo sino se procesa correctamente:

```csharp
libros[20] = new Book(21, "Nuevo libro"); // IndexOutOfRangeException
```

El programa lanza una excepci�n `IndexOutOfRangeException` y el libro no se registra. Si no se controla con una validaci�n previa (`if (cantidad == libros.Length)`) o con un `try/catch`,
