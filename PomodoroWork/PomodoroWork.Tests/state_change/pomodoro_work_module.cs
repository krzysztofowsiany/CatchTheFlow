using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroWork.Application.CommandHandlers;
using PomodoroWork.Application.Commands;

namespace PomodoroWork.Tests.state_change
{
    public sealed class pomodoro_work_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StopWorkCommandHandler>()
                .As<ICommandHandler<StopWorkCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}