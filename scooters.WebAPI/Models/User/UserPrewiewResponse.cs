namespace scooters.WebAPI.Models;
public class UserPreviewResponse
{
    public Guid Id{get;set;}
   public string? Number { get; set; }
    public string? FirstName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Login { get; set; }
    public bool Is_bloked { get; set; } 
}