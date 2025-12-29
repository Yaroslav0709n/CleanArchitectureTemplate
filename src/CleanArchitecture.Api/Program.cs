using CleanArchitecture.Api;
using CleanArchitecture.Api.Extensions;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddPresentation(builder.Configuration)
                .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.ApplyMigrationsAsync(CancellationToken.None);
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCurrentUserMiddleware();

app.MapControllers();

app.Run();
