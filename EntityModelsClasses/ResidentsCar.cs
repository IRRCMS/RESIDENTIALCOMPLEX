using IRRCMS.EntityModelsClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCMS
{
    public class ResidentsCar
    {
        public int Id { get; set; }
        //TODO: set a placeholder for the regularexpression plaque 
        [ MaxLength(10), Display(Name = "شماره پلاک"),RegularExpression(@"^\d{2}\w{1}\d{3}IR\d{2}$")]
        public string LicensePlateNumber { get; set; }

        //This property is defined as ForeinKey of Resident with fluent API.
        public int Resident_Id { get; set; }
        public Resident Resident { get; set; }
        

    }
}