using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroShortBreake.Application.CommandHandlers;
using PomodoroShortBreake.Application.Commands;

namespace PomodoroShortBreake.Tests.state_change
{
    public sealed class pomodoro_short_breake_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StopShortBreakeCommandHandler>()
                .As<ICommandHandler<StopShortBreakeCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}