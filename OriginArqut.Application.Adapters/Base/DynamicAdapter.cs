using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Base
{
    /// <summary>
    /// Implementación base de un adaptador dinámico
    /// </summary>
    public abstract class DynamicAdapter : IDynamicAdapter
    {
        /// <summary>
        /// <see cref="IDynamicAdapter.Adapt(object, IObjectModel)"/>
        /// </summary>
        public virtual dynamic Adapt(object source, IObjectModel model = null)
        {
            return Adapt(new[] { source }, model);
        }

        /// <summary>
        /// <see cref="IDynamicAdapter.Adapt(object[], IObjectModel)"/>
        /// </summary>
        public virtual dynamic Adapt(object[] sources, IObjectModel model = null)
        {
            dynamic oTarget = new ExpandoObject();
            if (model != null && model.Properties.Count > 0)
                model.Properties.ToList().ForEach(p => (oTarget as IDictionary<string, object>).Add(p, null));

            if (sources == null || sources.Length == 0)
                return oTarget;

            foreach (object oSource in sources)
            {
                if (model != null && model.Properties.Count > 0)
                {
                    foreach (string pTarget in model.Properties)
                    {
                        PropertyInfo pSource = oSource.GetType().GetProperty(pTarget);
                        if (pSource != null && pSource.CanRead && pSource.GetGetMethod() != null)
                        {
                            var vSource = pSource.GetValue(oSource);
                            (oTarget as IDictionary<string, object>)[pTarget] = vSource;
                        }
                    }
                }
                else
                {
                    foreach (PropertyInfo pSource in oSource.GetType().GetProperties().Where(p => p.CanRead && p.GetGetMethod() != null).ToList())
                    {
                        var vSource = pSource.GetValue(oSource);
                        if ((oTarget as IDictionary<string, object>).Keys.Contains(pSource.Name))
                            (oTarget as IDictionary<string, object>)[pSource.Name] = vSource;
                        else
                            (oTarget as IDictionary<string, object>).Add(pSource.Name, vSource);
                    }
                }
            }

            return oTarget;
        }
    }
}
