using Microsoft.OpenApi;
using ECommerce;
using Microsoft.EntityFrameworkCore;
using ECommerce.Enitites.Products;
using ECommerce.Enitites.Identity;
using ECommerce.Enitites;
using ECommerce.Repostories;
using ECommerce.Repostories.Users;
using ECommerce.Business.Users.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddScoped<AppDbContext>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

/*
 Scoped => موظف لكل زبون 
 Singleton => مدير واحد الشركة
*/


builder.Services.AddScoped<IUserRepostory, UserRepostory>();
builder.Services.AddScoped<IUserService,UserService>();


//builder.Services.AddScoped<IMyService, MyService>();

//builder.Services.AddSingleton<IMyService, MyService>();

//builder.Services.AddScoped<IUserService,SqlUserService>();

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

app.UseHttpsRedirection();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//List<Order> orders = context.Orders.ToList(); // Lazy Loaging

//foreach (var order in orders)
//{
//    var items = order.OrderItems;
//}

//var order = context.Orders.Include(i => i.OrderItems).First(); // Eager Loaging

/*
    - Eager Loading
    Select * From Orders JOIN OrderItems On Orders.Id = OrderItems.OrderId;

    // Take Orders + OrderItems with same request
 */

/*
    - Separeate Query = Quary منفصل 
    - Full Control = تحكم كامل
    - أفضل من طريقة Lazy Loading
*/

//var order = context.Orders.First(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
