using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using DotNetDiscordBotTeste.Data;

namespace DotNetDiscordBotTeste.Controller
{
    public abstract class BaseController(DiscordSocketClient client, DataContext dbContext)
    {
        protected readonly DiscordSocketClient _client = client;
        protected readonly DataContext _dbContext = dbContext;

        abstract internal Task HandleCommand(SocketMessage message);

    }
}