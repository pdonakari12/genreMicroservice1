using GenreMicroservice.DBContexts;
using GenreMicroservice.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
string CorsPolicy = "_corsPolicy";
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                       .AllowAnyMethod()
                                       .AllowAnyHeader();
                      });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json","Movies v1"));
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    }
app.UseStatusCodePages();
 app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(CorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();
