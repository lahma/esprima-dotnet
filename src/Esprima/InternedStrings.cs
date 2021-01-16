namespace Esprima
{
    /// <summary>
    /// Strings that parser will provide and allow reference equality for faster checks.
    /// Use at your own risk.
    /// </summary>
    public static class InternedStrings
    {
        public static readonly string Arguments = "arguments";
        public static readonly string Eval = "eval";
        public static readonly string Await = "await";
        public static readonly string True = "true";
        public static readonly string False = "false";
        public static readonly string Undefined = "undefined";
        public static readonly string Null = "null";
        public static readonly string Enum = "enum";
        public static readonly string Export = "export";
        public static readonly string Import = "import";
        public static readonly string Super = "super";
        public static readonly string OperatorDoubleAnd = "&&";
        public static readonly string OperatorDoublePipe = "||";
        public static readonly string OperatorDoubleQuestion = "??";
        public static readonly string Async = "async";
        public static readonly string Of = "of";
        public static readonly string In = "in";
        public static readonly string As = "as";
        public static readonly string From = "from";
    }
}