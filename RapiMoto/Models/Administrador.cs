using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RapiMoto.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroTelefono { get; set; }
        public string correo {get; set;}
        public TipoAdmin TipoAdmin {get; set;}
        
    }
}