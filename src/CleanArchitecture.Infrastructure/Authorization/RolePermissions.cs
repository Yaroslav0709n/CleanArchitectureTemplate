using System.Collections.ObjectModel;

namespace CleanArchitecture.Infrastructure.Authorization;

public static class Action
{
    public const string View = nameof(View);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
}

public static class Resource
{
    public const string Users = nameof(Users);
    public const string Roles = nameof(Roles);
    public const string UserRoles = nameof(UserRoles);
    public const string Organizations = nameof(Organizations);
}

public static class RolePermissions
{
    private static readonly Permission[] _all =
    [
        new("View Users", Action.View, Resource.Users, IsBasic: true),
        new("Create Users", Action.Create, Resource.Users),
        new("Update Users", Action.Update, Resource.Users),
        new("Delete Users", Action.Delete, Resource.Users),

        new("View Users", Action.View, Resource.Roles, IsBasic: true),
        new("Create Users", Action.Create, Resource.Roles),
        new("Update Users", Action.Update, Resource.Roles),
        new("Delete Users", Action.Delete, Resource.Roles),

        new("View UserRoles", Action.View, Resource.UserRoles, IsBasic: true),

        new("View Organizations", Action.View, Resource.Organizations, IsBasic: true),
        new("Create Organizations", Action.Create, Resource.Organizations),
        new("Update Organizations", Action.Update, Resource.Organizations),
        new("Delete Organizations", Action.Delete, Resource.Organizations)
    ];

    public static IReadOnlyList<Permission> Admin { get; } = new ReadOnlyCollection<Permission>(_all.ToArray());
    public static IReadOnlyList<Permission> Basic { get; } = new ReadOnlyCollection<Permission>(_all.Where(p => p.IsBasic).ToArray());
}

public record Permission(string Description, string Action, string Resource, bool IsBasic = false)
{
    public const string Permissions = nameof(Permissions);

    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => string.Join('.', Permissions, resource, action);
}