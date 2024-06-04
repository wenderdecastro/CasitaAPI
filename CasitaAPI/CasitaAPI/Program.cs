using CasitaAPI.Utils.Mail;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services
    .AddControllers()
        .AddNewtonsoftJson(options =>
        {
            // Ignora os loopings nas consultas
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            // Ignora valores nulos ao fazer junções nas consultas
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }
    );


//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //valida quem está solicitando
        ValidateIssuer = true,

        //valida quem está recebendo
        ValidateAudience = true,

        //define se o tempo de expiração será validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("CasitaAPI-chave-symmetricsecuritykey")),

        //valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(30),

        //nome do issuer (de onde está vindo)
        ValidIssuer = "CasitaAPI",

        //nome do audience (para onde está indo)
        ValidAudience = "CasitaAPI"
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure EmailSettings
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection(nameof(EmailSettings)));

// Registrando o serviço de e-mail como uma instância transitória, que é criada cada vez que é solicitada
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<EmailSendingService>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
