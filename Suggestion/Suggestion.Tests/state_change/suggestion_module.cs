using Autofac;
using CQRSLib.DateTime;

namespace Suggestion.Tests.state_change
{
    public sealed class suggestion_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

          //  builder.RegisterType<StopWorkCommandHandler>()
               // .As<ICommandHandler<StopWorkCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}