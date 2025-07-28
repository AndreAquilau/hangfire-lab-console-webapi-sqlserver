using Hangfire;
using Hangfire.SqlServer;

string connectionString = @"Server=localhost;Database=HANG_FIRE_CONSOLE;User Id=sa;Password=@@Root123;TrustServerCertificate=True;";

GlobalConfiguration
    .Configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true
    });


// Server - observa as tabelas da base de dados do hangfire
using (var server = new BackgroundJobServer())
{
    Console.WriteLine("Hangfire Server started. Press ENTER to exit...");
    Console.ReadLine();
}