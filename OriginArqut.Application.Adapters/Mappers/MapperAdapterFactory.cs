using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OriginArqut.Application.Adapters.Mappers
{
    /// <summary>
    /// Encapsula la única instancia al contenedor de adaptadores
    /// de toda la arquitectura
    /// </summary>
    public partial class MapperAdapterFactory
    {
        #region Singleton

        /// <summary>
        /// Única instancia a la clase
        /// </summary>
        private static MapperAdapterFactory _instance;

        /// <summary>
        /// Obtiene la única instancia a la clase
        /// </summary>
        public static MapperAdapterFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapperAdapterFactory();
                }
                return _instance;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// Instancia al mapeador de adaptadores
        /// </summary>
        private readonly IMapper _mapper;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene la instancia al mapeador de adaptadores
        /// </summary>
        public IMapper Mapper
        {
            get
            {
                return this._mapper;
            }
        }

        #endregion

        #region Builders

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// </summary>
        private MapperAdapterFactory()
        {
            this._mapper = new Mapper();
            this.RegisterAdapters(this._mapper);
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IMapper.CleanAdapters"/>
        /// </summary>
        public void CleanAdapters()
        {
            this._mapper.CleanAdapters();
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TSource, TTarget}(Func{TSource, TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TSource, TTarget>(Func<TSource, TTarget> expression)
            where TSource : class, new()
            where TTarget : class, new()
        {
            this._mapper.RegisterAdapter<TSource, TTarget>(expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(Type, Type, Func{object, object})"/>
        /// </summary>
        public void RegisterAdapter(Type tSource, Type tTarget, Func<object, object> expression)
        {
            this._mapper.RegisterAdapter(tSource, tTarget, expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TTarget}(Func{dynamic[], TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TTarget>(Func<dynamic[], TTarget> expression) where TTarget : class, new()
        {
            this._mapper.RegisterAdapter<TTarget>(expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(Type, Func{dynamic[], dynamic})"/>
        /// </summary>
        public void RegisterAdapter(Type tTarget, Func<dynamic[], dynamic> expression)
        {
            this._mapper.RegisterAdapter(tTarget, expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter{TTarget}(string, Func{dynamic[], TTarget})"/>
        /// </summary>
        public void RegisterAdapter<TTarget>(string name, Func<dynamic[], TTarget> expression) where TTarget : class, new()
        {
            this._mapper.RegisterAdapter<TTarget>(name, expression);
        }

        /// <summary>
        /// <see cref="IMapper.RegisterAdapter(string, Type, Func{dynamic[], dynamic})"/>
        /// </summary>
        public void RegisterAdapter(string name, Type tTarget, Func<dynamic[], dynamic> expression)
        {
            this._mapper.RegisterAdapter(name, tTarget, expression);
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TSource, TTarget}"/>
        /// </summary>
        public Func<TSource, TTarget> ResolveAdapter<TSource, TTarget>()
        {
            return this._mapper.ResolveAdapter<TSource, TTarget>();
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(Type, Type)"/>
        /// </summary>
        public Func<dynamic, dynamic> ResolveAdapter(Type tSource, Type tTarget)
        {
            return this._mapper.ResolveAdapter(tSource, tTarget);
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TTarget}"/>
        /// </summary>
        public Func<dynamic[], TTarget> ResolveAdapter<TTarget>()
        {
            return this._mapper.ResolveAdapter<TTarget>();
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(Type)"/>
        /// </summary>
        public Func<dynamic[], dynamic> ResolveAdapter(Type tTarget)
        {
            return this._mapper.ResolveAdapter(tTarget);
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter{TTarget}(string)"/>
        /// </summary>
        public Func<dynamic[], TTarget> ResolveAdapter<TTarget>(string name)
        {
            return this._mapper.ResolveAdapter<TTarget>(name);
        }

        /// <summary>
        /// <see cref="IMapper.ResolveAdapter(string, Type)"/>
        /// </summary>
        public Func<dynamic[], dynamic> ResolveAdapter(string name, Type tTarget)
        {
            return this._mapper.ResolveAdapter(name, tTarget);
        }

        #endregion
    }
}
