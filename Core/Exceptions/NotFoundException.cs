namespace Core.Exceptions;

public sealed class NotFoundException(string message) : Exception(message);

