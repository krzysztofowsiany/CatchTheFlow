using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroWork.Application.CommandHandlers;
using PomodoroWork.Application.Commands;
using PomodoroWork.Infrastructure;

namespace PomodoroWork
{
    public sealed class PomodoroWorkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PomodoroWorkEventListener>()
                .AutoActivate();

            builder.RegisterType<StopWorkCommandHandler>()
                .As<ICommandHandler<StopWorkCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}