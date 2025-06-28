using PurcepellPartners.ApiService.Services;
using PurcepellPartners.ApiService.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Register MVC controllers
builder.Services.AddControllers();

// Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Services
builder.Services.AddSingleton<IInputValidator, InputValidator>();
builder.Services.AddSingleton<IMissingNumberSearchService, MissingNumberSearchService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();

