using Autofac;

namespace CQRSLib
{
    public class QueryBus : IQueryBus
    {
        private ILifetimeScope _container;

        public QueryBus(ILifetimeScope container)
        {
            _container = container;
        }
        
        public TResult Process<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
            where TResult : class
        {
            var queryHandler = _container.ResolveOptional<IQueryHandler<TQuery, TResult>>();

            var result = queryHandler?.Handle(query);
            return result;
        }
    }
}