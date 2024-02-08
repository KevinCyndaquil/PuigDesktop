using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.finances
{
    [Serializable]
    public abstract class Articulo
    {
        [NotNull] [JsonPropertyName("_codigo")] public string Codigo { get; set; }
        [NotNull] public string Nombre { get; set; }
        [NotNull] public float Precio { get; set; }

        public enum Categorias
        {
            PLATILLO,
            BEBIDA,
            ADICIONAL
        }

        public Articulo(string codigo,
                        string nombre,
                        float precio) 
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"#{Codigo} {Nombre}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Articulo articulo)) return false;
            return Codigo.Equals(articulo.Codigo) || Nombre.Equals(articulo.Nombre);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;

                hash = hash * 23 + Codigo.GetHashCode();
                hash = hash * 23 + Nombre.GetHashCode();

                return hash;
            }
        }
    }
}
