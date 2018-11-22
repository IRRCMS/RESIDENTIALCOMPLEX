using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCMS.EntityModelsClasses
{
    public class Cost
    {
        public int Id { get; set; }

        [Required, Display(Name = "حقوق")]
        public int Wage { get; set; }

        [Required, Display(Name = "تاسیسات")]
        public int Maintenance { get; set; }

        [Required, Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        [MaxLength(500), Display(Name = "توضیحات")]

        public string Description { get; set; }
    }
}