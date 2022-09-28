using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMoto.Models
{
    public class Cliente 
    {   
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NumeroTelefono { get; set; }
        public string Direccion { get; set; }
        /// Coordenada de la dirección del cliente                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        public float Latitud { get; set; }
        /// Coordenada de la dirección del cliente
        public float Longitud { get; set; }
        public Servicio Servicio { get; set; }
        /// Relacion entre cliente y su Historia del cliente
        public HistorialCliente HistorialCliente { get; set; }
        
    }
}