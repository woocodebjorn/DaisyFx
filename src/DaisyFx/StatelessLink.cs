using System;
using System.Threading.Tasks;

namespace DaisyFx
{
    public abstract class StatelessLink<TInput, TOutput> : ILink<TInput, TOutput>
    {
        private readonly InstanceContext _context;

        protected StatelessLink()
        {
            _context = InstanceFactory.Context;
        }

        protected T ReadConfiguration<T>() where T : new() => _context.ReadConfiguration<T>();

        ValueTask<TOutput> ILink<TInput, TOutput>.ExecuteAsync(TInput input, ChainContext context) => ExecuteAsync(input, context);

        protected abstract ValueTask<TOutput> ExecuteAsync(TInput input, ChainContext context);

        void IDisposable.Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose()
        {
        }
    }
}