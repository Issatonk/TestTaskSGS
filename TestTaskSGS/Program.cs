using TestTaskSGS.Core;
using TestTaskSGS.Repository;
using TestTaskSGS.Repository.AutoMapperConfig;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<RepositoryMappingProfile>();
});
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://0c99f72ae9a0419ab5b4da753d2e4aaa@o4505063054901248.ingest.sentry.io/4505063058505728";
    o.Debug = true;
    o.TracesSampleRate= 1;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSentryTracing();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Ñurrencies}/{page}");

app.Run();
