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
    public sealed class StartLongBreakeViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartLongBreakeCommandHandler>()
                .As<ICommandHandler<StartLongBreakeCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<UserLongBreakeTimeQueryHandler>()
                .As<IQueryHandler<UserLongBreakeTimeQuery, LongBreakeTimeView>>();

            builder.RegisterType<StartLongBreakeDialog>();
        }
    }
}