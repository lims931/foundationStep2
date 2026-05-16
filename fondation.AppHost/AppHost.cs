var builder = DistributedApplication.CreateBuilder(args);

var backend = builder.AddProject<Projects.Backend>("backend");

builder.AddProject<Projects.FrontEnd>("frontend")
    .WithReference(backend)
    .WaitFor(backend);

builder.Build().Run();
