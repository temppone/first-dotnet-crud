using Catalog.Entities;
using Catalog.Repositories;
using Orders.Entities;
using Orders.Repositories;


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

app.MapGet("/products", () => 
{
    var productsRepository = new InMemProductsRepository();
    var items = productsRepository.GetProducts();

    return items;   
});

app.MapGet("/products/{id}", (Guid id) => 
{
    var productsRepository = new InMemProductsRepository();
    var item = productsRepository.GetItem(id);

    return item;   
});

app.MapPost("/products", (Product item) => 
{
    var productsRepository = new InMemProductsRepository();
    productsRepository.CreateProduct(item);

    return item;   
});

app.MapPut("/products/{id}", (Guid id, Product item) => 
{
    var productsRepository = new InMemProductsRepository();
    var existingItem = productsRepository.GetItem(id);

    var updatedItem = existingItem with 
    {
        Name = item.Name,
        Price = item.Price
    };

    productsRepository.UpdateItem(updatedItem);

    return updatedItem;   
});

app.MapDelete("/products/{id}", (Guid id) => 
{
    var productsRepository = new InMemProductsRepository();
    productsRepository.DeleteProduct(id);

    return Results.NoContent();   
});

app.MapGet("/order/{id}", (Guid id) => 
{
    var orderRepository = new InMemOrdersRepository();
    var items = orderRepository.GetOrder(id);

    return items;   
});


app.Run();