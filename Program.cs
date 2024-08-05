     using BenchmarkDotNet.Attributes;
     using BenchmarkDotNet.Running;
     using NLog;
     using Serilog;

     public class LoggingBenchmark
     {
         private static readonly Logger NLogLogger = LogManager.GetCurrentClassLogger();
         private static readonly Serilog.ILogger SerilogLogger = new LoggerConfiguration()
             .WriteTo.Console()
             .CreateLogger();

         [Benchmark]
         public void NLogBenchmark()
         {
             NLogLogger.Info("This is a test log message for NLog.");
         }

         [Benchmark]
         public void SerilogBenchmark()
         {
             SerilogLogger.Information("This is a test log message for Serilog.");
         }
     }

     public class Program
     {
         public static void Main(string[] args)
         {
             var summary = BenchmarkRunner.Run<LoggingBenchmark>();
         }
     }
     