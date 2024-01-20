using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using DotNetDiscordBotTeste.Controller;
using DotNetDiscordBotTeste.Data;
using DotNetDiscordBotTeste.Models;
using DotNetEnv;

class Program
{
    static async Task Main(string[] args)
    {
        Env.Load();

        using var dbContext = new DataContext();
        dbContext.Database.EnsureCreated();

        var discordToken = Environment.GetEnvironmentVariable("DiscordToken");
        if(discordToken == null) return;

        await RunBotAsync(discordToken, dbContext);
    }

    static async Task RunBotAsync(string discordToken, DataContext dbContext)
    {

        var client = new DiscordSocketClient(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Debug
        });

        var commandHandler = new CommandHandler(client, dbContext);

        client.Log += (log) =>
        {
            Console.WriteLine($"{DateTime.Now} -> {log.Message}");
            return Task.CompletedTask;
        };

        client.Ready += () =>
        {       
            dbContext.SaveChanges();
            return Task.CompletedTask;
        };

        await client.LoginAsync(TokenType.Bot, discordToken);
        await client.StartAsync();

        await Task.Delay(-1);
    }
}



