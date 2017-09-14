using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Mappers
{
    /// <summary>
    /// Encapsula los objetos que se registran como tipo para un adaptador
    /// </summary>
    internal class ObjectRegister
    {
        #region Consts

        /// <summary>
        /// Arreglo de tokens usado para obtener un número de indice
        /// </summary>
        private const string TOKENS = " abcdefghijklmnñopqrstuvwxyz0123456789.,:;_-+/*!#$%&()=?¡¿¨´~[]{}^`<>|¬°";

        #endregion

        #region Fields

        /// <summary>
        /// Nombre del objeto registrador
        /// </summary>
        private string _name;

        /// <summary>
        /// Arreglo de tipos que componen el registro
        /// </summary>
        private Type[] _types;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el nombre del objeto registrador
        /// </summary>
        public string Name { get => _name; }

        /// <summary>
        /// Obtiene el arreglo de tipos que componen el registro
        /// </summary>
        public Type[] Types { get => _types; }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="types">Arreglo de tipos que componen el registro</param>
        public ObjectRegister(params Type[] types) : this(types.GetUniqueName(), types) { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        /// <param name="name">Nombre del objeto registrador</param>
        /// <param name="types">Arreglo de tipos que componen el registro</param>
        public ObjectRegister(string name, params Type[] types)
        {
            this._name = name;
            this._types = types;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Obtiene el número de identificación único, el cual depende
        /// de los tipos que componen el registro sin importar su orden
        /// </summary>
        /// <returns>Identificación única</returns>
        public long GetUniqueId()
        {
            long uniqueId = 0;
            string uniqueName = this._name.ToLower() + this._types.GetUniqueName();
            foreach (char c in uniqueName)
            {
                int idx = TOKENS.IndexOf(c);
                if (idx == -1)
                    idx = 0;
                uniqueId += idx;
            }

            return uniqueId;
        }

        #endregion
    }
}
