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

        [Required( ErrorMessage = " فیلد هزینه اجباری است "), Display(Name = "حقوق")]
        public int Wage { get; set; }

        [Required(ErrorMessage = " فیلد تاسیسات اجباری است "), Display(Name = "تاسیسات")]
        public int Maintenance { get; set; }

        [Required(ErrorMessage = " فیلد تاریخ اجباری است "), Display(Name = "تاریخ")]
        public DateTime Date { get; set; }

        [MaxLength(500, ErrorMessage = "حداکثر 500 کاراکتر مجاز است."), Display(Name = "توضیحات")]

        public string Description { get; set; }
    }
}