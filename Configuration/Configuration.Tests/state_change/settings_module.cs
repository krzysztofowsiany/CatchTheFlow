using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using Configuration.Application.CommandHandlers;
using Configuration.Application.Commands;

namespace Configuration.Tests.state_change
{
    public sealed class settings_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SaveSettingsCommandHandler>()
                .As<ICommandHandler<SaveSettingsCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}