using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMotos.App.Dominio
{
    public class Servicio
    {
        // Identificador único de cada servicio
        public int Id { get; set; }
        /// Fecha y hora en que se realizó la toma del servicio
        public DateTime FechaHora { get; set; }
        /// Valor numérico de la fecha del servicio
        public float Valor {get;set;}
        /// Tipo de servicio aplicado 
        public TipoServicio TipoServicio { get; set; }
        /// Relacion entre cliente y el Tecnico que lo atiende
        public Tecnico Tecnico { get; set; }

    }
}