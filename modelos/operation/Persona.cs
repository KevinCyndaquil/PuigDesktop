using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.operation
{
    [Serializable]
    public abstract class Persona
    {
        [JsonPropertyName("_id")] public string Id { get; set; }
        [NotNull] public string Nombre { get; set; }
        [NotNull] public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        [NotNull] public string Rfc { get; set; }
        public string Telefono { get; set; }

        public Persona(string nombre,
                       string apellido_paterno,
                       string apellido_materno,
                       string rfc,
                       string telefono,
                       string id = null)
        {
            Id = id;
            Nombre = nombre;
            Apellido_paterno = apellido_paterno;
            Apellido_materno = apellido_materno;
            Rfc = rfc;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Nombre} {Apellido_paterno} {Apellido_materno}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Persona persona)) return false;
            if (Id is null) return Nombre.Equals(persona.Id) && Apellido_paterno.Equals(persona.Apellido_paterno) && Apellido_materno.Equals(persona.Apellido_materno);
            return Id.Equals(persona.Id);
        }

        public override int GetHashCode()
        {
            if (Id is null)
            {
                unchecked
                {
                    int hash = 17; // Un número primo inicial

                    // Combina el hash con el código hash de cada propiedad
                    hash = hash * 23 + Nombre.GetHashCode();
                    hash = hash * 23 + Apellido_paterno.GetHashCode();
                    hash = hash * 23 + (Apellido_materno?.GetHashCode() ?? 0);

                    return hash;
                }
            }
            return Id.GetHashCode();
        }
    }
}
