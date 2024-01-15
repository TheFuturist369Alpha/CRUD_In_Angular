using Microsoft.EntityFrameworkCore;
using GenDataBase;
using Services.AccountManager;
using Services.AccountManager.AccountManagerContracts;
using Services.AccountManager.PrimaryUsersAccountManagers;
using UnitOfWork.DbRepo;
using UnitOfWork.IDbRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GenDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnect"]);
});
builder.Services.AddScoped<ISigninManager, SigninManager>();
builder.Services.AddScoped<ILoginManager, LoginManager>();
builder.Services.AddScoped<IUpdateAccountManager, UpdateManager>();
builder.Services.AddScoped<IDeleteAccountManager, DeleteAccountManager>();
builder.Services.AddScoped<IRepo, Repo>();

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
