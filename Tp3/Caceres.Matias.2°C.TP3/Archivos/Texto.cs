using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un objeto en un archivo txt
        /// </summary>
        /// <param name="archivo"> Ubicacion del archivo en el cual se van a guardar los datos </param>
        /// <param name="datos"> Objeto a guardar en el archivo </param>
        /// <returns> Retorna true en caso de guardar en objeto correctamente, caso contrario lanza excepcion </returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter info = new StreamWriter(archivo, true, UTF8Encoding.UTF8);
            try
            {
                info.WriteLine(datos);
                info.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            finally
            {
                info.Close();
            }
        }

        /// <summary>
        /// Lee un archivo txt y guarda los datos en un objeto
        /// </summary>
        /// <param name="archivo"> Ubicacion del archivo a leer </param>
        /// <param name="datos"> Objeto en el cual se van a almacenar los datos leidos </param>
        /// <returns> Retorna true en caso de leer el archivo correctamente, caso contrario lanza excepcion </returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader info = new StreamReader(archivo, UTF8Encoding.UTF8);
            try
            {
                datos = info.ReadToEnd();
                info.Close();
                return true;
            }
            catch (ArchivosException e)
            {
                throw e;
            }
            finally
            {
                info.Close();
            }
        }
    }
}
