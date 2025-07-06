/* 
 * This code sets up a distributed application using the Aspire framework.
 * It creates a builder for the application, adds an API service project,
 * and then adds a web frontend project that references the API service.
 * The web frontend is configured to wait for the API service to be ready
 * before starting.
 */
var builder = DistributedApplication.CreateBuilder(args);

// Add DB's and MQ 
var oracle = builder.AddOracle("oracle, password")
                    .WithLifetime(ContainerLifetime.Persistent);
                    .WithDataVolume() 
                    .WithDataBindMount(source: @"C:\Oracle\Data"); 
var oracledb = oracle.AddDatabase("oracledb");
builder.AddProject<Projects.Aspire_#>()
       .WithReference(oracledb);
       .WaitFor(oracledb);

var cosmos = builder.AddCosmosDb("cosmosdb, password")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume()
                    .WithDataBindMount(source: @"C:\CosmosDB\Data");     
var cosmosdb = cosmos.AddDatabase("cosmosdb");
builder.AddProject<Projects.Aspire_#>()
       .WithReference(cosmosdb)
       .WaitFor(cosmosdb);

// Existing Cosmos DB
// var builder = DistributedApplication.CreateBuilder(args);
// var existingCosmosName = builder.AddParameter("existingCosmosName");
// var existingCosmosResourceGroup = builder.AddParameter("existingCosmosResourceGroup");
// var cosmos = builder.AddAzureCosmosDB("cosmos-db")
//                    .AsExisting(existingCosmosName, existingCosmosResourceGroup);
// builder.AddProject<Projects.WebApplication>("web")
//       .WithReference(cosmos);

var kafka = builder.AddKafka("kafka");
builder.AddProject<Projects.ExampleProject>()
       .WithReference(kafka);
       .WithKafkaUI() 
//     .WithKafkaUI(kafkaUI => kafkaUI.WithHostPort(9100));
       .WithDataVolume(isReadOnly: false);
       .WithDataBindMount( 
                       source: @"C:\Kafka\Data",
                       isReadOnly: false) 

var rabbitmq = builder.AddRabbitMQ("rabbitmq")
                    .WithLifetime(ContainerLifetime.Persistent)
                    .WithDataVolume() 
                    .WithDataBindMount(source: @"C:\RabbitMQ\Data"); 

// Add API service and web frontend
// The API service is added first, and the web frontend waits for it to be ready.
var apiService = builder.AddProject<Projects.Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

// Build and run the distributed application          
builder.Build().Run();