using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroShortBreake.Application.CommandHandlers;
using PomodoroShortBreake.Application.Commands;

namespace PomodoroShortBreake.Infrastructure
{
    public sealed class PomodoroShortBreakeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PomodoroShortBreakeEventListener>()
                .AutoActivate();

            builder.RegisterType<StopShortBreakeCommandHandler>()
                .As<ICommandHandler<StopShortBreakeCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}