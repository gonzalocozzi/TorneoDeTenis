namespace TorneoDeTenis.Exceptions
{
    public class NumeroDeJugadoresInvalidoException : Exception
    {
        public NumeroDeJugadoresInvalidoException() { }
        public NumeroDeJugadoresInvalidoException(string message) : base(message) { }
        public NumeroDeJugadoresInvalidoException(string message, Exception inner) : base(message, inner) { }
    }
}