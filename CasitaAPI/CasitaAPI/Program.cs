using CasitaAPI.Utils.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
