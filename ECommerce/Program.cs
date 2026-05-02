using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ECommerce;
using ECommerce.Enitites.Identity;
using ECommerce.Repostories;
using ECommerce.Repostories.Users;
using ECommerce.Business.Users.Services;

//public class MySettings
//{
//    public string AppName { get; set; }
//    public string Version { get; set; }
//}

var builder = WebApplication.CreateBuilder(args);

// ==================== SERVICES ====================

builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySetting"));

// Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// JWT Authentication
var jwtKey = "hjbgsdhgdifghldfjggsadgsdjgbarueigbrugibsguinbesguiarehgkgjsdghaiurghersijgheriseshtrhthjbgsdhgdifghldfjggsadgsdjgbarueigbrugibsguinbesguiarehgkgjsdghaiurghersijgheriseshtrht";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

/*
    1- Role-Based (RBAC) => المستخدم يتنمي الى دور 
    مثال : Admin , Teacher , Student
    ______________
    2-Claim-Based => بدل من دور ممكن ان نعطي المستخدم خصائص (Claims) 
    permission = "branchs.view"; CLAİM
    permission = "branchs.create"; CLAİM
    permission = "student.update";
    permission = "student.edit";
    permission = "student.delete";
    permission = "branchs.assignUserToBranch";
    _________________    
    3 -  Policy-Based => نجمع عدة شروط مع بعض
    مثال : 
    - User Should have "Admin" Role; 
    - User Should have "Student.Create" Permission; 
    - User Should have Depencies to "Tenant A"; 

    4 - ABAC




    appsetting => لادارة الاعدادات
    Environment => لفصل البيئات
    Attributes => للتحكم بسلوك معين داخل التطبيق
*/

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
      policy.RequireRole("Admin");
    });

    options.AddPolicy("UserSupport", policy =>
    {
        policy.RequireClaim("Permission", "CanEditUser");
    });


    //// Claim Based
    //options.AddPolicy("CanCreateUser", policy =>
    //{
    //    policy.RequireClaim("permission", "student.create");
    //});

    //// Policy Based
    //options.AddPolicy("CanCreateUser", policy =>
    //{
    //    policy.RequireClaim("permission", "student.create");
    //    policy.RequireClaim("permission", "student.edit");
    //    policy.RequireClaim("permission", "student.delete");
    //});

    //// Claim Based
    //options.AddPolicy("CanCreateBranch", policy =>
    //{
    //    policy.RequireClaim("permission", "branchs.create");
    //});

    //// Policy Based
    //options.AddPolicy("CanManagerUser", policy =>
    //{
    //    policy.RequireRole("Teacher");
    //    policy.RequireClaim("permission", "student.view");
    //});
});

// Repositories & Services
builder.Services.AddScoped<IUserRepostory, UserRepostory>();
builder.Services.AddScoped<IUserService, UserService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerce API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "ادخل التوكن بدون كلمة Bearer",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors("Allow");


app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
}

app.Run();