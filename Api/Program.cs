using Data;

var Origin = "";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: Origin, policy =>
	{
		policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

    });
});
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ApplicationDbContext.ConnectionString = builder.Configuration.GetConnectionString("ApplicationDbContext");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(Origin);

app.MapControllers();

app.Run();
