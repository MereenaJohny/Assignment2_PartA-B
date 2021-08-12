using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP380_B2_BlockWebAPI.Models
{
    public class BlockSummary
    {
        public DateTime TimeStamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }

        public BlockSummary()
        {

        }

        public BlockSummary(DateTime TimeStamp, string PreviousHash, string Hash)
        {
            this.TimeStamp = TimeStamp;
            this.PreviousHash = PreviousHash;
            this.Hash = Hash;
        }
    }
}
