using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCMS.EntityModelsClasses
{
    public class Resident
    {
        public int Id { get; set; }
        [Required, Display(Name = "شماره واحد")]
        public int UnitId { get; set; }
        [Required, Display(Name = "شماره ساکن")]
        public int PersonId { get; set; }
        [Required, Display(Name = "تعداد ساکنین")]
        public int Numofoccupants { get; set; }
        public virtual Person Person { get; set; }
        public List<BuildingUnit> Units { get; set; }
    }
}