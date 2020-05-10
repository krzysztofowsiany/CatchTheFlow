using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartWorkView.Application.CommandHandlers;
using StartWorkView.Application.Commands;

namespace StartWorkView.Tests.state_change
{
    public sealed class start_work_view_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartWorkCommandHandler>()
                .As<ICommandHandler<StartWorkCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}