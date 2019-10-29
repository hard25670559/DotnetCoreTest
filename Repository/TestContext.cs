using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class TestContext : DbContext
    {

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
