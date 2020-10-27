using Autofac;
using CQRSLib.DateTime;

namespace PomodoroStatus.Infrastructure
{
    public sealed class PomodoroStatusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DateTime>()
                .As<IDateTime>();
        }
    }
}