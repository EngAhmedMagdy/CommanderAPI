
using System.Collections.Generic;
using System.Linq;
namespace Commander.model
{
    public class SqlServerCommanderRepo : CommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlServerCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            _context.Commanders.Add(cmd);
            
        }

        public void DeleteCommand(Command cmd)
        {
           _context.Commanders.Remove(cmd);
        }

        public IEnumerable<Command> GetAppCommands()
        {
            return _context.Commanders.ToList();
        }

        public Command GetCommanderById(int id)
        {
            return _context.Commanders.FirstOrDefault(c => c.Id == id);
        }

        public bool SavingChanges()
        {
           return ( _context.SaveChanges() >= 0 );
        }

        public void UpdateCommand(Command cmd)
        {
           //nothing
        }
    }
}