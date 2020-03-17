﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAF.Model
{
    public class BorderCrossingPoint
    {
        [Key]
        public int BCPId { get; set; }
        public string BCPCode { get; set; }
        public int VillageId { get; set; }
        public string DistrictCode { get; set; }
        public string ProvinceCode { get; set; }
        public string NeighCountryCode { get; set; }
        public string EnName { get; set; }
        public string DrName { get; set; }
        public string PaName { get; set; }
        public bool IsActive { get; set; }
    }
}
