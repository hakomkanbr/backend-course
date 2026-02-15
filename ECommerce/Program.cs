using Microsoft.OpenApi;

using ECommerce.Models;



var builder = WebApplication.CreateBuilder(args);


//List<Employee> employees = new List<Employee>() { 
//    new FullTimeEmployee(),
//    new PartTimeEmployee(),
//};

List<IReport> reports = new List<IReport>() {
    new StudentReport(),
    new TeachrtReport()
};

foreach (var report in reports)
{
    report.GenerateReport();
}

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IStudentService,StudentService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
