using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroLongBreake.Application.CommandHandlers;
using PomodoroLongBreake.Application.Commands;

namespace PomodoroLongBreake.Infrastructure
{
    public sealed class PomodoroLongBreakeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PomodoroLongBreakeEventListener>()
                .AutoActivate();

            builder.RegisterType<StopLongBreakeCommandHandler>()
                .As<ICommandHandler<StopLongBreakeCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}