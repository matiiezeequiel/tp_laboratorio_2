using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

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

        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornadas[i];
            }
            set
            {
                jornadas[i] = value;
            }
        }
        #endregion

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Profesores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        #region Metodos
        /// <summary>
        /// Lee los datos de una universidad de un archivo XML (Universidad.txt)
        /// </summary>
        /// <returns>  retornará un Universidad con todos los datos previamente serializados </returns>
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> texto = new Xml<Universidad>();

            texto.Leer("./Universidad.xml", out universidad);

            return universidad;
        }

        /// <summary>
        ///  Guarda los datos del Universidad en un XML (Universidad.txt)
        /// </summary>
        /// <param name="universidad"> universidad de la cual de van a guardar los datos </param>
        /// <returns> true o false dependiendo si se guardo con exito o no </returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<string> texto = new Xml<string>();

            return texto.Guardar("./Universidad.xml", universidad.ToString());
        }

        /// <summary>
        /// Devuelve todos los datos de una universidad
        /// </summary>
        /// <param name="universidad"> Universidad de la cual se van a extraer los datos </param>
        /// <returns> Retorna los datos de dicha universidad en string </returns>
        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("---ALUMNOS---");
            foreach (Alumno alumno in universidad.Alumnos)
                datos.AppendLine(alumno.ToString());
            datos.AppendLine("---PROFESORES---");
            foreach (Profesor profesor in universidad.Profesores)
                datos.AppendLine(profesor.ToString());
            datos.AppendLine("---JORNADAS---");
            foreach (Jornada jornada in universidad.Jornadas)
                datos.AppendLine(jornada.ToString());

            return datos.ToString();
        }

        /// <summary>
        /// Devuelve todos los datos de una universidad de manera publica, casteando el objeto a string
        /// </summary>
        /// <returns> Retorna un string con los datos </returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }
        #endregion

        #region Operadores
        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            foreach(Alumno alumnos in universidad.Alumnos)
            {
                if (alumnos == alumno)
                    return false;
            }
            return true;
        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            return !(universidad != alumno);
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if (universidad != alumno)
            {
                universidad.alumnos.Add(alumno);
                return universidad;
            }
            throw new AlumnoRepetidoException();
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            foreach(Profesor profesores in universidad.Profesores)
            {
                if (profesores == profesor)
                    return false;
            }
            return true;
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            return !(universidad != profesor);
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if (universidad != profesor)
                universidad.profesores.Add(profesor);
            return universidad;
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor != clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }

        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach (Profesor profesor in universidad.profesores)
            {
                if (profesor == clase)
                    return profesor;
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Profesor profesor;
            try
            {
                profesor = universidad == clase;
            }
            catch (SinProfesorException e)
            {
                throw e;
            }
            Jornada jornada = new Jornada(clase, profesor);
            foreach (Alumno alumno in universidad.Alumnos)
            {
                if (alumno == clase)
                    jornada.Alumnos.Add(alumno);
            }
            universidad.Jornadas.Add(jornada);
            return universidad;
        }
        #endregion
    }
}
