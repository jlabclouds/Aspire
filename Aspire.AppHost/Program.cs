/* 
 * This code sets up a distributed application using the Aspire framework.
 * It creates a builder for the application, adds an API service project,
 * and then adds a web frontend project that references the API service.
 * The web frontend is configured to wait for the API service to be ready
 * before starting.
 */
var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

// Add Oracle Database
// https://learn.microsoft.com/en-us/dotnet/aspire/database/oracle-entity-framework-integration?tabs=package-reference
// To use Oracle, you need to install the Oracle Entity Framework Core provider.
// You can do this by adding the NuGet package `Oracle.EntityFrameworkCore` to your project.
// You can also use the `AddOracle` method to configure the Oracle database
// connection string and other settings. The `AddDatabase` method is used to specify
// the name of the database you want to connect to.
// Example:
var builder = DistributedApplication.CreateBuilder(args);
var oracle = builder.AddOracle("oracle, password")
                    .WithLifetime(ContainerLifetime.Persistent);
                    .WithDataVolume() // Optional: to persist data across restarts
                    // The password is stored in the data volume. When using a data volume 
                    // and if the password changes, it will not work until you delete the volume.
                    .WithDataBindMount(source: @"C:\Oracle\Data"); // Optional: bind mount a local directory to persist data
                    // Data bind mounts have limited functionality compared to volumes, which offer better performance, portability, 
                    // and security, making them more suitable for production environments. However, bind mounts allow direct access 
                    // and modification of files on the host system, ideal for development and testing where real-time changes are needed. 
var oracledb = oracle.AddDatabase("oracledb");
builder.AddProject<Projects.Aspire_#>()
       .WithReference(oracledb);
       .WaitFor(oracledb);

// Add Azure Cosmos DB
// https://learn.microsoft.com/en-us/dotnet/aspire/database/azure-cosmos-db-integration?tabs=dotnet-cli
// To use Azure Cosmos DB, you need to install the Azure Cosmos DB Entity Framework Core provider.
// You can do this by adding the NuGet package `Microsoft.EntityFrameworkCore.Cosmos` to your project.
// You can also use the `AddCosmosDb` method to configure the Azure Cosmos DB connection string and other settings.
// The `AddDatabase` method is used to specify the name of the database you want to connect to.
// Example:
var builder = DistributedApplication.CreateBuilder(args);
var cosmos = builder.AddCosmosDb("cosmosdb, password")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume()
                    .WithDataBindMount(source: @"C:\CosmosDB\Data");     
var cosmosdb = cosmos.AddDatabase("cosmosdb");
builder.AddProject<Projects.Aspire_#>()
       .WithReference(cosmosdb)
       .WaitFor(cosmosdb);

// Existing Cosmmos DB
var builder = DistributedApplication.CreateBuilder(args);
var existingCosmosName = builder.AddParameter("existingCosmosName");
var existingCosmosResourceGroup = builder.AddParameter("existingCosmosResourceGroup");
var cosmos = builder.AddAzureCosmosDB("cosmos-db")
                    .AsExisting(existingCosmosName, existingCosmosResourceGroup);
builder.AddProject<Projects.WebApplication>("web")
       .WithReference(cosmos);


// Add Kafka resource
// https://learn.microsoft.com/en-us/dotnet/aspire/messaging/kafka-integration?tabs=dotnet-cli
// dotnet add Aspire.Hosting.Kafka
var builder = DistributedApplication.CreateBuilder(args);
var kafka = builder.AddKafka("kafka");
builder.AddProject<Projects.ExampleProject>()
       .WithReference(kafka);
       .WithKafkaUI() 
//     .WithKafkaUI(kafkaUI => kafkaUI.WithHostPort(9100)); // Optional: to specify a custom host port for the Kafka UI
       .WithDataVolume(isReadOnly: false); // Better to use volumes for production environments
       .WithDataBindMount( // Optional: to bind mount a local directory for Kafka data, better for development
                       source: @"C:\Kafka\Data",
                       isReadOnly: false) 

// Add RabbitMQ resource
// https://learn.microsoft.com/en-us/dotnet/aspire/messaging/rabbitmq-integration?tabs=dotnet-cli
// dotnet add Aspire.Hosting.RabbitMQ
var builder = DistributedApplication.CreateBuilder(args);
var rabbitmq = builder.AddRabbitMQ("rabbitmq")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume() 
                    .WithDataBindMount(source: @"C:\RabbitMQ\Data"); 
                    

