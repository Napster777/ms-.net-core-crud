using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetMngApi.Models
{
    public class Assets
    {
        [Key]
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetDesc { get; set; }
        public int Stock { get; set; }

    }
}
