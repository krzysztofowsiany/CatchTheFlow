using Autofac;
using CQRSLib;
using Sound.Application.CommandHandlers;
using Sound.Application.Commands;
using Sound.Infrastructure;
using Module = Autofac.Module;

namespace Sound
{
    public sealed class SoundModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EventListener>().AutoActivate();
            builder.RegisterType<HandlerStopPlay>().As<ICommandHandler<StopPlay>>();
        }
    }
}