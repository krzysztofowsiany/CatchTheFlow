using Autofac;
using CQRSLib;
using EventBus;
using Sound.Application.CommandHandlers;
using Sound.Application.Commands;
using Sound.Core;
using Sound.Infrastructure;
using Sound.Sound;
using Module = Autofac.Module;

namespace Sound
{
    public sealed class SoundModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<EventListener>()
                .AutoActivate();
            
            builder.RegisterType<StopPlayCommandHandler>()
                .As<ICommandHandler<StopPlay>>();
            builder.RegisterType<StartPlayCommandHandler>()
                .As<ICommandHandler<StartPlay>>();
            
            builder.RegisterType<SoundPlayerService>();
            
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .SingleInstance();
            
            builder.RegisterType<SoundPlayer>()
                .As<ISoundPlayer>()
                .SingleInstance();
        }
    }
}