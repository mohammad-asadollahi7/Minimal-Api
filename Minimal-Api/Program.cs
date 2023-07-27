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

app.MapPut("/updateuser", async (HttpContext context, [FromServices] ICRUDServices CRUDServices) =>
    {
        var updatedUser = await context.Request.ReadFromJsonAsync<User>();
        CRUDServices.Update(updatedUser);
        context.Response.StatusCode = 200;
    });


app.MapDelete("/deleteuser/{id}", (HttpContext context, [FromServices] ICRUDServices
                                         CRUDSercives, int id) =>
{
    CRUDSercives.Delete(id);
    context.Response.StatusCode = 200;
});
app.Run();


