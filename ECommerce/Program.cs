using Microsoft.OpenApi;
using ECommerce;
using Microsoft.EntityFrameworkCore;
using ECommerce.Tables.Products;
using ECommerce.Tables.Identity;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddScoped<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

//var context = app.Services.GetRequiredService<AppDbContext>();


//var fetchAllUsers = context.Users.ToList();

//foreach (var user in fetchAllUsers)
//{
//    Console.WriteLine(user.Name);
//}



/*
    Http Request => A,B,C
    Http Response => C,B,A

    A (Before)
        b (Before)
            c (Before)
    Controller
    c (After)
        b (After)
            A (After)
*/

//app.UseMiddleware<A>();
//app.UseMiddleware<B>();
//app.UseMiddleware<C>();

app.UseHttpsRedirection();


using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//int roleId = context.Roles.Where(i => i.Name == "Manager").First().Id;

//User user = new User() {
//    UserName = "ahmed_user",
//    Name =  "Ahmed",
//    Password = "Test.123",
//    Email = "ahmed@gmail.com",
//    RoleId = roleId
//    //Phone = "+53802545454"
//};

//context.Users.Add(user);

//context.SaveChanges();

var users = context.Users.Include(i => i.Role).ToList();

foreach (var user in users)
{
    Console.WriteLine($"User Name {user.Name} Has Role {user.Role?.Name}");
}

app.UseAuthorization();

app.MapControllers();

app.Run();
