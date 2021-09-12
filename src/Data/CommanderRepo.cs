
using System.Collections;
using System.Collections.Generic;

namespace Commander.model
{
    public interface CommanderRepo
    {
        Command GetCommanderById(int id);
        IEnumerable<Command> GetAppCommands();

        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
        bool SavingChanges();
    }
}