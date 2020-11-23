using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using ShortBreakView.Application.CommandHandlers;
using ShortBreakView.Application.Commands;
using ShortBreakView.Application.Query;
using ShortBreakView.Application.QueryHandlers;
using ShortBreakView.Application.Views;
using DateTime = CQRSLib.DateTime.DateTime;
using Module = Autofac.Module;

namespace ShortBreakView.UI
{
    public sealed class ShortBreakViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

           builder.RegisterType<InterruptShortBreakCommandHandler>()
                .As<ICommandHandler<InterruptShortBreakCommand>>();
            
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
              
               builder.RegisterType<StartShortBreakTimeQueryHandler>()
                   .As<IQueryHandler<StartShortBreakTimeQuery, StartShortBreakTimeView>>();
   
            builder.RegisterType<ShortBreakDialog>();
        }
    }
}