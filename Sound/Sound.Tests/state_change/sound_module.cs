using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using EventBus;
using Sound.Application.CommandHandlers;
using Sound.Application.Commands;
using Sound.Core;
using Sound.Sound;
using Module = Autofac.Module;

namespace Sound.Tests.state_change
{
    public sealed class sound_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<StopPlayCommandHandler>()
                .As<ICommandHandler<StopPlayCommand>>();
            builder.RegisterType<StartPlayCommandHandler>()
                .As<ICommandHandler<StartPlayCommand>>();
            
            builder.RegisterType<SoundPlayerService>();
            
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .SingleInstance();
            
            builder.RegisterType<SoundPlayer>()
                .As<ISoundPlayer>()
                .SingleInstance();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}