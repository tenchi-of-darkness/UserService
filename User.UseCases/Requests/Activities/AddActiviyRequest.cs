using NetTopologySuite.Geometries;
using User.UseCases.Responses;

namespace User.UseCases.Requests.Activities;

public record AddUserRequest(string Name, string LocationName, Point Location, string? Description);
