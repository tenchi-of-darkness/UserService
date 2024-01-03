using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace User.UseCases.Entities;

public class UserEntity
{
    public string Id { get; set; }
    public string? UserName { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePictureUrl { get; set; }
}