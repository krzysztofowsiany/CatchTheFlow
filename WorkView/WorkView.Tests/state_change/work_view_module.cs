using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using WorkView.Application.CommandHandlers;
using WorkView.Application.Commands;

namespace WorkView.Tests.state_change
{
    public sealed class work_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<InterruptWorkCommandHandler>()
                .As<ICommandHandler<InterruptWorkCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}