var builder = WebApplication.CreateBuilder(args);
//Vai adicionar o serviço de controllers
builder.Services.AddControllers();
var app = builder.Build();

//Mapeia os controllers 
app.MapControllers();
app.Run();
