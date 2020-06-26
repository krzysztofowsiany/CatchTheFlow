using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartShortBreakeView.Application.CommandHandlers;
using StartShortBreakeView.Application.Commands;

namespace StartShortBreakeView.Tests.state_change
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