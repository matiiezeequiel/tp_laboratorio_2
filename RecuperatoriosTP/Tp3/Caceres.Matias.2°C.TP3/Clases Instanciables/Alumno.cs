using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructores
        public Alumno()
            : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve todos los datos de un alumno
        /// </summary>
        /// <returns> Retorna un string con los datos </returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            datos.AppendLine("Estado de cuenta: " + this.estadoCuenta);

            return datos.ToString();
        }

        /// <summary>
        /// Devuelve la clase que toma un alumno
        /// </summary>
        /// <returns> devuelve un string -> "TOMA LA CLASE {clase que toma}" </returns>
        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE " + this.claseQueToma);
        }

        /// <summary>
        /// Devuelve todos los datos de un alumno de manera publica, casteando el objeto a string
        /// </summary>
        /// <returns> Retorna un string con los datos </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            if (alumno.claseQueToma != clase)
                return true;
            return false;
        }

        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            if (!(alumno != clase) && (alumno.estadoCuenta != EEstadoCuenta.Deudor))
                return true;
            return false;
        }
        #endregion
    }
}
