using Hangfire;

string connectionString = @"Server=localhost;Database=HANG_FIRE_CONSOLE;User Id=sa;Password=@@Root123;TrustServerCertificate=True;";

GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString);

// Cliente Agendando uma tarefa em fila para ser executada pelo server em segundo plano em threads
BackgroundJob.Enqueue(() => Console.WriteLine("Hello, world!"));


// Server que fica observando as tabelas da base de dados do hangfire
using (var server = new BackgroundJobServer())
{
    Console.ReadLine();
}