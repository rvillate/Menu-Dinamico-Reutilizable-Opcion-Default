# Menú Dinámico en C#

Este proyecto incluye una clase reutilizable llamada `MenuDinamico` que permite crear menús interactivos en la consola, donde el usuario puede navegar entre las opciones utilizando las teclas de flechas y seleccionar una opción con la tecla "Enter". El menú es personalizable y flexible para diversos escenarios.

## Características

- **Interacción con el teclado**: Usa las flechas arriba/abajo para navegar por las opciones y "Enter" para seleccionar.
- **Visualización clara**: La opción seleccionada se resalta en la consola.
- **Parámetro de selección predeterminado**: Se puede definir una opción predeterminada que será seleccionada automáticamente si el usuario no elige ninguna.
- **Reutilizable**: Fácil de usar y adaptar en diferentes contextos.

## Cómo usar

### 1. Incluir la clase `MenuDinamico`
Primero, agrega la clase `MenuDinamico` a tu proyecto.

```csharp
using System;
namespace Menu_interactivo
{
    internal class MenuDinamico
    {
        public int CrearMenu(string titulo, String[] opciones, int seleccionDefault = -1)
        {
            Console.CursorVisible = false;
            if (Console.CursorTop != 0)
            {
                Console.WriteLine();
            }

            Console.WriteLine(titulo + (seleccionDefault != -1 ? $" (Por defecto {seleccionDefault})" : "") + ":");
            seleccionDefault = seleccionDefault == -1 ? 0 : seleccionDefault-1;
            int y = Console.CursorTop;
            int cont = 0;
            int cursorInicio = Console.CursorTop;

            ConsoleKeyInfo accionKey = new ConsoleKeyInfo();
            do
            {
                Console.CursorTop = cursorInicio;
                cont = 0;

                if (accionKey.Key == ConsoleKey.UpArrow)
                {
                    seleccionDefault--;
                }
                else if (accionKey.Key == ConsoleKey.DownArrow)
                {
                    seleccionDefault++;
                }

                if (seleccionDefault > opciones.Length - 1)
                {
                    seleccionDefault = 0;
                }
                else if (seleccionDefault < 0)
                {
                    seleccionDefault = opciones.Length - 1;
                }
                Array.ForEach(opciones, opcion =>
                {
                    if (cont == seleccionDefault)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"-> {opcion}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {opcion}");
                    }
                    cont++;
                });
            } while ((accionKey = Console.ReadKey(true)).Key != ConsoleKey.Enter);

            seleccionDefault++; // index + 1 para corrección
            Console.WriteLine($"\nOpción seleccionada: {opciones[seleccionDefault - 1]}\n");
            return seleccionDefault;
        }
    }
}
```




### 2. Crear un menú en tu aplicación
Primero, agrega la clase `MenuDinamico` a tu proyecto.

```csharp
using Menu_interactivo;

namespace MenuInteractivo
{
    class Program
    {
        static void Main()
        {
            MenuDinamico menu = new MenuDinamico();
            
            // Crear un menú simple
            int opcion = menu.CrearMenu("Seleccione una opción", new string[] { "1 - Subir", "2 - Bajar", "3 - Eliminar", "4 - Nada" });

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Lógica para una acción de Subir");
                    break;
                case 2:
                    Console.WriteLine("Lógica para una acción de Bajar");
                    break;
                case 3:
                    Console.WriteLine("Lógica para una acción de Eliminar");
                    break;
                case 4:
                    Console.WriteLine("Lógica para no hacer nada");
                    break;
                default:
                    break;
            }

            // Crear otro menú con opción predeterminada
            opcion = menu.CrearMenu("Seleccione otra opción", new string[] { "1 - Subir", "2 - Bajar", "3 - Eliminar", "4 - Nada" }, 3);
            Console.WriteLine($"La opción seleccionada fue: {opcion}");
        }
    }
}
```


# Ejemplos de uso
## Menú simple

```csharp
int opcion = menu.CrearMenu("Seleccione una opción", new string[] { "1 - Iniciar", "2 - Configurar", "3 - Salir" });
```

Esto creará un menú interactivo en la consola con las opciones:

```diff
Seleccione una opción:
-> 1 - Iniciar
   2 - Configurar
   3 - Salir
```

Menú con selección predeterminada

```csharp
int opcion = menu.CrearMenu("Seleccione una opción", new string[] { "1 - Opción A", "2 - Opción B", "3 - Opción C" }, 2);
```

En este ejemplo, la opción predeterminada será la segunda opción (Opción B).

Agregar lógica a las opciones

```csharp
switch (opcion)
{
    case 1:
        // Lógica para la opción 1
        break;
    case 2:
        // Lógica para la opción 2
        break;
    case 3:
        // Lógica para la opción 3
        break;
    default:
        break;
}
```

+ Titulo del menú: El primer parámetro de CrearMenu permite personalizar el título que se muestra al usuario.
+ Opciones del menú: El segundo parámetro es un array de strings que define las opciones disponibles en el menú.
+ Selección predeterminada: El tercer parámetro (opcional) establece la opción predeterminada cuando el menú se muestra.

# Requerimientos
+ .NET 6.0 o superior

# Contribuir
+ Haz un fork de este repositorio.
+ Crea una nueva rama para tu funcionalidad (git checkout -b nueva-funcionalidad).
+ Realiza tus cambios y haz commit (git commit -m 'Añadir nueva funcionalidad').
+ Haz push a la rama (git push origin nueva-funcionalidad).
+ Abre un Pull Request.

# Licencia
## Este proyecto está licenciado bajo la Licencia MIT - consulta el archivo LICENSE para más detalles.


# Personalización
