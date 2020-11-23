using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroLongBreak.Application.CommandHandlers;
using PomodoroLongBreak.Application.Commands;

namespace PomodoroLongBreak.Infrastructure
{
    public sealed class PomodoroLongBreakModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PomodoroLongBreakEventListener>()
                .AutoActivate();

            builder.RegisterType<StopLongBreakCommandHandler>()
                .As<ICommandHandler<StopLongBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}