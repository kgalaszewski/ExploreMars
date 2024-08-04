namespace ExploreMars.Exceptions;

public class InvalidMovementCommandException : Exception
{
    public InvalidMovementCommandException() { }

    public InvalidMovementCommandException(char command)
        : base($"Invalid Movement Command: {command}") { }
}