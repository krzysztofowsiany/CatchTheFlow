using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroLongBreak.Application.CommandHandlers;
using PomodoroLongBreak.Application.Commands;

namespace PomodoroLongBreak.Tests.state_change
{
    public sealed class pomodoro_long_break_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StopLongBreakCommandHandler>()
                .As<ICommandHandler<StopLongBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}