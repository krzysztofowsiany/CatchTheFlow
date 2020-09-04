using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using Configuration.Application.CommandHandlers;
using Configuration.Application.Commands;
using Configuration.Application.Query;
using Configuration.Application.QueryHandlers;
using Configuration.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace Configuration.UI
{
    public sealed class SettingsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SaveTimeSettingsCommandHandler>()
                .As<ICommandHandler<SaveTimeSettingsCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<ConfiguraitonTimesQueryHandler>()
                .As<IQueryHandler<ConfiguraitonTimesQuery, TimeConfigurationView>>();

            builder.RegisterType<ConfigurePomodoroTimesDialog>();
        }
    }
}