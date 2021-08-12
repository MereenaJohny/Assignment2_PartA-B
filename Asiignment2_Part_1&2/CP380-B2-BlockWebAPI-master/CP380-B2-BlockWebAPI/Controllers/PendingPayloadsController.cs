using CP380_B2_BlockWebAPI.Models;
using CP380_B1_BlockList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        public object DependencyManager { get; private set; }

        [HttpGet("/PendingPayloads")]
        public string GetLatestBlocks()
        {
            BlockList blockList = new BlockList();
            var blocks = blockList.Chain;
            return JsonConvert.SerializeObject(blocks);
        }

        [HttpPost("/PendingPayloads")]
        public void AddTransaction(int val)
        {
            BlockList blockList = new BlockList();
            var d = HttpContext.Request.ReadFromJsonAsync<Payload>();
            if (d != null && d.Result != null)
                blockList.AddTransaction(d.Result, val);
        }
    }
}
