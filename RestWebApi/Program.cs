using RestWebApi;
using RestWebApi.Contracts;
using RestWebApi.Options;
using RestWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProductRepository,MockForCourseProductRepository>();
builder.Services.AddControllers();
builder.Services.Configure<UnitOptions>(builder.Configuration.GetSection("Units"));
builder.Services.AddScoped<ITransientService, ScopedService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
