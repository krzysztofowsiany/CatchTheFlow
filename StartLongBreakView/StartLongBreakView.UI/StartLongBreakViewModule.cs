using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartLongBreakView.Application.CommandHandlers;
using StartLongBreakView.Application.Commands;
using StartLongBreakView.Application.Query;
using StartLongBreakView.Application.QueryHandlers;
using StartLongBreakView.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace StartLongBreakView.UI
{
    public sealed class StartLongBreakViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartLongBreakCommandHandler>()
                .As<ICommandHandler<StartLongBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<UserLongBreakTimeQueryHandler>()
                .As<IQueryHandler<UserLongBreakTimeQuery, LongBreakTimeView>>();

            builder.RegisterType<StartLongBreakDialog>();
        }
    }
}