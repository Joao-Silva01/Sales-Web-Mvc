using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Sales_Web_Mvc.Data;
using Sales_Web_Mvc.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Sales_Web_MvcContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Sales_Web_MvcContext") 
    ?? throw new InvalidOperationException("Connection string 'Sales_Web_MvcContext' not found."),

    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Sales_Web_MvcContext")),
    b => b.MigrationsAssembly("Sales-Web-Mvc"))

    );
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordsService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//CultureInfo, Localization
var ciList = new List<CultureInfo>
{
    new CultureInfo("en-US"),
    new CultureInfo("pt-BR"),
    new CultureInfo("ja-JP")
};
var localizationOptions = new RequestLocalizationOptions
{
    SupportedCultures = ciList,
    SupportedUICultures = ciList,
    DefaultRequestCulture = new RequestCulture(ciList[0])
};
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using (var scope = app.Services.CreateScope()) 
    { 
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Sales_Web_MvcContext>();
    var seedingService = new SeedingService(context);
    seedingService.Seed(); }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
