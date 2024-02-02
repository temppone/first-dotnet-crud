using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductsRepository, InMemProductsRepository>();
// builder.Services.AddTransient();
// builder.Services.AddScoped();
builder.Services.AddControllers();
builder.Services.AddMvc();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();