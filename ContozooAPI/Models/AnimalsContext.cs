using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContozooAPI.Models
{
    public class AnimalsContext : DbContext
    {
        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }

        public DbSet<ContozooAPI.Models.Animals> Animals { get; set; }
    }
}
