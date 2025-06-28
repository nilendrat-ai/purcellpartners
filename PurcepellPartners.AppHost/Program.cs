var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.PurcepellPartners_ApiService>("apiservice");

builder.Build().Run();
