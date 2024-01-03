namespace User.UseCases.Responses;

public record UpdateUserResponse(FailureType? FailureType = null, string? FailureReason = null);

public enum FailureType
{
    User,
    Server
}