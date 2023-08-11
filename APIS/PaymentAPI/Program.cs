using Contracts;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(KebabCaseEndpointNameFormatter.Instance);

builder.Services.AddMassTransit(cfg =>
{
    cfg.SetKebabCaseEndpointNameFormatter();

    cfg.UsingRabbitMq((context, x) =>
    {
        x.Host(builder.Configuration["Queue"], "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        x.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
    });
});

builder.Services.AddHttpClient();

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