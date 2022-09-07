using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMotos.App.Dominio
{
    public class Cliente: Persona
    {
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