//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR(cfg =>
//{
//    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();




var builder = WebApplication.CreateBuilder(args);

// Register controllers (one per slice)
builder.Services.AddControllers();

// Swagger/OpenAPI (for testing your vertical slices easily)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediatR - important for vertical slices
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Register Mapster (optional if using Mapster globally)
//TypeAdapterConfig.GlobalSettings.Scan(typeof(Program).Assembly);

var app = builder.Build();

// Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Basic middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// Map all controllers
app.MapControllers();

app.Run();
