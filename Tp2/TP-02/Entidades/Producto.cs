using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        private EMarca marca;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias
        {
            get;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns> retorna los datos del producto </returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        public static explicit operator string(Producto producto)
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendFormat("CODIGO DE BARRAS: {0}\r\n", producto.codigoDeBarras);
            datosProducto.AppendFormat("MARCA          : {0}\r\n", producto.marca.ToString());
            datosProducto.AppendFormat("COLOR EMPAQUE  : {0}\r\n", producto.colorPrimarioEmpaque.ToString());
            datosProducto.AppendLine("---------------------");

            return datosProducto.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            if (v1.codigoDeBarras == v2.codigoDeBarras)
                return true;
            return false;
        }

        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto producto1, Producto producto2)
        {
            return !(producto1.codigoDeBarras == producto2.codigoDeBarras);
        }

        public Producto(string patente, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = patente;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        public enum EMarca
        {
            Serenisima,
            Campagnola,
            Arcor,
            Ilolay,
            Sancor,
            Pepsico
        }
    }
}
