using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiMotos.App.Dominio
{
    public class Tecnico :Persona
    {

        /// numéro de Registro profesional
        public int Registro { get; set;}
        /// disponibilidad del tecnico 
        public string Disponibilidad {get;set; }
    }
}