var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.PurcepellPartners_ApiService>("apiservice");

builder.AddProject<Projects.PurcepellPartners_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
