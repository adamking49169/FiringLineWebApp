

var builder = WebApplication.CreateBuilder(args);




//  Add MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// (Optional) keep Razor Pages so /Identity pages still work
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error"); // (or keep "/Error" if you have that Razor Page)
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


// Default MVC route: "/" => HomeController.Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
