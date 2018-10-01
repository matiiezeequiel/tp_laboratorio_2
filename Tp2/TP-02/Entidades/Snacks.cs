using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        public Snacks(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
        }

        /// <summary>
        /// Publica todos los datos del Producto snack.
        /// </summary>
        /// <returns> retorna los datos del producto </returns>
        public override string Mostrar()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine("SNACKS");
            datosProducto.AppendLine(base.Mostrar());
            datosProducto.AppendLine("CALORIAS : " + this.CantidadCalorias);
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }
    }
}
