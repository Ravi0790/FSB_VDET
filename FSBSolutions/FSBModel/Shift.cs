﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class Shift
    {
        public int ShiftId { get; set; }

        public string ShiftName { get; set; }

        public DateTime ShiftStartTime { get; set; }

        public DateTime ShiftEndTime { get; set; }

        public int PlantId { get; set; }

        public virtual Plant Plant { get; set; }

        public bool Status { get; set; }
    }
}
