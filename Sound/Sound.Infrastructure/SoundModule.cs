using System;
using System.Reflection;
using Autofac;
using CQRSLib;
using Sound.Infrastructure;
using Module = Autofac.Module;

namespace Sound
{
    public sealed class SoundModule : Module
    {
        private readonly Assembly _assembly;

        public SoundModule(Assembly assembly)
        {
            _assembly = assembly == null ? ThisAssembly : assembly;
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EventListener>().AutoActivate();
            
            builder.RegisterAssemblyTypes(_assembly)
                .Where(x => x.IsAssignableTo<ICommandHandler>())
                .AsImplementedInterfaces();
            
            builder.Register<Func<Type, ICommandHandler>>(context =>
                {
                    var componentContext = context.Resolve<IComponentContext>();

                    return type =>
                    {
                        var handlerType = typeof(ICommandHandler<>).MakeGenericType(type);
                        return (ICommandHandler) componentContext.Resolve(handlerType);
                    };
                }
            );
        }
    }
}