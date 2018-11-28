using IRRCMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IRRCMS.EntityModelsClasses
{
    public class Resident
    {
        
        public int Id { get; set; }        

        [Required(ErrorMessage = " فیلد تعداد ساکنین اجباری است "), Display(Name = "تعداد ساکنین")]
        public int NumOfOccupants { get; set; }


        //This property is defined as ForeinKey of ApplicationUser with fluent API.
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }

        //This property is defined as ForeinKey of BuildingUnit with fluent API.
        public int BuildingUnit_Id { get; set; }
        public BuildingUnit BuildingUnit { get; set; }

        public ICollection<ResidentsCar> ResidentsCars { get; set; }
    }
}