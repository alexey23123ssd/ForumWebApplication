namespace Application.Common.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException(string name) : base($"Entity{name} not found") 
        { 

        }
    }
}
