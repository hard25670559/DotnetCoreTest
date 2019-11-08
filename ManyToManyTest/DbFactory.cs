using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ManyToManyTest
{
    public class DbFactory : IDesignTimeDbContextFactory<MTMContext>
    {
        public MTMContext CreateDbContext(string[] args)
        {

            DbContextOptionsBuilder<MTMContext> optionsBuilder = new DbContextOptionsBuilder<MTMContext>();
            // 以下請自行修改為自己的ConnectionString
            optionsBuilder.UseSqlite(@"Data Source=/Users/hardanonymous/Projects/DotnetCoreTest/ManyToManyTest/ManyToManyTest.db",
                options => options.MigrationsAssembly(typeof(DbFactory).Namespace));
            return new MTMContext(optionsBuilder.Options);


        }
    }
}
