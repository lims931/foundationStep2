var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
            .WithRedisCommander()
            .WithLifetime(ContainerLifetime.Persistent);

var backend = builder.AddProject<Projects.Backend>("backend")
            .WithReference(cache)
            .WaitFor(cache);

builder.AddProject<Projects.FrontEnd>("frontend")
    .WithReference(backend)
    .WaitFor(backend);

builder.Build().Run();
