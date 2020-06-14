using Autofac;
using CQRSLib;
using CQRSLib.DateTime;
using Suggestion.Application.CommandHandlers;
using Suggestion.Application.Commands;
using Module = Autofac.Module;

namespace Suggestion.Infrastructure
{
    public sealed class SuggestionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<SuggestionEventListener>()
                .AutoActivate();

            builder.RegisterType<DateTime>()
                .As<IDateTime>();
            
            builder.RegisterType<SuggestShortBreakCommandHandler>()
                .As<ICommandHandler<SuggestShortBreakCommand>>();
        }
    }
}