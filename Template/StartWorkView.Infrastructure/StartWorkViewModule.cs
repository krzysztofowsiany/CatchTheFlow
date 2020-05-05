using Autofac;
using CQRSLib.DateTime;
using DateTime = System.DateTime;
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

          /* builder.RegisterType<StopWorkCommandHandler>()
                .As<ICommandHandler<StopWorkCommand>>();
            */
            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}