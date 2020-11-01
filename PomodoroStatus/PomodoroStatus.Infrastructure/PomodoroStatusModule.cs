using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using PomodoroStatus.Application.Query;
using PomodoroStatus.Application.QueryHandlers;
using PomodoroStatus.Application.Views;

namespace PomodoroStatus.Infrastructure
{
    public sealed class PomodoroStatusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<PomodoroStatusQueryHandler>()
                .As<IQueryHandler<PomodoroStatusQuery, PomodoroStatusView>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}