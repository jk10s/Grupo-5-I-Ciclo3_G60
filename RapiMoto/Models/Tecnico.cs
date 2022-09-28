using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMoto.Models
{
    public class Tecnico
    {   
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroTelefono { get; set; }
        /// numéro de Registro profesional
        public int Registro { get; set;}
        /// disponibilidad del tecnico 
        public string Disponibilidad {get;set; }
        ///public HitorialTecnico HitorialTecnico { get; set; }
        
    }
}