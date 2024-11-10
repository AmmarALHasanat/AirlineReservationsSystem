using AirlineReservationsSystem.Application.Interfaces;
using AirlineReservationsSystem.Application.Services;
using AirlineReservationsSystem.Domain.Entities;
using AirlineReservationsSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
//Infrastructure

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(connectionString) 
    );
builder.Services.AddIdentity<User, IdentityRole>
    (options =>{
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric =false;
        // options.SignIn.RequireConfirmedAccount = true
    }).AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>{
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
        googleOptions.CallbackPath = "/account/signin-google";
    });

builder.Services.AddAuthorization(options =>
    {
        //options.FallbackPolicy = new AuthorizationPolicyBuilder()
        //.RequireAuthenticatedUser().Build();

        options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
    });


// Add Scoped
builder.Services.AddScoped<IAirplaneeService, AirplaneeService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITravelRouteService, TravelRouteService>();
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
