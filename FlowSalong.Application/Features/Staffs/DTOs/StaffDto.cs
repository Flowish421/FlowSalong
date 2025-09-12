namespace FlowSalong.Application.Features.Staffs.DTOs;

public class StaffDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!; // Viktigt

    public StaffDto() { }

    public StaffDto(int id, string name, string role) // primary constructor om du vill använda den
    {
        Id = id;
        Name = name;
        Role = role;
    }
}
