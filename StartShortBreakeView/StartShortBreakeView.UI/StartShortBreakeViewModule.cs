using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartLongBreakeView.Application.CommandHandlers;
using StartLongBreakeView.Application.Commands;
using StartLongBreakeView.Application.Query;
using StartLongBreakeView.Application.QueryHandlers;
using StartLongBreakeView.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace StartLongBreakeView.UI
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