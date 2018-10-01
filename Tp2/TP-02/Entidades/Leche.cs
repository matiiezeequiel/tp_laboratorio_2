using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        private ETipo tipo;

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {
            this.tipo = ETipo.Entera;
        }

        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            : base(patente, marca, color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Publica todos los datos del Producto leche.
        /// </summary>
        /// <returns> retorna los datos del producto </returns>
        public override string Mostrar()
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendLine("LECHE");
            datosProducto.AppendLine(base.Mostrar());
            datosProducto.AppendLine("CALORIAS : " + this.CantidadCalorias);
            datosProducto.AppendLine("TIPO: " + this.tipo);
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }

        public enum ETipo
        {
            Entera, Descremada
        }
    }
}
