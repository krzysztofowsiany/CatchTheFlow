using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using Suggestion.Application.CommandHandlers;
using Suggestion.Application.Commands;

namespace Suggestion.Tests.state_change
{
    public sealed class suggestion_module : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SuggestShortBreakCommandHandler>()
                .As<ICommandHandler<SuggestShortBreakCommand>>();
            
            builder.RegisterType<SuggestLongBreakeCommandHandler>()
                .As<ICommandHandler<SuggestLongBreakeCommand>>();
            
            builder.RegisterType<SuggestWorkCommandHandler>()
                .As<ICommandHandler<SuggestWorkCommand>>();
            
            builder.RegisterType<fake_date_time>()
                .As<IDateTime>();
        }
    }
}