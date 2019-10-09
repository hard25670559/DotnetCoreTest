using Serilog;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;

namespace DotnetCore_30_Console_Log_Test
{

    public class Test
    {
        public override string ToString()
        {
            return Guid.NewGuid().ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILogger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log2.json")
                .CreateLogger();

            List<object> col = new List<object>
            {
                new Test(), new Test(), new Test()
            };

            string tmpString = "test";

            log.Information($"Information { tmpString }.");
            log.Fatal("Fatal {tmpString}", tmpString);
            log.Error($"Error { col }.");
            log.Warning("Warning {col}", col);
            log.Verbose("Verbose {col}", col);
            log.Debug("Debug.");

            Console.ReadKey();
        }
    }
}
