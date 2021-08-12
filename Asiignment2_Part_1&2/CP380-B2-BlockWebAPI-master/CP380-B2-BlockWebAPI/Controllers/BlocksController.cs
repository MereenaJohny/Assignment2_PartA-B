using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {

        [HttpGet("/Blocks")]
        public string GetAllBlocks()
        {
            BlockList blockList = new BlockList();
            List<BlockSummary> blockSummaryList = new List<BlockSummary>();
            for(int i = 0; i < blockList.Chain.Count; i++)
            {
                BlockSummary summary = new BlockSummary();
                summary.TimeStamp = blockList.Chain[i].TimeStamp;
                summary.PreviousHash = blockList.Chain[i].PreviousHash;
                summary.Hash = blockList.Chain[i].Hash;
                blockSummaryList.Add(summary);
            }
            return JsonConvert.SerializeObject(blockSummaryList);
        }

        [HttpGet("/Blocks/{hash?}")]
        public string GetAllBlocks(int hash)
        {
            Block block = null;
            BlockList blockList = new BlockList();
            if (hash < blockList.Chain.Count)
                block = blockList.Chain[hash];
            if (block == null)
                return JsonConvert.SerializeObject(NotFound());
            return JsonConvert.SerializeObject(block);
        }

        [HttpGet("/Blocks/{hash?}/Payloads")]
        public string GetAllPayloads(int hash)
        {
            Block block = null;
            BlockList blockList = new BlockList();
            if (hash < blockList.Chain.Count)
                block = blockList.Chain[hash];
            return JsonConvert.SerializeObject(block.Data);
        }

    }
}
