using Repository;
using System;

namespace MigrationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestContext db = new DbFacotry().CreateDbContext(null);

        }
    }
}
