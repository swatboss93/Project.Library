using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Project.Library.Authorization.Roles;
using Project.Library.Authors;
using Project.Library.MultiTenancy;
using Project.Library.Users;

namespace Project.Library.EntityFramework
{
    public class LibraryDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual IDbSet<Author> authors { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public LibraryDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in LibraryDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of LibraryDbContext since ABP automatically handles it.
         */
        public LibraryDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public LibraryDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
