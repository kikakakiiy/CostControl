using CostControl.Data;
using Microsoft.EntityFrameworkCore;
using CostControl.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7170/"); // cek port di launchSettings.json
});


// Register DbContext
builder.Services.AddDbContext<DashboardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger (API Docs)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

// Routing untuk API
app.MapControllers();

// Routing untuk MVC (Dashboard)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
