using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectToSend.CrossCutting;
using ProjectToSend.CrossCutting.Services;
using TheProjectToSend.Api.Extensions;
using TheProjectToSend.Context;
using TheProjectToSend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersonContext(builder.Configuration);
builder.Services.PolicyRegistration(builder.Configuration);
builder.Services.AddCommonServices();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwagger();
}

/*builder.Services.AddDbContext<PersonContext>(opt =>
                          opt.UseSqlServer(builder.Configuration.GetConnectionString("NewDatabase"))
                             .EnableSensitiveDataLogging()
                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
//builder.Services.AddScoped<IPersonRepository<Person>, PersonRepository>();
//builder.Services.AddScoped<IGenderRepository<Gender>, GenderRepository>();
//builder.Services.AddScoped<IPersonService, PersonService>();
//builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
/*builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    { jwtSecurityScheme, Array.Empty<string>() }
        });
});

var appSettingsSection = builder.Configuration.GetSection("TokenCredential");
builder.Services.Configure<TokenCredential>(appSettingsSection);
var appSettings = appSettingsSection.Get<TokenCredential>();

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
       .AddJwtBearer(x =>
       {
           x.RequireHttpsMetadata = false;
           x.SaveToken = true;
           x.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(key),
               ValidateIssuer = false,
               ValidateAudience = false
           };
       });*/




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    app.UseSwaggerWithUi();
    app.UseCors("DevCors");
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

try
{
    app.Run();
}
catch (Exception)
{
    throw;
}

