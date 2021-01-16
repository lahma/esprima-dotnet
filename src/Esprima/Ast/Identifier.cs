using System;

namespace Esprima.Ast
{
    public sealed class Identifier : Expression
    {
        public readonly string Name;

        public Identifier(string? name) : base(Nodes.Identifier)
        {
#if LOCATION_ASSERTS
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
#endif
            Name = name;
        }

        public override NodeCollection ChildNodes => NodeCollection.Empty;
    }
}