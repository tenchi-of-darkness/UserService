using NetTopologySuite.Geometries;

namespace User.UseCases.Requests.User;

public record GetUsersRequest(string? SearchValue, int Page = 1, int PageSize = 10);