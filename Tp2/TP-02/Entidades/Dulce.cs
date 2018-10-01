using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        public Dulce(EMarca marca, string patente, ConsoleColor color) 
            : base(patente, marca, color)
        {
        }

        /// <summary>
        /// Publica todos los datos del Producto dulce.
        /// </summary>
        /// <returns> retorna los datos del producto </returns>
        public override string Mostrar()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine("DULCE");
            datosProducto.AppendLine(base.Mostrar());
            datosProducto.AppendLine("CALORIAS : " + this.CantidadCalorias);
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }
    }
}
