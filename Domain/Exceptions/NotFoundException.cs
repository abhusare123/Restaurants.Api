namespace Domain.Exceptions
{
    public class NotFoundException(string resouceType, string resouceIdentifier) : Exception($"{resouceType} with id: {resouceIdentifier} doesn't exist")
    {
    }
}
