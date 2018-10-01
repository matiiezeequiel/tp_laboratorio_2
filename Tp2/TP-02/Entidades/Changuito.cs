using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        private int espacioDisponible;
        private List<Producto> productos;

        #region "Constructores"

        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        public Changuito(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }

        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito changuito, ETipo tipo)
        {
            StringBuilder datosProducto = new StringBuilder();

            datosProducto.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", changuito.productos.Count, changuito.espacioDisponible);
            datosProducto.AppendLine("");
            foreach (Producto producto in changuito.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(producto is Snacks)
                            datosProducto.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if (producto is Dulce)
                            datosProducto.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Leche:
                        if (producto is Leche)
                            datosProducto.AppendLine(producto.Mostrar());
                        break;
                    case ETipo.Todos:
                        datosProducto.AppendLine(producto.Mostrar());
                        break;
                    default:
                            datosProducto.AppendLine(producto.Mostrar());
                        break;
                }
            }

            return datosProducto.ToString();
        }

        #endregion

        #region "Operadores"

        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito changuito, Producto producto)
        {
            if (changuito.productos.Count < changuito.espacioDisponible)
            {
                foreach (Producto productoChanguito in changuito.productos)
                {
                    if (productoChanguito == producto)
                        return changuito;
                }
                changuito.productos.Add(producto);
            }
            return changuito;
        }

        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito changuito, Producto producto)
        {
            foreach (Producto productoChanguito in changuito.productos)
            {
                if (productoChanguito == producto)
                {
                    changuito.productos.Remove(productoChanguito);
                    break;
                }
            }
            return changuito;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
    }
}
