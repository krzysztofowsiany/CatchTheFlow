using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using LongBreakView.Application.CommandHandlers;
using LongBreakView.Application.Commands;
using LongBreakView.Application.Query;
using LongBreakView.Application.QueryHandlers;
using LongBreakView.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace LongBreakView.UI
{
    public sealed class LongBreakViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<InterruptLongBreakCommandHandler>()
                .As<ICommandHandler<InterruptLongBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
              
               builder.RegisterType<StartLongBreakTimeQueryHandler>()
                   .As<IQueryHandler<StartLongBreakTimeQuery, StartLongBreakTimeView>>();
   
            builder.RegisterType<LongBreakDialog>();
        }
    }
}