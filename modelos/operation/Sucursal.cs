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
    public class Sucursal
    {
        [JsonPropertyName("_id")] public string Id { get; set; }
        [NotNull] public string Nombre { get; set; }
        [NotNull] public Direccion Direccion { get; set; }
        [NotNull] public TimeSpan Hora_abre { get; set; }
        [NotNull] public TimeSpan Hora_cierra { get; set; }

        public Sucursal(string nombre,
                        Direccion direccion,
                        TimeSpan hora_abre,
                        TimeSpan hora_cierra,
                        string id = null)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Hora_abre = hora_abre;
            Hora_cierra = hora_cierra;
        }

        public override string ToString()
        {
            return $"{Nombre} {Direccion.Calle_principal}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Sucursal sucursal)) return false;
            if (Id is null) return Nombre.Equals(sucursal.Nombre);
            return Id.Equals(sucursal.Id);
        }

        public override int GetHashCode()
        {
            if (Id is null) return Nombre.GetHashCode();
            return Id.GetHashCode();
        }
    }
}
