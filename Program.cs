using PuigDesktop.modelos;
using PuigDesktop.modelos.finances;
using PuigDesktop.modelos.operation;
using PuigDesktop.modelos.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuigDesktop
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Empleado empleado = new Empleado("Kevin",
                                             "Francisco",
                                             "González",
                                             "FAGK030518TU1",
                                             "9621859698",
                                             DateTime.Parse("2003-05-18"),
                                             DateTime.Now,
                                             "CURP",
                                             Empleado.Puestos.GERENTE,
                                             new Tarjeta { 
                                                 Banco = "BANAMEX", 
                                                 Numero = "0000 0000 0000 0001" });

            Sucursal sucursal = new Sucursal("LomasSayula",
                                             new Direccion { Calle_principal = "And Masajeo" },
                                             new TimeSpan(9, 0, 0),
                                             new TimeSpan(17, 0, 0));

            ArticuloMenu pollo = new ArticuloMenu("PLLO1", "Pollo Entero", 255f, Articulo.Categorias.PLATILLO);

            Venta venta = new Venta(sucursal, empleado);
            venta.AgregarArticulo(pollo, 10);
            venta.AgregarArticulo(pollo, 20);

            Console.WriteLine(venta.Monto_total);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
