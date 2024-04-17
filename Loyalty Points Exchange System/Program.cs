
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using LoyaltyPointsExchangeSystem.Provider;
using System.Text.Json.Serialization;
using LoyaltyPointsExchangeSystem.Interface;
using LoyaltyPointsExchangeSystem.AppDbContext;
using Loyalty_Points_Exchange_System.Provider;
using LoyaltyPointsExchangeystem.Interface;
using Loyalty_Points_Exchange_System.Interface;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegisterUser,RegisterUserProvider>();
builder.Services.AddScoped<ILogin, LoginProvider>();
builder.Services.AddScoped<IItem,ItemProvider>();
builder.Services.AddScoped<IBankAccount, BankAccountProvider>();
builder.Services.AddScoped<IPointsTransfer,PointsTransferProvider>();
builder.Services.AddScoped<IPointsTransferToUser,PointsTransferToUserProvider>();
builder.Services.AddScoped<IRedeemPoints,RedeemPointsProvider>();
//builder.Services.AddScoped<ITransactionHistory, TransactionHistoryProvider>();
//builder.Services.AddScoped<ITransactionHistory, TransactionHistoryProvider>();

builder.Services.AddScoped<ITransactionHistory, TransactionHistoryProvider>();




builder.Services.AddCors((setup) =>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();

    });
});


builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
