using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroShortBreak.Application.CommandHandlers;
using PomodoroShortBreak.Application.Commands;

namespace PomodoroShortBreak.Tests.state_change
{
    public sealed class pomodoro_short_break_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StopShortBreakCommandHandler>()
                .As<ICommandHandler<StopShortBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}