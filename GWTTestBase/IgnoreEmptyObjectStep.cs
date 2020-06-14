using System.Linq;
using FluentAssertions.Equivalency;

namespace GWTTestBase
{
    public class IgnoreEmptyObjectStep : IEquivalencyStep
    {
        public bool CanHandle(IEquivalencyValidationContext context, IEquivalencyAssertionOptions config)
            => context.RuntimeType.GetFields().Length == 0
               && context.RuntimeType.GetProperties().Length == 0;

        public bool Handle(IEquivalencyValidationContext context, IEquivalencyValidator parent,
            IEquivalencyAssertionOptions config) => true;
    }
}