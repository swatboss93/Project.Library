using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Project.Library.EntityFramework.Repositories
{
    public abstract class LibraryRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LibraryDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LibraryRepositoryBase(IDbContextProvider<LibraryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class LibraryRepositoryBase<TEntity> : LibraryRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LibraryRepositoryBase(IDbContextProvider<LibraryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
