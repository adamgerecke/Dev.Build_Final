using Dev.Build_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Build_Final.Services
{
    public interface IDAL
    {
        IEnumerable<planner> GetList();

        void RemoveTask(planner myTask);

        void AddTask(planner myTask);

        void CompleteTask(planner myTask);
    }
}
