using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Dev.Build_Final.Models
{
    [Table("planner")]
    public class planner
    {
        public string description { get; set; }
        public bool done { get; set; }
    }
}
