using BlazorExpenseTracker.Services.Auth;
using BlazorExpenseTracker.Services.Data;
using BlazorExpenseTracker.Services.Data.MongoDb;
using BlazorExpenseTracker.Services.Data.MongoDb.Settings;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var app = BuildApp(args);
ConfigureApp(app);
app.Run();





static WebApplication BuildApp(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    builder.Services.AddMemoryCache();
    builder.Services.AddLocalization();
    builder.Services.AddMudServices();
    builder.Services.AddSpeechRecognition();

    // Auth services
    builder.Services.AddAuthenticationCore();
    builder.Services.AddScoped<AuthenticationStateProvider, ExpTrackerAuthenticationStateProvider>();
    builder.Services.AddSingleton<IExpTrackerAuthService, ExpTrackerAuthService>();

    // Data services - MongoDB
    builder.Services.Configure<ExpTrackerMongoDbSettings>(builder.Configuration.GetSection("ExpTrackerMongoDb"));
    builder.Services.AddSingleton<IUserDataService, UserMongoDbDataService>();
    builder.Services.AddSingleton<IExpenseDataService, ExpenseMongoDbDataService>();
    builder.Services.AddSingleton<ICategoryDataService, CategoryMongoDbDataService>();
    builder.Services.AddSingleton<IPaymentTypeDataService, PaymentTypeMongoDbDataService>();

    // Data services - In Memory
    ////builder.Services.AddSingleton<IUserDataService, UserInMemoryDataService>();
    ////builder.Services.AddSingleton<IExpenseDataService, ExpenseInMemoryDataService>();
    ////builder.Services.AddSingleton<ICategoryDataService, CategoryInMemoryDataService>();
    ////builder.Services.AddSingleton<IPaymentTypeDataService, PaymentTypeInMemoryDataService>();

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

    app.UseRequestLocalization(new RequestLocalizationOptions()
        .SetDefaultCulture("pt-BR")
        .AddSupportedCultures(new[] { "pt-BR" })
        .AddSupportedUICultures(new[] { "pt-BR" }));

    app.UseAuthorization();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
}