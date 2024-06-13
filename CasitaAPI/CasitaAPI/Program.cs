using CasitaAPI.Data;
using CasitaAPI.Utils.Mail;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Casita API",
        Description = "An ASP.NET CORE API dedicated to Casita app.",
        //TermsOfService = new Uri("https://example.com/terms"),
        //Contact = new OpenApiContact
        //{
        //    Name = "Example Contact",
        //    Url = new Uri("https://example.com/contact")
        //},
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });
});
builder.Services.AddDbContext<CasitaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDataBase")));

// Configure EmailSettings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection(nameof(EmailSettings)));

// Registrando o serviço de e-mail como uma instância transitória, que é criada cada vez que é solicitada
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddScoped<EmailSendingService>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
}
else
{
    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
}

//builder.Services.AddAzureClients(x =>
//{
//    x.AddBlobServiceClient(new Uri("https://<account-name>.blob.core.windows.net"));
//    x.UseCredential(new DefaultAzureCredential());
//});

//builder.Services.AddDbContext<CasitaContext>(options =>
//    options.UseSqlServer(connection));

//builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
