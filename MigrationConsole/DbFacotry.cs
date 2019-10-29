using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MigrationConsole
{
    public class DbFacotry : IDesignTimeDbContextFactory<TestContext>
    {

        public TestContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TestContext> optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseSqlite("Data Source=./blog.db", options => options.MigrationsAssembly(typeof(DbFacotry).Namespace));

            return new TestContext(optionsBuilder.Options);
        }
    }
}
