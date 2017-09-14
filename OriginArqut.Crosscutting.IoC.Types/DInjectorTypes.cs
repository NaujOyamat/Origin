using OriginArqut.Crosscutting.IoC.DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriginArqut.Crosscutting.IoC.Types
{
    /// <summary>
    /// Provee métodos para registrar los tipos en el contenedor
    /// </summary>
    public partial class DInjectorTypes
    {
        /// <summary>
        /// Registra los tipos en el contenedor de instancias
        /// </summary>
        /// <param name="injector">Contenedor de instancias</param>
        public static void RegisterTypes(IDInjector injector)
        {
            //Registra los tipos comunes
            RegisterCommonTypes(injector);
        }
    }
}
