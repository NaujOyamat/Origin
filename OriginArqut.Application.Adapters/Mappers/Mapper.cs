using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Mappers
{
    /// <summary>
    /// Implementación de un mapeador de adaptadores
    /// </summary>
    public class Mapper : IMapper
    {
        #region Fields

        /// <summary>
        /// Contenedor de adaptadores
        /// </summary>
        private readonly ConcurrentDictionary<long, Delegate> _adapters;

        #endregion

        #region Properties
        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        public Mapper()
        {
            this._adapters = new ConcurrentDictionary<long, Delegate>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IMapper.CleanAdapters"/>
        /// </summary>
        public void CleanAdapters()
        {
            this._adapters.Clear();
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TSource, TTarget}(Func{TSource, TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TSource, TTarget>(Func<TSource, TTarget> expression)
            where TSource : class, new()
            where TTarget : class, new()
        {
            this._adapters.AddOrUpdate(new ObjectRegister(typeof(TSource), typeof(TTarget)).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(Type, Type, Func{object, object})"/>
        /// </summary>
        public void RegisterAdapter(Type tSource, Type tTarget, Func<object, object> expression)
        {
            this._adapters.AddOrUpdate(new ObjectRegister(tSource, tTarget).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TTarget}(Func{dynamic[], TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TTarget>(Func<dynamic[], TTarget> expression) where TTarget : class, new()
        {
            this._adapters.AddOrUpdate(new ObjectRegister(typeof(TTarget)).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(Type, Func{dynamic[], dynamic})"/>
        /// </summary>
        public void RegisterAdapter(Type tTarget, Func<dynamic[], dynamic> expression)
        {
            this._adapters.AddOrUpdate(new ObjectRegister(tTarget).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TTarget}(string, Func{dynamic[], TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TTarget>(string name, Func<dynamic[], TTarget> expression) where TTarget : class, new()
        {
            this._adapters.AddOrUpdate(new ObjectRegister(name, typeof(TTarget)).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(string, Type, Func{dynamic[], dynamic})"/>
        /// </summary>
        public void RegisterAdapter(string name, Type tTarget, Func<dynamic[], dynamic> expression)
        {
            this._adapters.AddOrUpdate(new ObjectRegister(name, tTarget).GetUniqueId(), expression, (or, ex) => expression);
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TSource, TTarget}"/>
        /// </summary>
        public Func<TSource, TTarget> ResolveAdapter<TSource, TTarget>()
        {
            this._adapters.TryGetValue(new ObjectRegister(typeof(TSource), typeof(TTarget)).GetUniqueId(), out Delegate ex);
            return (Func<TSource, TTarget>)ex;
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(Type, Type)"/>
        /// </summary>
        public Func<dynamic, dynamic> ResolveAdapter(Type tSource, Type tTarget)
        {
            this._adapters.TryGetValue(new ObjectRegister(tSource, tTarget).GetUniqueId(), out Delegate ex);
            return (Func<dynamic, dynamic>)ex;
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TTarget}"/>
        /// </summary>
        public Func<dynamic[], TTarget> ResolveAdapter<TTarget>()
        {
            this._adapters.TryGetValue(new ObjectRegister(typeof(TTarget)).GetUniqueId(), out Delegate ex);
            return (Func<dynamic[], TTarget>)ex;
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(Type)"/>
        /// </summary>
        public Func<dynamic[], dynamic> ResolveAdapter(Type tTarget)
        {
            this._adapters.TryGetValue(new ObjectRegister(tTarget).GetUniqueId(), out Delegate ex);
            return (Func<dynamic[], dynamic>)ex;
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TTarget}(string)"/>
        /// </summary>
        public Func<dynamic[], TTarget> ResolveAdapter<TTarget>(string name)
        {
            this._adapters.TryGetValue(new ObjectRegister(name, typeof(TTarget)).GetUniqueId(), out Delegate ex);
            return (Func<dynamic[], TTarget>)ex;
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(string, Type)"/>
        /// </summary>
        public Func<dynamic[], dynamic> ResolveAdapter(string name, Type tTarget)
        {
            this._adapters.TryGetValue(new ObjectRegister(name, tTarget).GetUniqueId(), out Delegate ex);
            return (Func<dynamic[], dynamic>)ex;
        }

        #endregion
    }
}
