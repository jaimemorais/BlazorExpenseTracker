using BlazorExpenseTracker.Services.Auth;
using BlazorExpenseTracker.Services.Data;
using BlazorExpenseTracker.Services.Data.InMemory;
using Microsoft.AspNetCore.Components.Authorization;



var app = BuildApp(args);
ConfigureApp(app);
app.Run();





static WebApplication BuildApp(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

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

    return builder.Build();
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