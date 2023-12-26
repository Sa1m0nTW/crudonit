using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crudonit.Data;
using Microsoft.AspNetCore.Components.Forms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<crudonitContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("crudonitContext") ?? throw new InvalidOperationException("Connection string 'crudonitContext' not found.")));

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<crudonitContext>();
context.Database.Migrate();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
