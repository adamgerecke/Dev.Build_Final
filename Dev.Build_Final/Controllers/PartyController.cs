using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dev.Build_Final.Models;
using Dev.Build_Final.Services;

namespace Dev.Build_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private IDAL DAL;
        public PartyController(IDAL DAL) {
            this.DAL = DAL;
        }

        [HttpGet]
        public IEnumerable<party> getParty()
        {
            return DAL.GetPartyList();
        }

        [HttpPost("check")]
        public void toggle(party desc)
        {       
                
            DAL.CompleteTask(desc);
        }

        [HttpGet("add")]
        public void addTask()
        {
            party myTask = new party() { description = "TEST DESCRIPTION", done = false };

            DAL.AddTask(myTask);
        }

        [HttpGet("remove")]
        public void removeTask()
        {
            party myTask = new party() { description = "TEST DESCRIPTION", done = false };

            DAL.RemoveTask(myTask);
        }


    }
}
