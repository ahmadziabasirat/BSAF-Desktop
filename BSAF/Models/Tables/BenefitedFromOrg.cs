namespace BSAF.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BenefitedFromOrg
    {
        public int ID { get; set; }

        public int BeneficiaryID { get; set; }

        public DateTime Date { get; set; }

        public string ProvinceCode { get; set; }

        public string DistrictID { get; set; }

        public string Village { get; set; }

        [Required]
        public string OrgCode { get; set; }

        public string AssistanceProvided { get; set; }
    }
}
