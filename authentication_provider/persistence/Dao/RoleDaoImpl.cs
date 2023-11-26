using persistance.Entity;
using persistance.Exception;

namespace persistance.Dao;

public class RoleDaoImpl : IRoleDao
{
    private readonly PostgresContext _context;

    public RoleDaoImpl(PostgresContext context)
    {
        _context = context;
    }

    public Role GetDefaultRole()
    {
        Role? role = _context.Roles.FirstOrDefault(role => role.Name.Equals("user"));
        if (role == null)
            throw new NotFoundException("Default role has not been found");
        return role;
    }
}