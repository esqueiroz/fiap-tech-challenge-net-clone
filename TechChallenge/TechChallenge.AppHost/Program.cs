var builder = DistributedApplication.CreateBuilder(args);

var postgress = builder.AddPostgres("aspire-postgres")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.TechChallenge_Api>("techchallenge-api")
    .WithReference(postgress);

builder.Build().Run();
