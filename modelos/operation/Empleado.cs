using JetBrains.Annotations;
using PuigDesktop.modelos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.operation
{
    [Serializable]
    public class Empleado : Persona
    {
        [NotNull] public DateTime? Fecha_nacimiento { get; set; }
        [NotNull] public DateTime? Fecha_alta { get; set; }
        [NotNull] public string Curp { get; set; }
        [NotNull] public Puestos Puesto { get; set; }
        [NotNull] public Tarjeta Cuenta_nomina { get; set; }

        public enum Puestos
        {
            GERENTE,
            EMPLEADO,
            ADMIN,
        }

        public Empleado(string nombre,
                        string apellido_paterno,
                        string apellido_materno,
                        string rfc,
                        string telefono,
                        DateTime? fecha_nacimiento,
                        DateTime? fecha_alta,
                        string curp,
                        Puestos puesto,
                        Tarjeta cuenta_nomina,
                        string id = null) : base(nombre, apellido_paterno, apellido_materno, rfc, telefono, id)
        {
            Fecha_nacimiento = fecha_nacimiento;
            Fecha_alta = fecha_alta;
            Curp = curp;
            Puesto = puesto;
            Cuenta_nomina = cuenta_nomina;
        }
    }
}
