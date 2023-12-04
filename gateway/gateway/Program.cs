using CSharpShared.Exception;
using gateway.AuhtenticationScheme;
using gateway.DTO;
using gateway.Model;
using gateway.Model.Implementation;
using gateway.RpcClient;
using gateway.RpcClient.Interface;
using RpcClient.RpcClient.Implementation;
using RpcClient.RpcClient.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthenticationServiceClient, AuthenticationServiceClientImpl>();
builder.Services.AddScoped<IPackage, PackageLogicImpl>();
builder.Services.AddScoped<ILocationServiceClient, LocationServiceClientImpl>();
builder.Services.AddScoped<IAuthenticationServiceClient, AuthenticationServiceClientImpl>();
builder.Services.AddScoped<IPackageServiceClient, PackageServiceClient>();
builder.Services.AddScoped<IUserServiceClient, UserServiceClientImpl>();
builder.Services.AddScoped<DtoMapper>();
builder.Services.AddScoped<IAuth, AuthLogicImpl>();
builder.Services.AddScoped<ILocationServiceLogic, LocationLogicImpl>();
builder.Services.AddScoped<ExceptionHandler>();

// Add authentication. Every request will be authenticated using the AuthenticationProviderSchemeHandler
builder.Services.AddAuthentication().AddScheme<AuthenticationProviderOptions, AuthenticationProviderSchemeHandler>(
    "AuthenticationProvider", null);

var app = builder.Build();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();