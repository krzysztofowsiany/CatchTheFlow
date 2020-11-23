using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartLongBreakView.Application.CommandHandlers;
using StartLongBreakView.Application.Commands;

namespace StartLongBreakView.Tests.state_change
{
    public sealed class start_short_break_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartShortBreakCommandHandler>()
                .As<ICommandHandler<StartShortBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}