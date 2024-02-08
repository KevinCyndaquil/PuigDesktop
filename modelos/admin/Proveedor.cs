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
    public class Proveedor
    {
        [JsonPropertyName("_id")] public string Id { get; set; }
        [NotNull] public string Nombre { get; set; }  
        public string Telefono_fijo { get; set; }
        public string Telefono_movil { get; set; }
        [NotNull] public string Rfc { get; set; }
        public string Correo { get; set; }
        public Direccion Ubicacion { get; set; }
        [NotNull] public RazonesSociales Razon { get; set; }
        public HashSet<Tarjeta> Cuentas { get; set; }
        
        public enum RazonesSociales
        {
            FISICO,
            MORAL,
        }

        public Proveedor(string nombre,
                         string telefono_fijo,
                         string telefono_movil,
                         string rfc,
                         string correo,
                         Direccion ubicacion,
                         RazonesSociales razon,
                         HashSet<Tarjeta> cuentas,
                         string id = null)
        {
            Id = id;
            Nombre = nombre;
            Telefono_fijo = telefono_fijo;
            Telefono_movil = telefono_movil;
            Rfc = rfc;
            Correo = correo;
            Ubicacion = ubicacion;
            Razon = razon;
            Cuentas = cuentas;
        }

        public override string ToString()
        {
            return Nombre;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Proveedor proveedor)) return false;
            if (Id is null) return Nombre.Equals(proveedor.Nombre);
            return Id.Equals(proveedor.Id);
        }

        public override int GetHashCode()
        {
            if (Id == null) return Nombre.GetHashCode();
            return Id.GetHashCode();
        }

        [Serializable]
        public class Producto
        {
            [JsonPropertyName("_codigo")] public string Codigo { get; set; }
            [NotNull] public Proveedor Proveedor { get; set; }
            [NotNull] public string Nombre { get; set; }
            [NotNull] public float Precio { get; set; }
            [NotNull] public Presentacion Presentacion { get; set; }

            public Producto(Proveedor proveedor,
                            string nombre,
                            float precio,
                            Presentacion presentacion,
                            string codigo = null)
            {
                Codigo = codigo;
                Proveedor = proveedor;
                Nombre = nombre;
                Precio = precio;
                Presentacion = presentacion;
            }

            public override string ToString()
            {
                return $"#{Codigo} {Nombre} de {Proveedor.Nombre}";
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Producto producto)) return false;
                if (Codigo is null) return Nombre.Equals(producto.Nombre) && Proveedor.Equals(producto.Proveedor);
                return Codigo.Equals(producto.Codigo);
            }

            public override int GetHashCode()
            {
                if (Codigo is null)
                {
                    unchecked
                    {
                        int hash = 17; // Un número primo inicial

                        // Combina el hash con el código hash de cada propiedad
                        hash = hash * 23 + Nombre.GetHashCode();
                        hash = hash * 23 + Proveedor.GetHashCode();

                        return hash;
                    }
                }
                return Codigo.GetHashCode();
            }
        }

        [Serializable]
        public class Factura
        {
            [JsonPropertyName("_folio")][NotNull] public string Folio { get; set; }
            [NotNull] public Proveedor Proveedor { get; set; }
            [JsonPropertyName("detalle")] public HashSet<Detalle> Detalles { get; set; } = new HashSet<Detalle>();
            [NotNull] public DateTime? Recepcion { get; set; }
            [NotNull] public float Monto { get; set; }
            [NotNull] public float Iva { get; set; }
            [NotNull] public float Monto_total { get; set; }

            public Factura(string folio,
                           Proveedor proveedor,
                           HashSet<Detalle> detalles,
                           DateTime? recepcion,
                           float iva)
            {
                Folio = folio;
                Proveedor = proveedor;
                Detalles = detalles;
                Recepcion = recepcion;
                Iva = iva;

                foreach (var d in detalles)
                {
                    Monto += d.Monto;
                }

                Monto_total = Monto + Iva;
            }

            public override string ToString()
            {
                return $"#{Folio} {Proveedor.Nombre}";
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Factura factura)) return false;
                return Folio.Equals(factura.Folio);
            }

            public override int GetHashCode()
            {
                return Folio.GetHashCode();
            }

            [Serializable]
            public class Detalle
            {
                [NotNull] public Producto Producto { get; set; }
                [NotNull] public int Cantidad;
                [NotNull] public float Monto;

                public Detalle(Producto producto,
                               int cantidad)
                {
                    Producto = producto;
                    Cantidad = cantidad;
                    Monto = Producto.Precio * Cantidad;
                }
            }
        }
    }
}
