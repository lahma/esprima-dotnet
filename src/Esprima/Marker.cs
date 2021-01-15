namespace Esprima
{
    internal readonly struct Marker
    {
        public readonly int Index;
        public readonly int Line;
        public readonly int Column;

        public Marker(int index, int line, int column)
        {
            Index = index;
            Line = line;
            Column = column;
        }

        public Marker(Scanner scanner)
            : this(scanner.Index, scanner.LineNumber, scanner.Index - scanner.LineStart)
        {
        }

        public Marker(in Marker marker)
            : this(marker.Index, marker.Line, marker.Column)
        {
        }
    }
}