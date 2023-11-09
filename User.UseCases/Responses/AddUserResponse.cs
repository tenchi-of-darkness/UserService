namespace User.UseCases.Responses;

public record AddUserResponse(FailureType? FailureType = null, string? FailureReason = null);

public enum FailureType
{
    User,
    Server
}