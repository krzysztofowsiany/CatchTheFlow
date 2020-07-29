using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartLongBreakeView.Application.CommandHandlers;
using StartLongBreakeView.Application.Commands;

namespace StartLongBreakeView.Tests.state_change
{
    public sealed class start_short_breake_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartShortBreakeCommandHandler>()
                .As<ICommandHandler<StartShortBreakeCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}