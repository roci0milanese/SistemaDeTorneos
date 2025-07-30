using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTorneos.Clases
{

    public class Partidos
    {
        //Atributos de la clase Partidos
        public string NombreEquipo1 { get; set; }
        public string NombreEquipo2 { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Resultado { get; set; }
        public string Lugar { get; set; }
        public int GolesAFavor { get; set; } = 0;
        public int GolesEnContra { get; set; } = 0;
        public int Puntos { get; set; } = 0;

        public static List<Partidos> ListaPartidos = new List<Partidos>(); //lista de partidos
        public Partidos(string NombreEquipo1, string NombreEquipo2, string equipoLocal,
            string equipoVisitante, DateTime fecha, DateTime hora, string lugar) //constructor de partidos
        {
            this.NombreEquipo1 = NombreEquipo1;
            this.NombreEquipo2 = NombreEquipo2;
            this.EquipoLocal = equipoLocal;
            this.EquipoVisitante = equipoVisitante;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Lugar = lugar;
        }


        public static void ArmarPartido(string NombreEquipo1, string NombreEquipo2, string equipoLocal,
            string equipoVisitante, DateTime fecha, DateTime hora, string lugar) //metodo para agregar partidos
        {
            Partidos partido = new Partidos(NombreEquipo1, NombreEquipo2, equipoLocal, equipoVisitante, fecha, hora, lugar);
            ListaPartidos.Add(partido);
        }
        public static void CargarResultados()
        {
            Console.WriteLine("Para registrar el resultado de un partido ingrese los nombres de los equipos y la fecha: ");
            Console.Write("Equipo 1: ");
            string nombre1 = Console.ReadLine();
            Console.Write("Equipo 2: ");
            string nombre2 = Console.ReadLine();
            Console.Write("Fecha del partido (dd/mm/yyyy): ");
            DateTime fechaPartido = DateTime.Parse(Console.ReadLine());

            foreach (var partido in ListaPartidos)
            {
                if (partido.NombreEquipo1 == nombre1 && partido.NombreEquipo2 == nombre2 && partido.Fecha.Date == fechaPartido.Date)
                {
                    Console.Write("Ingrese el resultado del partido (ejemplo: 2-1): ");
                    partido.Resultado = Console.ReadLine();

                    string[] goles = partido.Resultado.Split('-');
                    int goles1 = int.Parse(goles[0]);
                    int goles2 = int.Parse(goles[1]);

                    Equipos equipo1 = null;
                    Equipos equipo2 = null;

                    foreach (var eq in Equipos.ListaEquipos)
                    {
                        if (eq.Nombre == nombre1)
                            equipo1 = eq;
                        else if (eq.Nombre == nombre2)
                            equipo2 = eq;
                    }

                    if (equipo1 != null && equipo2 != null)
                    {
                        equipo1.GolesAFavor += goles1;
                        equipo1.GolesEnContra += goles2;

                        equipo2.GolesAFavor += goles2;
                        equipo2.GolesEnContra += goles1;

                        if (goles1 > goles2)
                            equipo1.Puntos += 3; // Gana equipo 1
                        else if (goles2 > goles1)
                            equipo2.Puntos += 3; // Gana equipo 2
                        else
                        {
                            equipo1.Puntos += 1; // Empate
                            equipo2.Puntos += 1;
                        }

                        Console.WriteLine("Resultado registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Uno o ambos equipos no fueron encontrados.");
                    }

                    return;
                }
            }

            Console.WriteLine("No se encontró el partido con esos datos.");
        }
        public static void VerTablaDePosiciones()
        {
            if (Equipos.ListaEquipos.Count == 0)
            {
                Console.WriteLine("No hay datos todavía");
                return;
            }

            Console.WriteLine("Tabla de posiciones:");
            Console.WriteLine("Posición - Equipo - Puntos - Goles a favor - Goles en contra");

            int posicion = 1;

            foreach (var equipo in Equipos.ListaEquipos)
            {
                Console.WriteLine("Posición: " + posicion);
                Console.WriteLine("Equipo: " + equipo.Nombre);
                Console.WriteLine("Puntos: " + equipo.Puntos);
                Console.WriteLine("Goles a favor: " + equipo.GolesAFavor);
                Console.WriteLine("Goles en contra: " + equipo.GolesEnContra);

                posicion++;
            }
        }
        public static void PartidosJugados()
        {
            if (ListaPartidos.Count == 0)
            {
                Console.WriteLine("No hay partidos jugados.");
                return;
            }
            Console.WriteLine("Partidos jugados:");
            foreach (var partido in ListaPartidos)
            {
                Console.WriteLine($"Fecha: {partido.Fecha}, Hora: {partido.Hora}, " +
                                  $"Equipo Local: {partido.EquipoLocal}, Equipo Visitante: {partido.EquipoVisitante}, " +
                                  $"Resultado: {partido.Resultado}, Lugar: {partido.Lugar}");
            }
        }
    }
}



