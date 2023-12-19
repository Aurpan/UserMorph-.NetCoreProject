namespace UserMorph.Core.ApplicationExceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string errorMessage) : base(errorMessage) { }

    }
}
