using OriginArqut.Application.Adapters.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Adapters
{
    /// <summary>
    /// Implementación de un adaptador estático
    /// </summary>
    public class StaAdapter : Adapter
    {
    }

    /// <summary>
    /// Implementación de un adaptador estático genérico
    /// </summary>
    /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
    public class StaAdapter<TTarget> : Adapter<TTarget> where TTarget : class, new()
    {
    }
}
