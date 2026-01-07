namespace CleanArchitecture.Application.Dtos.Roles;

public class UserRoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Enabled { get; set; }
}