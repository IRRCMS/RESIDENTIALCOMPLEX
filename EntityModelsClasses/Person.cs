using IRRCMS.EntityModelsClasses;
using IRRCMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IRRCMS
{
    public class Person
    {        
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "حداکثر ۵۰ کاراکتر مجاز است."),Display(Name ="نام")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "حداکثر ۵۰ کاراکتر مجاز است"),Display(Name ="نام خانوادگی")]
        public string Family { get; set; }
        [Index("IX_NationalCode",IsUnique =true)]
        [RegularExpression(@"^\d{10}$",ErrorMessage ="شماره ملی باید شامل ۱۰ رقم باشد"),Display(Name ="کد ملی")]
        [MaxLength(10)]
        public string NationalCode { get; set; }
        [MaxLength(1),Display(Name ="جنسیت")]
        public string Gender { get; set; }
        [Display(Name ="تلفن ثابت")]
        public string PhoneNumber { get; set; }
        //[Required,RegularExpression(@"^09\d{9}$",ErrorMessage ="تلفن همراه با ۰۹ آغاز میشود"),Display(Name ="تلفن همراه")]
        //[MaxLength(11)]
        //public string CellPhone { get; set; }
        //[EmailAddress,Display(Name ="تلفن همراه"),MaxLength(50)]
        //public string EmailAddress { get; set; }
        [Display(Name ="وضعیت تاهل"),MaxLength(10)]
        public string MartialStatus { get; set; }

        public virtual ICollection<BuildingUnit> BuildingUnits { get; set; }

        public ApplicationUser User { get; set; }
    }
}