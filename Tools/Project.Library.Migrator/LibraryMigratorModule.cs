using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Project.Library.EntityFramework;

namespace Project.Library.Migrator
{
    [DependsOn(typeof(LibraryDataModule))]
    public class LibraryMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<LibraryDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}