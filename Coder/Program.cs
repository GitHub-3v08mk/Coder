// Create and add services to the container
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); //Add Controllers
builder.Services.AddEndpointsApiExplorer(); //Add Swagger
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline
// Enable Swagger documentation
app.UseSwagger();
app.UseSwaggerUI();

//Redirect HTTP to HTTPS
//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Add controllers to API
app.MapControllers();

//Add paths for probes
app.MapGet("/status/liveness", async context =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Liveness OK");
});

app.MapGet("/status/readiness", async context =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Readiness OK");
});

app.MapGet("/status/startup", async context =>
{
    context.Response.StatusCode = 200;
    await context.Response.WriteAsync("Startup OK");
});

app.Run();