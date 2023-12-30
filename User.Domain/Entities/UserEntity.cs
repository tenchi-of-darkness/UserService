using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace User.UseCases.Entities;

public class UserEntity
{
    public string Id { get; set; }
    public string? UserName { get; set; } = null;
    public string? Bio { get; set; } = null;
}