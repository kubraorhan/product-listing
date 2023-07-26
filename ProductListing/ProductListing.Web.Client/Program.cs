
using Microsoft.EntityFrameworkCore;
using ProductListing.Data.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<EFContext>(opt =>
{
    opt.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ProductListingDB;User ID=sa;Password=sqlsa;MultipleActiveResultSets=True;Encrypt=False", opt =>
    {
        opt.EnableRetryOnFailure();
    });
    opt.EnableSensitiveDataLogging();
    
});
builder.Services.AddMvc(options =>
{
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<EFContext>();
    context.Database.EnsureCreated();
}

app.Run();
