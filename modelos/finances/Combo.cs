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
    public class Combo : Articulo
    {
        [NotNull] public HashSet<ArticuloMenu> Contenido { get; set; }
        [NotNull] public DateTimeOffset Inicia { get; set; }
        [NotNull] public DateTimeOffset Vigencia { get; set; }

        [JsonConstructor] 
        public Combo(string codigo,
                     string nombre,
                     float precio,
                     HashSet<ArticuloMenu> contenido,
                     DateTimeOffset inicia,
                     DateTimeOffset vigencia) : base(codigo, nombre, precio)
        {
            Contenido = contenido;
            Inicia = inicia;
            Vigencia = vigencia;
        }

        public Combo(string codigo,
                     string nombre,
                     float precio,
                     DateTimeOffset inicia,
                     DateTimeOffset vigencia) : this(codigo, nombre, precio, new HashSet<ArticuloMenu>(), inicia, vigencia)
        {

        }
    }
}
