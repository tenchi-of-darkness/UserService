using NetTopologySuite.Geometries;
using User.UseCases.Responses;

namespace User.UseCases.Requests.User;

public record AddUserRequest(
    string Id,
    string UserName,
    string LocationName,
    double LocationLat,
    double LocationLong,
    Guid OwnerUserId,
    string? Bio);