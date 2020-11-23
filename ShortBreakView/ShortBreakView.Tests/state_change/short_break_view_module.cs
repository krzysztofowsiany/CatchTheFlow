using System.Reflection;
using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using ShortBreakView.Application.CommandHandlers;
using ShortBreakView.Application.Commands;
using Module = Autofac.Module;

namespace ShortBreakView.Tests.state_change
{
    public sealed class short_break_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<InterruptShortBreakCommandHandler>()
                .As<ICommandHandler<InterruptShortBreakCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}