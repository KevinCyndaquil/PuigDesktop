using JetBrains.Annotations;
using PuigDesktop.modelos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.admin
{
    [Serializable]
    public class Producto
    {
        [NotNull] [JsonPropertyName("_codigo")] public string Codigo { get; set; }
        [NotNull] public Proveedor.Producto Producto_proveedor { get; set; }
        [NotNull] public int Cantidad_bodega { get; set; }
        [NotNull] public bool Inventariado { get; set; }
    
        public Producto(Proveedor.Producto producto_proveedor,
                        int cantidad_bodega,
                        bool inventariado = true)
        {
            Codigo = producto_proveedor.Codigo;
            Cantidad_bodega = cantidad_bodega;
            Inventariado = inventariado;
        }

        public override string ToString()
        {
            return Producto_proveedor.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Producto producto)) return false;
            return Producto_proveedor.Equals(producto.Producto_proveedor);
        }

        public override int GetHashCode()
        {
            return Producto_proveedor.GetHashCode();
        }
    }
}
