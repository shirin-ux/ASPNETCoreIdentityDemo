using ASPNETCoreIdentityDemo_Application.IServices;
using Domain_AspNet_Identity.Entities;
using Domain_AspNet_Identity.IRepository;
using Infrastracture_Asp.Net_Identity;
using Infrastracture_Asp.Net_Identity.ExternalService;
using Infrastracture_Asp.Net_Identity.Identity;
using Infrastracture_Asp.Net_Identity.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();//برای قابلیتهای مثل تایید ایمیل و رمز عبور و توکن


builder.Services.AddHttpClient("SmsApiClient", client =>
{
    client.BaseAddress = new Uri("https://api.melipayamak.com/v1/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization(); 
app.MapControllers();
app.UseDeveloperExceptionPage();

app.Run();
