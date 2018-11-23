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
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}