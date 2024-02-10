

using Catalog.Api.Repositories;
using Catalog.Api.Settings;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoDbSettings = builder.Configuration
    .GetSection(nameof(MongoDbSettings))
    .Get<MongoDbSettings>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(
    options => options.SuppressAsyncSuffixInActionNames = false
);
builder.Services.AddMvc();
builder.Services.AddHealthChecks().AddMongoDb(
    mongoDbSettings.ConnectionString,
    name: "mongodb",
    timeout: TimeSpan.FromSeconds(3),
    tags: new[] {"ready"}
);

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));



builder.Services.AddSingleton<IMongoClient>(ServiceProvider => 
{
  
    
    return new MongoClient(mongoDbSettings.ConnectionString);
});

builder.Services.AddSingleton<IProductsRepository, MongoDBProductsRepository>();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.MapHealthChecks(
    "/health/ready",
    new HealthCheckOptions
    {
        Predicate = (check) => check.Tags.Contains("ready")
    }
);

app.MapHealthChecks(
    "/health/live",
    new HealthCheckOptions
    {
        Predicate = (_) => false
    }
);

app.Run();