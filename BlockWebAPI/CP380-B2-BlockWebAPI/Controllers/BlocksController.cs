using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        // TODO

        private BlockList _blockList;

        public BlocksController(BlockList blockList)
        {
            _blockList = blockList;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_blockList.Chain.Select(block => new BlockSummary()
            {
                Hash = block.Hash,
                PreviousHash = block.PreviousHash,
                TimeStamp = block.TimeStamp
            }));
        }

        [HttpGet]
        [Route("{hash}")]
        public IActionResult GetBlock(string hash)
        {
            var block = _blockList.Chain
                .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => new BlockSummary()
                    {
                        Hash = block.Hash,
                        PreviousHash = block.PreviousHash,
                        TimeStamp = block.TimeStamp
                    }
                    )
                    .First());
            }

            return NotFound();
        }

        [HttpGet]
        [Route("{hash}/Payloads")]
        public IActionResult GetBlockPayload(string hash)
        {
            var block = _blockList.Chain
                        .Where(block => block.Hash.Equals(hash));

            if (block != null && block.Count() > 0)
            {
                return Ok(block
                    .Select(block => block.Data
                    )
                    .First());
            }

            return NotFound();
        }
    }
}
