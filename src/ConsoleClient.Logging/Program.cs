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

while (true)
{
    Console.WriteLine("Digite uma mensagem para o servidor: ");

    var payload = Console.ReadLine();

    //BackgroundJob.Enqueue(() => Console.WriteLine(payload ?? "Empty"));
    //BackgroundJob.Schedule(() => Console.WriteLine( "Delay: " + payload ?? "Empty"), TimeSpan.FromMinutes(2));
}