using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using WorkView.Application.CommandHandlers;
using WorkView.Application.Commands;
using WorkView.Application.Query;
using WorkView.Application.QueryHandlers;
using WorkView.Application.Views;
using Module = Autofac.Module;

namespace WorkView.UI
{
    public sealed class WorkViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<InterruptWorkCommandHandler>()
                .As<ICommandHandler<InterruptWorkCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
              
               builder.RegisterType<StartWorkTimeQueryHandler>()
                   .As<IQueryHandler<StartWorkTimeQuery, StartWorkTime>>();
   
            builder.RegisterType<WorkDialog>();
        }
    }
}