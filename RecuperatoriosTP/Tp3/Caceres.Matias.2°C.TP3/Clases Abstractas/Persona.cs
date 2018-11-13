using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Propiedades
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

         #region Metodos
        /// <summary>
        /// Devuelve todos los datos de una persona
        /// </summary>
        /// <returns> retorna un string con todos los datos de la persona </returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("Nombre y apellido: {0} {1}", this.Nombre, this.Apellido).AppendLine();
            datos.AppendLine("Nacionalidad: " + this.Nacionalidad);
            datos.AppendLine("DNI: " + this.DNI);

            return datos.ToString();
        }

        /// <summary>
        /// Valida que el DNI(int) ingresado sea valido dependiendo de la zona y numero de DNI
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la persona </param>
        /// <param name="dato"> DNI de la persona </param>
        /// <returns> Devuelve el DNI si es valido, caso contrario lanza excepcion </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {            
            if (nacionalidad == ENacionalidad.Argentino)            
            {
                if (dato > 1 && dato < 89999999)
                    return dato;
            }
            else
            {
                if (dato > 90000000 && dato < 99999999)
                    return dato;
            }
            throw new NacionalidadInvalidaException();
        }

        /// <summary>
        /// Valida que el DNI(string) ingresado sea valido dependiendo de la zona, cantidad de digitos, y si contiene algun caracter incorrecto
        /// </summary>
        /// <param name="nacionalidad"> Nacionalidad de la persona </param>
        /// <param name="dato"> DNI de la persona </param>
        /// <returns> Devuelve el DNI si es valido, caso contrario lanza una excepcion </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;

            if (dato.Length > 8 || dato.Length == 0)
                throw new DniInvalidoException();
            foreach (char ch in dato)
            {
                if (!(char.IsDigit(ch)))
                    throw new DniInvalidoException();
            }
            if (!(int.TryParse(dato, out dni)))
                throw new DniInvalidoException();
            else
                return this.ValidarDni(nacionalidad, dni);
        }

        /// <summary>
        /// Valida que en nombre o apeliido de la persona ingresado sea valido
        /// </summary>
        /// <param name="dato"> nombre de la persona </param>
        /// <returns> Devuelve el nombre si es valido, caso contrario devuelve un string vacio </returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char ch in dato)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                    return "";
                }
            }
            return dato;
        }
        #endregion
    }
}