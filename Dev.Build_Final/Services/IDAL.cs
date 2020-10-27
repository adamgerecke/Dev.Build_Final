using Dev.Build_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Build_Final.Services
{
    public interface IDAL
    {
        IEnumerable<party> GetPartyList();

        void RemoveTask(party myTask);

        void AddTask(party myTask);

        void CompleteTask(party myTask);
    }
}
