using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace User.Data.DBO;

public class UserDBO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; } = "";
    
    public string LocationName { get; set; } = "";
    public Point Location { get; set; } = Point.Empty;
    public Guid OwnerUserId { get; set; }
    public string? Description { get; set; } = "";
}