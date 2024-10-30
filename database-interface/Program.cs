using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var username = string.Empty;
var password = string.Empty;
File.ReadAllLines("/run/secrets/mongodb_username")
    .ToList()
    .ForEach(line => username = line );
File.ReadAllLines("/run/secrets/mongodb_password")
    .ToList()
    .ForEach(line => password = line );

var connectionString = $"mongodb://{username}:{password}@mongodb:27017";

var client = new MongoClient(connectionString);

app.MapGet("/", () => {
  return $"Connection string: {connectionString}\n" +
         $"Database names: {string.Join(", ", client.ListDatabaseNames().ToList())}";
});

app.Run("http://*:25052/");
