using FinanceTracker.Data;
using FinanceTracker.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// ✅ DB bağlantısı (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Controller desteği
builder.Services.AddControllers();

string localIp = Dns.GetHostEntry(Dns.GetHostName())
    .AddressList
    .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
    .ToString();

builder.WebHost.UseUrls($"http://{localIp}:5000");

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Redis bağlantısı
var options = ConfigurationOptions.Parse($"{localIp}:6379");
options.AbortOnConnectFail = false;
var redis = ConnectionMultiplexer.Connect(options);
builder.Services.AddSingleton<IConnectionMultiplexer>(redis);

// ✅ Currency Service
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

var app = builder.Build();

// ✅ Swagger UI sadece Development ortamında çalışsın
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// ✅ Controller route'larını kullan
app.MapControllers();

app.Run();
