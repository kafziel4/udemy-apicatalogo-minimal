using CatalogoAPI.ApiEndpoints;
using CatalogoAPI.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger()
    .AddPersistence()
    .AddAppServices()
    .AddAutenticacaoJwt();

builder.Services.AddCors();

var app = builder.Build();

var environment = app.Environment;

app.UseExceptionHandling(environment)
    .UseSwaggerMiddleware()
    .UseAppCors();

app.UseHttpsRedirection();

app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
