using NetTopologySuite.Geometries;

namespace User.UseCases.Responses;

public record GetUserResponse(
    string Id,
    string UserName,
    string? Bio);