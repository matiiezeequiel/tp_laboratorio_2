using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        public string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
            Array.Reverse(array);
            double numero = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                    numero += (double)Math.Pow(2, i);
                else if(array[i] != '0')
                    return "Valor invàlido";
            }
            return numero.ToString();
        }

        public string DecimalBinario(double numero)
        {
            string binario = "";
            if (numero > 0)
            {
                while (numero > 0)
                {
                    if (numero % 2 == 1)
                        binario = "1" + binario;
                    else
                        binario = "0" + binario;
                    numero = (int)numero / 2;
                }
                return binario;
            }
            return "Valor invàlido";
        }

        public string DecimalBinario(string strNumero)
        {
            double numero;
            bool resultado = Double.TryParse(strNumero, out numero);
            if (resultado)
                return DecimalBinario(numero);
            return "Valor invàlido";
        }

        public Numero()
        {
            this.SetNumero = "0";
        }

        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero != 0)
                return n1.numero / n2.numero;
            return double.MinValue;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numero;
            bool resultado = Double.TryParse(strNumero, out numero);
            if (resultado)
                return numero;
            return 0;
        }
    }
}