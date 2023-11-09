using NetTopologySuite.Geometries;

namespace User.API.DTO;

public class UserDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string LocationName { get; set; }
    
    public double LocationLat { get; set; }
    public double LocationLong { get; set; }
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; }
}