using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev.Build_Final.Models;
using Dev.Build_Final.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Build_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {

        private IDAL DAL;
        public GiftController(IDAL DAL)
        {
            this.DAL = DAL;
        }

        [HttpGet]
        public IEnumerable<gift> GetGifts()
        {
            return DAL.GetPersonGifts();
        }

        [HttpPost("check")]
        public void toggle(party desc)
        {

            DAL.CompleteTask(desc);
        }

        [HttpPost("add")]
        public void addTask(party newEvent)
        {
            //party myTask = new party() { description = "TEST DESCRIPTION", done = false };

            DAL.AddTask(newEvent);
        }
    }
}
