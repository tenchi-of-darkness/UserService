using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace User.Data.DBO;

public class UserDBO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string? UserName { get; set; } = "";
    public string? Bio { get; set; } = "";
}