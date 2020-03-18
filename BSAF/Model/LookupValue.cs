﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Model
{
    public class LookupValue
    {
        [Key]
        public int ValueId { get; set; }
        [Required]
        public string LookupCode { get; set; }
        [Required]
        public string ValueCode { get; set; }
        [Required]
        public string EnName { get; set; }
        [Required]
        public string DrName { get; set; }
        [Required]
        public string PaName { get; set; }

        public string ForOrdering { get; set; }

        public int? GroupValueId { get; set; }

        public bool IsActive { get; set; }
    }
}