using Microsoft.EntityFrameworkCore;

namespace Commander.model
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {
            
        }
        public DbSet<Command> Commanders {get;set;}
    }
}