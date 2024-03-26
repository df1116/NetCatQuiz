using Microsoft.AspNetCore.Mvc;
using NetCatQuiz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var catQuizApi = new CatQuizApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET API Endpoint to fetch a new instance of the Cat Quiz
app.MapGet("/catquiz", () => catQuizApi.GetCatQuiz())
    .WithName("GetCatQuiz")
    .WithOpenApi();

// POST API Endpoint to send results of the Cat Quiz
app.MapPost("/catquiz/{userId}/{correct}", ([FromRoute] string userId, [FromRoute] bool correct) =>
    {
        catQuizApi.GradeCatQuiz(userId, correct);
    })
    .WithName("GradeCatQuiz")
    .WithOpenApi();

// GET API Endpoint to fetch the leaderboard of the Cat Quiz
app.MapGet("/leaderboard", () => catQuizApi.GetLeaderboard())
    .WithName("GetLeaderboard")
    .WithOpenApi();

app.Run();