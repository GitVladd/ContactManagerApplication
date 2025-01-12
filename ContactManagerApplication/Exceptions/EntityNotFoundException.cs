namespace ContactManagerApplication.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string str) : base(str ){ }
    }
}
