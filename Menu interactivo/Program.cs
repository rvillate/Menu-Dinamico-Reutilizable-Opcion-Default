using System.Security.Cryptography.X509Certificates;
using Menu_interactivo;

namespace MenuInteractivo
{
    class Program
    {
        
        static void Main()
        {
            MenuDinamico menu = new MenuDinamico();
            int opcion = menu.CrearMenu("Seleccione una", new string[] {"1 - Subir", "2 - Bajar", "3 - Eliminar", "4 - Nada" });

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Logica para una accion de Subir");
                    break;
                case 2:
                    Console.WriteLine("Logica para una accion de Bajar");
                    break;
                case 3:
                    Console.WriteLine("Logica para una accion de Eliminar");
                    break;
                case 4:
                    Console.WriteLine("Logica para una accion de no hacer Nada");
                    break;
                default:
                    break;
            }
            opcion = menu.CrearMenu("Seleccione otra", new string[] { "1 - Subir", "2 - Bajar", "3 - Eliminar", "4 - Nada" }, 3);
        }
    }

}