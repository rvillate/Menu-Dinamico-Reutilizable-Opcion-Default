using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            seleccionDefault++; // index + 1 para correccion
            Console.WriteLine($"\nOpcion seleccionada: {opciones[seleccionDefault - 1]}\n");

            return seleccionDefault;
        }
    }
}
