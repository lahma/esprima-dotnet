using System.Runtime.CompilerServices;

namespace Esprima
{
    internal readonly struct TextSpan
    {
        public static readonly TextSpan Empty = new(string.Empty);

        public readonly int Length;
        public readonly int Offset;
        public readonly string Buffer;

        public TextSpan(string value)
        {
            Buffer = value;
            Offset = 0;
            Length = value.Length;
        }

        public TextSpan(string buffer, int offset, int length)
        {
            Buffer = buffer;
            Offset = offset;
            Length = length;
        }

        public int this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Buffer[Offset + i];
        }

        public override string ToString()
        {
            return Offset == 0
                ? Buffer
                : Buffer.Substring(Offset, Length);
        }
    }
}