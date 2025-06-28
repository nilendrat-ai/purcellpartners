using PurcepellPartners.ApiService.Services;
using PurcepellPartners.ApiService.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Register Services
builder.Services.AddSingleton<IInputValidator, InputValidator>();
builder.Services.AddSingleton<IMissingNumberSearchService, MissingNumberSearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/missing", (IMissingNumberSearchService finder, ILogger<Program> logger) =>
{
    int[] nums = new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
    logger.LogInformation("Received request for missing number.");

    int missing = finder.FindMissingNumber(nums);

    return Results.Ok(new { Input = nums, Missing = missing });
});

app.MapDefaultEndpoints();

app.Run();

