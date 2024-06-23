using ProducerService.BLL;
using ProducerService.DAL;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IUserDAL, UserDAL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

