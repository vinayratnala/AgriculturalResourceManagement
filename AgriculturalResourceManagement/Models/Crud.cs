using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace AgriculturalResourceManagement.Models
{

    public class Timing1
    {
        [Key]
        public int executing { get; set; }
        public string unit { get; set; }
    }

    public class Total1
    {
        [Key]
        public int record_count { get; set; }
    }

    public class Info1
    {
        public Timing timing { get; set; }
        [Key]
        public string result_coverage { get; set; }
        public Total total { get; set; }
    }

    public class Report1
    {
        [Key]

        public int id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string desc { get; set; }
    }

    public class Reports1
    {
        [Key]
        public string status { get; set; }
        public Info info { get; set; }
        public List<Report> data { get; set; }
    }
}