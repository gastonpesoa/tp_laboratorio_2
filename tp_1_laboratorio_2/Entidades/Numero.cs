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

        private string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        public Numero()
        {
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que el valor recibido sea numerico
        /// </summary>
        /// <param name="strNumero">Valor a ser comprobado</param>
        /// <returns>
        /// 0 : double - En caso de error  
        /// Valor ingresado : double - En caso Ok
        /// </returns>
        private double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double returnNumero))
            {
                returnNumero = 0;
            }
            return returnNumero;
        }

        /// <summary>
        /// Convierte binario a decimal
        /// </summary>
        /// <param name="binario">Numero binario a ser convertido</param>
        /// <returns>
        /// "Valor invalido" : string - En caso de error
        /// Numero decimal equivalente : string - En caso Ok
        /// </returns>
        public string BinarioDecimal(string binario)
        {
            double numeroDecimal = 0;

            for (int i = 0; i <= binario.Length - 1; i++)
            {
                double.TryParse(binario[i].ToString(), out double binarioParsed);
                if (binarioParsed == 1 || binarioParsed == 0)
                {
                    numeroDecimal += binarioParsed * Math.Pow(2, binario.Length - i - 1);
                }
                else
                {
                    return "Valor invalido";
                }
            }
            return numeroDecimal.ToString();
        }

        /// <summary>
        /// Convierte numero decimal de tipo double a numero binario de tipo string
        /// </summary>
        /// <param name="numero">Numero de tipo double a ser convertido</param>
        /// <returns>Numero binario de tipo string equivalente</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            long cociente = (long)numero;
            long resto = (long)numero;

            while (cociente >= 1)
            {
                resto = cociente % 2;
                cociente = cociente / 2;

                if (resto != 0)
                {
                    numeroBinario = "1" + numeroBinario;
                }
                else
                {
                    numeroBinario = "0" + numeroBinario;
                }
            }
            return numeroBinario;
        }

        /// <summary>
        /// Convierte decimal de tipo string a binario de tipo string 
        /// previo a validar que sea un valor numerico
        /// </summary>
        /// <param name="numero">Decimal de tipo string, a ser convertido</param>
        /// <returns>Numero binario de tipo string equivalente</returns>
        public string DecimalBinario(string numero)
        {
            string returnAux = "Valor invalido";

            if (double.TryParse(numero, out double cociente))
            {
                returnAux = this.DecimalBinario(cociente);
            }
            return returnAux;
        }

        /// <summary>
        /// Sobrecarga de operador suma
        /// </summary>
        /// <param name="n1">Primer operando de tipo Numero a ser sumado</param>
        /// <param name="n2">Segundo operando de tipo Numero a ser sumado</param>
        /// <returns>Resultado de tipo double de la operacion</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador menos
        /// </summary>
        /// <param name="n1">Primer operando de tipo Numero a ser sustraido</param>
        /// <param name="n2">Segundo operando de tipo Numero a ser sustraido</param>
        /// <returns>Resultado de tipo double, de la operacion</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador multiplicacion
        /// </summary>
        /// <param name="n1">Primer operando de tipo Numero a ser multiplicado</param>
        /// <param name="n2">Segundo operando de tipo Numero a ser multiplicado</param>
        /// <returns>Resultado de tipo double, de la operacion</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador division
        /// </summary>
        /// <param name="n1">Primer operando de tipo Numero a ser dividido</param>
        /// <param name="n2">Segundo operando de tipo Numero divisor</param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
    }

    
}
