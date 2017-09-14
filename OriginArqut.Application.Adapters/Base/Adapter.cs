using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Implementación base de un adaptador
    /// </summary>
    public abstract class Adapter : IAdapter
    {
        #region Methods

        /// <summary>
        /// <see cref="IAdapter.Adapt(object, Type)"/>
        /// </summary>
        public virtual object Adapt(object source, Type target)
        {
            return Adapt(new[] { source }, target);
        }

        /// <summary>
        /// <see cref="IAdapter.Adapt(object[], Type)"/>
        /// </summary>
        public virtual object Adapt(object[] sources, Type target)
        {
            var oTarget = Activator.CreateInstance(target);
            if (sources == null || sources.Length == 0)
                return oTarget;

            foreach (object oSource in sources)
            {
                foreach (PropertyInfo pTarget in target.GetProperties().Where(p => p.CanWrite && p.GetSetMethod() != null).ToList())
                {
                    PropertyInfo pSource = oSource.GetType().GetProperty(pTarget.Name);
                    if(pSource != null && pSource.CanRead && pSource.GetGetMethod() != null)
                    {
                        if(pSource.PropertyType == pTarget.PropertyType)
                        {
                            var vSource = pSource.GetValue(oSource);
                            pTarget.SetValue(oTarget, vSource);
                        }
                    }
                }
            }

            return oTarget;
        }

        #endregion
    }

    /// <summary>
    /// Implementación base de un adaptador genérico
    /// </summary>
    /// <typeparam name="TTarget">Tipo del objeto destino</typeparam>
    public abstract class Adapter<TTarget> : Adapter, IAdapter<TTarget> where TTarget : class, new()
    {
        /// <summary>
        /// <see cref="IAdapter{TTarget}.Adapt(object)"/>
        /// </summary>
        public TTarget Adapt(object source)
        {
            return (TTarget)Adapt(new[] { source }, typeof(TTarget));
        }

        /// <summary>
        /// <see cref="IAdapter{TTarget}.Adapt(object[])"/>
        /// </summary>
        public TTarget Adapt(object[] sources)
        {
            return (TTarget)Adapt(sources, typeof(TTarget));
        }
    }
}
