using Microsoft.AspNetCore.Mvc;
using Minimal_Api.Data;
using Minimal_Api.Model;
using Minimal_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICRUDServices, CRUDServices>();
builder.Services.AddScoped<UserData>();

var app = builder.Build();

// Configure the HTTP request pipeline.




app.MapGet("/users", async (HttpContext context, [FromServices] ICRUDServices CRUDServices) =>
{
    await context.Response.WriteAsJsonAsync(CRUDServices.GetAll());
});

app.MapGet("/user/{id}", async (HttpContext context, [FromServices] ICRUDServices CRUDServices,
                                int id) =>
{
    await context.Response.WriteAsJsonAsync(CRUDServices.GetById(id));
});

app.MapPost("/adduser", async (HttpContext context, [FromServices] ICRUDServices CRUDServices) =>
{

    var newUser = await context.Request.ReadFromJsonAsync<User>();
    CRUDServices.Create(newUser);
    context.Response.StatusCode = 201;
});
app.Run();
