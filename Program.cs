using aspnet.Data;
using Microsoft.EntityFrameworkCore;



// This line creates a WebApplication instance using the CreateBuilder method, which is a builder pattern for setting up the application.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MVCDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MvcConnectionString")));


// build web application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// This line adds middleware to redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();
// This line adds middleware to serve static files such as CSS, JavaScript, and images from the wwwroot folder.
app.UseStaticFiles();

// This line adds middleware for routing requests to the appropriate endpoint.
app.UseRouting();

// This line adds middleware for handling authorization, allowing you to secure certain parts of your application.
app.UseAuthorization();

// This line configures a default route for MVC controllers. It specifies the pattern of the URL and maps it to a specific controller and action.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// This line starts the application and listens for incoming HTTP requests. 
app.Run();
