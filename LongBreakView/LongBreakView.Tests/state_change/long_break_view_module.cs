using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using LongBreakView.Application.CommandHandlers;
using LongBreakView.Application.Commands;
using Module = Autofac.Module;

namespace LongBreakView.Tests.state_change
{
    public sealed class long_break_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<InterruptLongBreakCommandHandler>()
                .As<ICommandHandler<InterruptLongBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}