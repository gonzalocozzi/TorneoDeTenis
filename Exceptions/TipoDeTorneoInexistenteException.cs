namespace TorneoDeTenis.Exceptions
{
    public class TipoDeTorneoInexistenteException : Exception
    {
        public TipoDeTorneoInexistenteException()
        {
        }

        public TipoDeTorneoInexistenteException(string message)
            : base(message)
        {
        }

        public TipoDeTorneoInexistenteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}