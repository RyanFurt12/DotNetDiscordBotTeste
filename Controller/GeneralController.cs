using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Discord.WebSocket;
using DotNetDiscordBotTeste.Data;
using DotNetDiscordBotTeste.Models;

namespace DotNetDiscordBotTeste.Controller
{
    public class GeneralController : BaseController
    {
        public GeneralController(DiscordSocketClient client, DataContext dbContext) : base(client, dbContext){}

        internal override Task HandleCommand(SocketMessage message)
        {
            
            Console.WriteLine("Cheguei aqui");

            return Task.CompletedTask;
        }

        public Task UpdateUser(){
            foreach(var guild in _client.Guilds)
            {
                Console.WriteLine($"Entrei no {guild.Name}");
                var isServerInDB = _dbContext.Servers.FirstOrDefault(s => s.Id == (long)guild.Id) != null;
                if(!isServerInDB)
                {
                    var newServer = new Server
                    {
                        Id = (long)guild.Id,
                        Name = guild.Name
                    };
                    _dbContext.Servers.Add(newServer);
                    Console.WriteLine($"Server ADD: {newServer.Name}");
                }

                
                foreach(var member in guild.Users)
                {
                    Console.WriteLine($"{guild.Users.Count} Usuarios");

                    var isUserInDB = _dbContext.Users.FirstOrDefault(u => u.Id == (long)member.Id && u.ServerId == (long)guild.Id) != null;
                    if(!isUserInDB){
                        var newUser = new User
                        {
                            IdDisc = (long)member.Id,
                            ServerId = (long)guild.Id,
                            UserName = member.Username
                        };
                        _dbContext.Users.Add(newUser);
                        Console.WriteLine($"User ADD: {newUser.UserName}");
                    }
                    return Task.CompletedTask;
                };
            }
            return Task.CompletedTask;
        
        }
    }
}