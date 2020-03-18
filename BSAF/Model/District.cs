﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Model
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public int DistrictCode { get; set; }
        public string ProvinceCode { get; set; }
        public string EnName { get; set; }
        public string DrName { get; set; }
        public string PaName { get; set; }
        public bool IsActive { get; set; }
    }
}