var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();


/* 
* This code sets up a distributed application using the Aspire framework.
 * It creates a builder for the application, adds an API service project,
 * and then adds a web frontend project that references the API service.
 * The web frontend is configured to wait for the API service to be ready
 * before starting.
 */

 /** Call AddOracle to add and return an Oracle server resource 
 builder. Chain a call to the returned resource builder to AddDatabase,
 to add an Oracle database to the server resource:
 **/
// var oracleServer = builder.AddOracle().AddDatabase("mydb");
// If you'd rather connect to an existing Oracle server, call AddConnectionString 
var builder = DistributedApplication.CreateBuilder(args);

var oracle = builder.AddOracle("oracle, password")
                    .WithLifetime(ContainerLifetime.Persistent);

var oracledb = oracle.AddDatabase("oracledb");

builder.AddProject<Projects.Aspire_#>()
       .WithReference(oracledb);
       .WaitFor(oracledb);

// After adding all resources, run the app...