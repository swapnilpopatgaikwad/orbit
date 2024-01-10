﻿namespace AirHockey.GameObjects;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterGameObjects(this IServiceCollection services) =>
        services
            .AddTransient<OpponentPaddle>()
            .AddTransient<Paddle>()
            .AddTransient<Puck>()
            .AddTransient<ScoreDisplay>();
}
