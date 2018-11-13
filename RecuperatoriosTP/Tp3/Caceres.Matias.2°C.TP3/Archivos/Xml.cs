using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda un objeto en un archico XML
        /// </summary>
        /// <param name="archivo"> Ubicacion del archico para guardar el objeto </param>
        /// <param name="datos"> objeto a guardar </param>
        /// <returns> Retorna true en caso de poder guardar el objeto son problemas, caso contrario lanza excepcion </returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer;
            XmlSerializer serializer;

            writer = new XmlTextWriter(archivo, Encoding.UTF8);
            try
            {
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
            }
            catch(ArchivosException e)
            {
                throw e;
            }
            finally
            {
                writer.Close();
            }
            return true;
        }

        /// <summary>
        /// Lee un archivo XML, devolviendo un objeto con los datos leidos
        /// </summary>
        /// <param name="archivo"> Ubicacion del archivo a leer </param>
        /// <param name="datos"> objeto en el cual se van a guardar los datos leidos </param>
        /// <returns> Retorna true en caso de poder leer los datos correctamente, caso contrario lanza excepcion </returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader;
            XmlSerializer serializer;

            reader = new XmlTextReader(archivo);
            try
            {
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
            }
            catch(ArchivosException e)
            {
                throw e;
            }
            finally
            {
                reader.Close();
            }
            return true;
        }
    }
}
