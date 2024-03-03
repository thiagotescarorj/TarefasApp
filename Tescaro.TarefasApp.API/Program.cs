using Tescaro.TarefasApp.API.Extensions;
using Tescaro.TarefasApp.Application.Extensions;
using Tescaro.TarefasApp.Infra.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting( x => x.LowercaseUrls = true);// URLS em caixa baixa
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc();
builder.Services.AddApplicationServices();
builder.Services.AddDataContext(builder.Configuration);

var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwaggerDoc();


app.UseAuthorization();

app.MapControllers();

app.Run();
