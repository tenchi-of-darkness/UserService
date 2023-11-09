using NetTopologySuite.Geometries;

namespace User.UseCases.Responses;

public record GetUserResponse(Guid Id, string Name, string LocationName, Point Location, Guid OwnerUserId,
    string Description);
