using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        #region "Enumerado"
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }
        #endregion

        #region "Atributos"
        private List<Producto> productos;
        private int espacioDisponible;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor encargado de inicializar lista de productos
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }
        /// <summary>
        /// Constructor para objetos de TIPO Changuito
        /// </summary>
        /// <param name="espacioDisponible">Espacio disponible en el Chanquito con el que se iniciará la instancia</param>
        public Changuito(int espacioDisponible)
            :this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>(string) Datos del elemento y detalle de su lista</returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto producto in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if (producto is Snacks)
                        {
                            sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    case ETipo.Dulce:
                        if (producto is Dulce)
                        {
                            sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    case ETipo.Leche:
                        if (producto is Leche)
                        {
                            sb.AppendLine(producto.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(producto.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>
        /// (Changuito) Elemento, con el producto agregado a la lista, en caso de que el producto no se encuentre en la misma.
        /// (Changuito) Mismo elemento, sin modificar la lista, en caso de que el producto se encuentre en la misma.
        /// </returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            if (c.productos.Count < c.espacioDisponible)
            {
                foreach (Producto producto in c.productos)
                {
                    if (producto == p)
                        return c;
                }
                c.productos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>
        /// (Changuito) Elemento, menos el producto solicitado, en caso de que el producto se encuentre cargado.
        /// (Changuito) Mismo elemento, sin modificar la lista, en caso de que el producto no se encuentre cargado.
        /// </returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            if (c.productos.Count > 0)
            {
                foreach (Producto producto in c.productos)
                {
                    if (producto == p)
                    {
                        c.productos.Remove(p);
                        break;
                    }
                }
            }
            return c;
        }
        #endregion
    }
}
