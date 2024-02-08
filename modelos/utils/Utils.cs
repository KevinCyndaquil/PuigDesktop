using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PuigDesktop.modelos.utils
{
    [Serializable]
    public struct Tarjeta
    {
        [NotNull] public string Banco;
        [NotNull] public string Numero;
    }

    [Serializable]
    public struct Direccion
    {
        [NotNull] public string Calle_principal;
        [NotNull] public string Calle_1;
        public string Calle_2;
        public string Manzana;
        public string Lote;
        public string Numero_exterior;
        [NotNull] public string Numero_interior;
        public string Descripcion_vivienda;
    }

    [Serializable]
    public class Presentacion
    {
        [NotNull] public Envases Envase { get; set; }
        public int Cantidad_envase { get; set; }
        [NotNull] public float Peso_envase { get; set; }
        public Presentacion Sub_presentacion { get; set; }

        public enum Envases
        {
            PIEZA,
            BOLSA,
            CAJA,
            CUBETA,
            PESO,
        }

        public Presentacion(float peso_envase,
                            Envases envase = Envases.PESO,
                            int cantidad_envase = 1,
                            Presentacion sub_presentacion = null)
        {
            Peso_envase = peso_envase;
            Envase = envase;
            Cantidad_envase = cantidad_envase;
            Sub_presentacion = sub_presentacion;
        }

        public override string ToString()
        {
            return $"{Envase} de {Peso_envase}{((Sub_presentacion is null) ? "" : " con " + Sub_presentacion.ToString())}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Presentacion presentacion)) return false ;
            return Envase.Equals(presentacion.Envase) && Peso_envase.Equals(presentacion.Peso_envase);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; // Un número primo inicial

                // Combina el hash con el código hash de cada propiedad
                hash = hash * 23 + Envase.GetHashCode();
                hash = hash * 23 + Peso_envase.GetHashCode();

                return hash;
            }
        }
    }
}
