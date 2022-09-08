using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMotos.App.Dominio
{
    public class HitorialTecnico
    {
        // Identificador único de cada HistorialTecnico
        public int Id { get; set; }
        ///Descripcion detallada del Mantenimiento del Servicio
        public string DescripcionMantenimiento { get; set; }
        // fecha de la realizacion del servicio
        public DateTime FechaHora { get; set; }
    }
}