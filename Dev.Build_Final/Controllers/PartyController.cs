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
        public void toggle()
        {
            planner myTask = new planner() { description = "test", done = false };          
                
            DAL.CompleteTask(myTask);
        }
    }
}
