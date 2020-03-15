using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSBModel;

namespace FSBAPI.Models
{
    public class OrderVolumeList
    {
        public IList<OrderProducedVolume> OrderVolume { get; set; }
    }
}