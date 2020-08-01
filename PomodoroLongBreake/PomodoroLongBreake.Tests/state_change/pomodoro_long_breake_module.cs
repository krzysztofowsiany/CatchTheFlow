using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroLongBreake.Application.CommandHandlers;
using PomodoroLongBreake.Application.Commands;

namespace PomodoroLongBreake.Tests.state_change
{
    public sealed class pomodoro_long_breake_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StopLongBreakeCommandHandler>()
                .As<ICommandHandler<StopLongBreakeCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}