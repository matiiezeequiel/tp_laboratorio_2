using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        public Profesor()
            : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }

        static Profesor()
        {
            random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve todos los datos del profesor
        /// </summary>
        /// <returns> retorna un string con todos los datos del profesor </returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.Append(base.MostrarDatos());
            datos.Append(this.ParticiparEnClase());

            return datos.ToString();
        }

        /// <summary>
        /// Devuelve la clase en las que participa el profesor
        /// </summary>
        /// <returns> retorna un string de las clases en las que participa -> "CLASES DEL DIA {clases}" </returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("CLASES DEL DÍA");
            foreach (Universidad.EClases clases in this.clasesDelDia)
                datos.AppendLine(clases.ToString());

            return datos.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos de un profesor de manera publica, casteando el objeto a string
        /// </summary>
        /// <returns> Retorna un string con los datos </returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Agrega una EClase a la cola "clasesDelDia" del profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
        }
        #endregion

        #region Operadores
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            foreach(Universidad.EClases clases in profesor.clasesDelDia)
            {
                if (clases == clase)
                    return false;
            }
            return true;
        }

        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor != clase);
        }
        #endregion
    }
}
