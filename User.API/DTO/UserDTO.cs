using NetTopologySuite.Geometries;

namespace User.API.DTO;

public class UserDTO
{
    public string Id { get; set; }
    public string? UserName { get; set; }
    public string? Bio { get; set; }
}