using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetDiscordBotTeste.Models
{
    public class User
    {
        public User()
        {
            Id = 0;
            Score = 0;
        }

        [Key]
        public long Id { get; set; }

        public long IdDisc { get; set; }
        public long ServerId { get; set; }
        public required string UserName { get; set; }
        public int Score { get; set; }
    }
}