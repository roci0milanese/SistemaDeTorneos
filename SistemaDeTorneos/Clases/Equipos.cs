using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeTorneos.Clases
{
    public class Equipos
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int GolesAFavor { get; set; } = 0;
        public int GolesEnContra { get; set; } = 0;
        public int Puntos { get; set; } = 0;

        public static List<Equipos> ListaEquipos = new List<Equipos>();

        public Equipos(string nombre, string ciudad)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;
        }

        public static void AgregarEquipo(string nombre, string ciudad) //Registrar un nuevo equipo
        {
            Equipos nuevoEquipo = new Equipos(nombre, ciudad);
            ListaEquipos.Add(nuevoEquipo);
        }

      

        public static void VerEquipos()
        {
            if (ListaEquipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
            }
            else
            {
                Console.WriteLine("Equipos registrados:");
                foreach (var equipo in ListaEquipos)
                {
                    Console.WriteLine($"Nombre: {equipo.Nombre}, Ciudad: {equipo.Ciudad}, Goles a favor: {equipo.GolesAFavor}, Goles en contra: {equipo.GolesEnContra}, Puntos: {equipo.Puntos}");
                }
            }
        }
    }

}



