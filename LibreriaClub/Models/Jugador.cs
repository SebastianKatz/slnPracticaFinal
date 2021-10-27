using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClub.Models
{
    public class Jugador : Persona
    {
        public Jugador()
        {
        }

        public Jugador(string nombre, string apellido, DateTime fechaNacimiento, string puesto) : base(nombre, apellido)
        {
            FechaNacimiento = fechaNacimiento;
            Puesto = puesto;
        }

        public DateTime FechaNacimiento { get; set; }
        public string Puesto { get; set; }
    }
}
