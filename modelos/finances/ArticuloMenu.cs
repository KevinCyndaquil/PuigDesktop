using JetBrains.Annotations;
using PuigDesktop.modelos.admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.finances
{
    [Serializable]
    public class ArticuloMenu : Articulo
    {
        [NotNull] public Categorias Tipo { get; set; }
        [NotNull] public Dictionary<Producto, float> Receta { get; set; }

        [JsonConstructor] 
        public ArticuloMenu(string codigo,
                            string nombre,
                            float precio,
                            Categorias tipo,
                            Dictionary<Producto, float> receta) : base(codigo, nombre, precio)
        {
            Tipo = tipo;
            Receta = receta;
        }

        public ArticuloMenu(string codigo,
                            string nombre,
                            float precio,
                            Categorias tipo) : this(codigo, nombre, precio, tipo, new Dictionary<Producto, float>())
        {

        }
    }
}
