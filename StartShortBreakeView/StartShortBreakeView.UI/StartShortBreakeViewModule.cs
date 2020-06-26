using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartShortBreakeView.Application.CommandHandlers;
using StartShortBreakeView.Application.Commands;
using StartShortBreakeView.Application.Query;
using StartShortBreakeView.Application.QueryHandlers;
using StartShortBreakeView.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace StartShortBreakeView.UI
{
    public sealed class StartShortBreakeViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<StartShortBreakeCommandHandler>()
                .As<ICommandHandler<StartShortBreakeCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<UserShortBreakeTimeQueryHandler>()
                .As<IQueryHandler<UserShortBreakeTimeQuery, ShortBreakeTimeView>>();

            builder.RegisterType<StartShortBreakeDialog>();
        }
    }
}