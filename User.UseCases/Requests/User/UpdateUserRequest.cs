using NetTopologySuite.Geometries;
using User.UseCases.Responses;

namespace User.UseCases.Requests.User;

public record UpdateUserRequest(
    string UserName,
    string? Bio);