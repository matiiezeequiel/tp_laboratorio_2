using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor profesor;

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        public Profesor Profesor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor profesor)
            : this()
        {
            this.Clase = clase;
            this.profesor = profesor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Lee el archivo jornada.txt
        /// </summary>
        /// <returns> Retona un string con los que contiene Jornada.txt </returns>
        public static string Leer()
        {
            Texto texto = new Texto();
            string datos;

            texto.Leer("./Jornada.txt",out datos);
 
            return datos;
        }

        /// <summary>
        /// Guarda los datos de una jornada en el archivo Jornada.txt
        /// </summary>
        /// <param name="jornada"> Jornada la cual se quiere guardar </param>
        /// <returns> Retorna un bool dependiendo si se pudo guardar o no </returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            return texto.Guardar("./Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Devuelve todos los datos de una jornada, casteando el objeto a string
        /// </summary>
        /// <returns> Retorna los datos en un string </returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("Clase: " + this.Clase);
            datos.AppendLine(this.Profesor.ToString());
            foreach (Alumno alumno in this.Alumnos)
                datos.AppendLine(alumno.ToString());

            return datos.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator !=(Jornada jornada, Alumno alumno)
        {
            foreach (Alumno alumnos in jornada.Alumnos)
            {
                if (alumnos == alumno)
                    return false;
            }
            return true;
        }

        public static bool operator ==(Jornada jornada, Alumno alumno)
        {
            return !(jornada != alumno);
        }

        public static Jornada operator +(Jornada jornada, Alumno alumno)
        {
            if (jornada != alumno)
                jornada.Alumnos.Add(alumno);
            return jornada;
        }
        #endregion
    }
}
