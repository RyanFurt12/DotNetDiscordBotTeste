using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDiscordBotTeste.Models
{
    public class Server
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}