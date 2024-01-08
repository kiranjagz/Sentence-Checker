using Sentence.Checker.Api.Facade.SentenceChecker;
using Sentence.Checker.Api.Facade.SentenceChecker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISentenceCheckerFacade, SentenceCheckerFacade>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/sentence", () =>
{
    var ping = "Pong!";

    return Results.Ok(ping);
})
.WithName("ping");

app.MapPost("/sentence", async (ISentenceCheckerFacade sentenceCheckerFacade, SentenceCheckerRequest sentenceCheckerRequest) =>
{
    var result = await sentenceCheckerFacade
        .ValidateSentence(sentenceCheckerRequest);

    return Results.Ok(result);
})
.WithName("validate");

app.Run();