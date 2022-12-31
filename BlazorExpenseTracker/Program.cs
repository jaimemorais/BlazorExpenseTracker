using BlazorExpenseTracker.Services.Auth;
using BlazorExpenseTracker.Services.Data;
using BlazorExpenseTracker.Services.Data.InMemory;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);
ConfigureDependencies(builder);
var app = builder.Build();
ConfigureApp(app);
app.Run();





static void ConfigureDependencies(WebApplicationBuilder builder)
{
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();


    // Auth services
    builder.Services.AddAuthenticationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, ExpTrackerAuthenticationStateProvider>();
    builder.Services.AddSingleton<IExpTrackerAuthService, ExpTrackerAuthService>();

    // Data services
    builder.Services.AddSingleton<IUserDataService, UserDataServiceInMemory>();
    builder.Services.AddSingleton<IExpenseDataService, ExpenseDataServiceInMemory>();
    builder.Services.AddSingleton<ICategoryDataService, CategoryDataServiceInMemory>();
    builder.Services.AddSingleton<IPaymentTypeDataService, PaymentTypeDataServiceInMemory>();
}



static void ConfigureApp(WebApplication app)
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
}