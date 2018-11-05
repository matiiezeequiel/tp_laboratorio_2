using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region constructores
        public Universitario()
            : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Devuelve todos los datos del universitario
        /// </summary>
        /// <returns> retorna un string con todos los datos del universitario </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Legajo: " + this.legajo);
            datos.Append(base.ToString());

            return datos.ToString();
        }

        /// <summary>
        /// Devuelve la clase en la que participa el universitario
        /// </summary>
        /// <returns> retorna un string de la clase en la que participa </returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Valida que los dos objetos sean del mismo tipo
        /// </summary>
        /// <param name="obj"> object </param>
        /// <returns> true si son del mismo tipo y no son null, false caso contrario </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            return true;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI) && pg1.Equals(pg2))
                return true;
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
