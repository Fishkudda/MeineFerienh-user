using MeineFerienhäuser;
using MeineFerienhäuser.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Setze die statischen Werte der AppSettings-Klasse
AppSettings.DefaultImagePath = configuration["AppSettings:DefaultImagePath"];
AppSettings.DefaultHouseLink = configuration["AppSettings:DefaultHouseLink"];
AppSettings.FailImageText = configuration["AppSettings:FailImageText"];
AppSettings.FailHouseUrl = configuration["AppSettings:FailHouseUrl"];
AppSettings.UrlDaten = configuration["AppSettings:UrlDaten"];
AppSettings.BaseUrlHouse = configuration["AppSettings:BaseUrlHouse"];
AppSettings.BaseUrlLink = configuration["AppSettings:BaseUrlLink"];



// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await HouseFactory.Load();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
