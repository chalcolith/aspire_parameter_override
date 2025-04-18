var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireParameterOverride_ApiService>("apiservice");

var myParameter = builder.AddParameter("myparameter", "false");

builder.AddProject<Projects.AspireParameterOverride_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithEnvironment("MY_PARAMETER", myParameter)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
