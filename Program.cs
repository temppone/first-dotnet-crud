using Catalog.Entities;
using Catalog.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/items", () => 
{
    var repository = new InMemItemsRepository();
    var items = repository.GetItems();

    return items;   
});

app.MapGet("/items/{id}", (Guid id) => 
{
    var repository = new InMemItemsRepository();
    var item = repository.GetItem(id);

    return item;   
});

app.MapPost("/items", (Item item) => 
{
    var repository = new InMemItemsRepository();
    repository.CreateItem(item);

    return item;   
});

app.MapPut("/items/{id}", (Guid id, Item item) => 
{
    var repository = new InMemItemsRepository();
    var existingItem = repository.GetItem(id);

    var updatedItem = existingItem with 
    {
        Name = item.Name,
        Price = item.Price
    };

    repository.UpdateItem(updatedItem);

    return updatedItem;   
});

app.MapDelete("/items/{id}", (Guid id) => 
{
    var repository = new InMemItemsRepository();
    repository.DeleteItem(id);

    return Results.NoContent();   
});

app.Run();