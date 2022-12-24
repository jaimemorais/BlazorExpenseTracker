using BlazorExpenseTracker.Domain.Services;
using BlazorExpenseTracker.Domain.Services.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IExpenseDataService, ExpenseDataServiceInMemory>();
builder.Services.AddSingleton<ICategoryDataService, CategoryDataServiceInMemory>();
builder.Services.AddSingleton<IPaymentTypeDataService, PaymentTypeDataServiceInMemory>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
