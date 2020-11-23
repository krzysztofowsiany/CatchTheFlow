using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartLongBreakView.Application.CommandHandlers;
using StartLongBreakView.Application.Commands;

namespace StartLongBreakView.Tests.state_change
{
    public sealed class start_long_break_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartLongBreakCommandHandler>()
                .As<ICommandHandler<StartLongBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}