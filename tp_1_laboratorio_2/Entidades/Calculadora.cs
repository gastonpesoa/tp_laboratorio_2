using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador ingresado sea +,-,* o /, caso contrario retorna +
        /// </summary>
        /// <param name="operador">Operador a comprobar</param>
        /// <returns>Operador ingresado, en caso de error operador suma</returns>
        private static string ValidarOperador(string operador)
        {
            string returnOperador = operador;

            if ((operador != "+") && (operador != "-") && (operador != "*") && (operador != "/"))
            {
                returnOperador = "+";
            }
            return returnOperador;
        }

        /// <summary>
        /// Valida y realiza la operacion indicada entre los operandos pasados como parametro
        /// </summary>
        /// <param name="num1">Primer operando de tipo Numero a ser operado</param>
        /// <param name="num2">Segundo operando de tipo Numero a ser operado</param>
        /// <param name="operador">Operador indica el calculo a ser realizado</param>
        /// <returns>Resultado de la operacion si ok</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValidado = Calculadora.ValidarOperador(operador);
            double resultado = 0;

            switch (operadorValidado)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
