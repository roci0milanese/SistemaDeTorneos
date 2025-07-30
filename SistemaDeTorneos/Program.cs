using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTorneos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a Deporte Total :)");
                Console.WriteLine("Seleccione una opcion:");
                Console.WriteLine("1. Registrar nuevo equipo");
                Console.WriteLine("2. Ver equipos");
                Console.WriteLine("3. Jugar Partido");
                Console.WriteLine("4. Ver tabla de posiciones");
                Console.WriteLine("5. Ver Historial de partidos");
                Console.WriteLine("6. Registrar Resultados");
                Console.WriteLine("7. Salir");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del equipo:");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese la ciudad del equipo:");
                        string ciudad = Console.ReadLine();
                        Clases.Equipos.AgregarEquipo(nombre, ciudad);
                        break;

                    case 2:
                        Clases.Equipos.VerEquipos();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el nombre del primer equipo:");
                        string equipo1 = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre del segundo equipo:");
                        string equipo2 = Console.ReadLine();
                        Console.WriteLine("¿Cuál es el equipo local?");
                        string local = Console.ReadLine();
                        Console.WriteLine("¿Cuál es el equipo visitante?");
                        string visitante = Console.ReadLine();
                        Console.WriteLine("Ingrese la fecha del partido (yyyy-MM-dd):");
                        DateTime fecha = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese la hora del partido (HH:mm):");
                        DateTime hora = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el lugar del partido:");
                        string lugar = Console.ReadLine();
                        Clases.Partidos.ArmarPartido(equipo1, equipo2, local, visitante, fecha, hora, lugar);
                        break;

                    case 4:
                        Clases.Partidos.VerTablaDePosiciones();
                        break;

                    case 5:
                        Clases.Partidos.PartidosJugados();
                        break;

                    case 6:
                        Clases.Partidos.CargarResultados();
                        break;

                    case 7:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (opcion != 7)
                {
                    Console.WriteLine("\nPresione una tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 7); //mientras no sea 7 lo repite
        }
    }
}
     

    