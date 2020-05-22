using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using StartWorkView.Application.CommandHandlers;
using StartWorkView.Application.Commands;
using StartWorkView.Application.Query;
using StartWorkView.Application.QueryHandlers;
using StartWorkView.Application.Views;
using StartWorkView.UI;
using Module = Autofac.Module;

namespace StartWorkView.Infrastructure
{
    public sealed class StartWorkViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<StartWorkCommandHandler>()
                .As<ICommandHandler<StartWorkCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<UserWorkTimeQueryHandler>()
                .As<IQueryHandler<UserWorkTimeQuery, UserWorkTime>>();

            builder.RegisterType<StartWorkDialog>();
        }
    }
}