using MediatR;
using MinimalApiExample.Application;
using MinimalApiExample.Application.Common.Interfaces;
using MinimalApiExample.Application.Products.Commands.DeleteProduct;
using MinimalApiExample.Application.Products.Commands.UpsertProduct;
using MinimalApiExample.Application.Products.Queries.GetProducts;
using MinimalApiExample.Application.Products.Queries.GetSingleProduct;
using MinimalApiExample.Domain.Entities;
using MinimalApiExample.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/test", () => "Hello World!");

app.MapDelete("/product/{id}", async (string id, IMediator mediator) =>
{
    var response = await mediator.Send(new DeleteProductCommand() { ProductId = id });

    return response;
});

app.MapGet("/product/{id}", async (string id, IMediator mediator) =>
{
    var response = await mediator.Send(new GetSingleProductQuery() { ProductId = id });

    return response;
});

app.MapPost("/products", async (GetProductsQuery model, IMediator mediator) =>
{
    var response = await mediator.Send(model);

    return response;
});

app.MapPost("/product/upsert", async (UpsertProductCommand model, IMediator mediator) =>
{
    var response = await mediator.Send(model);

    return response;
});



app.Run();
