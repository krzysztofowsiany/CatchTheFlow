using FluentAssertions.Equivalency;

namespace GWTTestBase
{
    public class IgnoreTimestampPropertyStep : IEquivalencyStep
    {
        public bool CanHandle(IEquivalencyValidationContext context, IEquivalencyAssertionOptions config)
            => context.SelectedMemberPath.Contains("Timestamp");

        public bool Handle(IEquivalencyValidationContext context, IEquivalencyValidator parent,
            IEquivalencyAssertionOptions config)
            => true;

    }
}