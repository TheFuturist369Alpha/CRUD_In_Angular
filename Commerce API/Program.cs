using Microsoft.EntityFrameworkCore;
using GenDataBase;
using Services.AccountManager;
using Services.AccountManager.AccountManagerContracts;
using Services.AccountManager.PrimaryUsersAccountManagers;
using UnitOfWork.DbRepo;
using UnitOfWork.IDbRepo;
using Services.Peripherals.Contracts;
using Services.Peripherals.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GenDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:Db2Connect"]);
});
builder.Services.AddScoped<ISigninManager, SigninManager>();
builder.Services.AddScoped<ISigninManager, SigninManager>();
builder.Services.AddScoped<ILoginManager, LoginManager>();
builder.Services.AddScoped<IUpdateAccountManager, UpdateManager>();
builder.Services.AddScoped<IDeleteAccountManager, DeleteAccountManager>();
builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddScoped<IPeripherals, Peripheral>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(build =>
    {
        build.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>());
        build.WithHeaders("Authorization", "origin", "accept", "content-type");
        build.WithMethods("GET", "POST", "PUT", "DELETE");
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthorization();


app.MapControllers();

app.Run();
