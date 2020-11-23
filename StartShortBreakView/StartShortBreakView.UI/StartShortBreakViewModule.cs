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
    public sealed class StartShortBreakViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<StartShortBreakCommandHandler>()
                .As<ICommandHandler<StartShortBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<UserShortBreakTimeQueryHandler>()
                .As<IQueryHandler<UserShortBreakTimeQuery, ShortBreakTimeView>>();

            builder.RegisterType<StartShortBreakDialog>();
        }
    }
}