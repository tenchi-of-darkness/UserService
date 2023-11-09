namespace User.UseCases.Responses;

public record GetUsersResponse(IEnumerable<GetUserResponse> Activities);