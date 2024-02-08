using JetBrains.Annotations;
using PuigDesktop.modelos.operation;
using PuigDesktop.modelos.utils;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PuigDesktop.modelos.finances
{
    [Serializable]
    public class Venta
    {
        [JsonPropertyName("_id")] public string Id { get; set; }
        [NotNull] [JsonPropertyName("detalle")] public HashSet<Detalle> Detalles { get; set; } = new HashSet<Detalle>();
        [NotNull] public float Monto_total { get; set; }
        [NotNull] public FormasEntrega Forma_entrega { get; set; } = FormasEntrega.MOSTRADOR;
        [NotNull] public Sucursal Realizada_en { get; set; }
        [NotNull] public Empleado Asignada_a { get; set; }
        [NotNull] public DateTime Fecha_venta { get; set; } = DateTime.Now;
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        [NotNull] public bool Internet { get; set; } = false;

        public enum FormasEntrega
        {
            MOSTRADOR,
            REPARTO,
            PARA_LLEVAR
        }

        [JsonConstructor] public Venta() { }

        public Venta(Sucursal realizada_en, Empleado asignada_a, string id = null) 
        {
            Id = id;
            Realizada_en = realizada_en;
            Asignada_a = asignada_a;
        }

        public void AgregarArticulo(Articulo articulo, int cantidad)
        {
            Detalle detalle = new Detalle(articulo, cantidad);
            if (!Detalles.Add(detalle))
            {
                Detalles.TryGetValue(detalle, out Detalle detalleEnLista);

                Monto_total -= detalleEnLista.Subtotal;
                Detalles.Add(detalle);
            }
            Monto_total += detalle.Subtotal;
        }

        public bool EliminarArticulo(Articulo articulo)
        {
            var detalle = Detalle.Of(articulo);
            if (!Detalles.Remove(detalle)) return false;
            Monto_total -= detalle.Subtotal;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Venta venta)) return false;
            if (Id is null) return false;
            return Id.Equals(venta.Id);
        }

        public override int GetHashCode()
        {
            if (Id == null) return 0;
            return Id.GetHashCode();
        }

        [Serializable]
        public class Detalle
        {
            [NotNull] public Articulo Articulo { get; set; }
            [NotNull] public int Cantidad { get; set; }
            [NotNull] public float Subtotal { get; set; }

            public Detalle(Articulo articulo, int cantidad)
            {
                Articulo = articulo;
                Cantidad = cantidad;
                Subtotal = articulo.Precio * Cantidad;
            }

            internal static Detalle Of(Articulo articulo)
            {
                return new Detalle(articulo, 0);
            }

            public override string ToString()
            {
                return Articulo.ToString();
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Detalle detalle)) return false;
                return Articulo.Equals(detalle.Articulo);
            }

            public override int GetHashCode()
            {
                return Articulo.GetHashCode();
            }
        }

        [Serializable]
        public class Pago
        {
            [NotNull] [JsonPropertyName("pago")] public float Monto { get; set; }
            [NotNull] [JsonPropertyName("modo")] public Modo Forma_pago { get; set; }

            public enum Modo
            {
                EFECTIVO,
                DEBITO,
                CREDITO
            }

            public Pago(float monto_pago,
                        Modo forma_pago = Modo.EFECTIVO)
            {
                Monto = monto_pago;
                Forma_pago = forma_pago;
            }

            public override string ToString()
            {
                return $"{Forma_pago} ${Monto}";
            }
        }

        [Serializable]
        public class Reparto : Venta
        {
            [NotNull] public Direccion Direccion { get; set; }
            [NotNull] public float Costo { get; set; }
            [NotNull] public string Nombre_cliente { get; set; }
            [NotNull] public string Telefono_cliente { get; set; }

            [JsonConstructor] public Reparto() { }

            public Reparto(Sucursal realizada_en,
                           Empleado asignada_a,
                           Direccion direccion,
                           string nombre_cliente,
                           float costo,
                           string telefono_cliente,
                           string id = null) : base(realizada_en, asignada_a, id)
            {
                Direccion = direccion;
                Costo = costo;
                Nombre_cliente = nombre_cliente;
                Telefono_cliente = telefono_cliente;
            }
        }
    }
}
