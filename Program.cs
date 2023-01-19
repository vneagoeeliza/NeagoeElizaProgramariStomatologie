using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NeagoeElizaProgramariStomatologie.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Programari");
    options.Conventions.AuthorizeFolder("/Specializari");
    options.Conventions.AuthorizeFolder("/Medici");
    options.Conventions.AuthorizeFolder("/Proceduri");
    options.Conventions.AuthorizeFolder("/Pacienti");


    options.Conventions.AllowAnonymousToPage("/Medici/Index");
    options.Conventions.AllowAnonymousToPage("/Specializari/Index");
    options.Conventions.AllowAnonymousToPage("/Proceduri/Index");
});
builder.Services.AddDbContext<NeagoeElizaProgramariStomatologieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NeagoeElizaProgramariStomatologieContext") ?? throw new InvalidOperationException("Connection string 'NeagoeElizaProgramariStomatologieContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("NeagoeElizaProgramariStomatologieContext") ?? throw new InvalidOperationException("Connection string 'NeagoeElizaProgramariStomatologieContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
 .AddEntityFrameworkStores<LibraryIdentityContext>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
