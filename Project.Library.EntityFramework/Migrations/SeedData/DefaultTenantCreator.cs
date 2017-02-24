using System.Linq;
using Project.Library.EntityFramework;
using Project.Library.MultiTenancy;

namespace Project.Library.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly LibraryDbContext _context;

        public DefaultTenantCreator(LibraryDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
