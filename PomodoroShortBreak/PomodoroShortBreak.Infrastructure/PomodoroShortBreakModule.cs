using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroShortBreak.Application.CommandHandlers;
using PomodoroShortBreak.Application.Commands;

namespace PomodoroShortBreak.Infrastructure
{
    public sealed class PomodoroShortBreakModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PomodoroShortBreakEventListener>()
                .AutoActivate();

            builder.RegisterType<StopShortBreakCommandHandler>()
                .As<ICommandHandler<StopShortBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}