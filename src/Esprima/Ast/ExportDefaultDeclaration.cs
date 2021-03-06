﻿namespace Esprima.Ast
{
    public class ExportDefaultDeclaration : Node,
        ExportDeclaration
    {
        public Declaration Declaration; //: BindingIdentifier | BindingPattern | ClassDeclaration | Expression | FunctionDeclaration;
        public ExportDefaultDeclaration(Declaration declaration)
        {
            Type = Nodes.ExportDefaultDeclaration;
            Declaration = declaration;
        }
    }
}
