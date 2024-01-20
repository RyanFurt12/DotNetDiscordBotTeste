using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using DotNetDiscordBotTeste.Data;

namespace DotNetDiscordBotTeste.Controller
{
    public class CommandHandler
    {
        private readonly List<BaseController> _controllers;

        public CommandHandler(DiscordSocketClient client, DataContext dbContext)
        {
            _controllers = new List<BaseController>
            {
                new GeneralController(client, dbContext),
            };
        }

        public async Task HandleCommand(SocketMessage message)
        {
            foreach (var controller in _controllers)
            {
                await controller.HandleCommand(message);
            }
        }
    }
}