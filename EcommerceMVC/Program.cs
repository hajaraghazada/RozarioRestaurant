
using Business.Abstract;
using Business.Concrete;
using Core.DataRepositories.Abstract;
using Core.DataRepositories.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RozarioContext>(options => options.UseSqlServer("Server=DESKTOP-04AMR15;Database=MyRozarioDb;Trusted_Connection = true;TrustServerCertificate=True;"));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWork, EFUnitofWork>();

builder.Services.AddScoped<IArchiveService, ArchiveManager>();
builder.Services.AddScoped< ICategoryService, CategoryManager>();
builder.Services.AddScoped<IFeedBackService, FeedBackManager>();
builder.Services.AddScoped<IGalleryItemService, GalleryItemManager>();
builder.Services.AddScoped<IMenuItemService, MenuItemManager>();
builder.Services.AddScoped<IPostService, PostManager>();
builder.Services.AddScoped<IReservationService, ReservationManager>();
builder.Services.AddScoped<ITagService, TagManager>();
builder.Services.AddScoped<ITeamService, TeamManager>();




var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
