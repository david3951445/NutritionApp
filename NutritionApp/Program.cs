using Microsoft.EntityFrameworkCore;
using NutritionApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddDbContextFactory<SamplesContext>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapDefaultControllerRoute();

// Initialize the database
// var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
// using (var scope = scopeFactory.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<SampleStoreContext>();
//     if (db.Database.EnsureCreated())
//     {
//         SeedData.Initialize(db);
//     }
// }

app.Run();
