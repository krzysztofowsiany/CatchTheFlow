using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartWorkView.Application.CommandHandlers;
using StartWorkView.Application.Commands;
using Module = Autofac.Module;

namespace StartWorkView.Infrastructure
{
    public sealed class StartWorkViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StartWorkViewEventListener>()
                .AutoActivate();

           builder.RegisterType<StartWorkCommandHandler>()
                .As<ICommandHandler<StartWorkCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}