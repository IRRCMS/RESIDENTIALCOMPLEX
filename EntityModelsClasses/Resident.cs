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
        [ForeignKey("Person")]
        public int ResidentId { get; set; }

        [Required, Display(Name = "تعداد ساکنین")]
        public int NumOfOccupants { get; set; }

        public virtual Person Person { get; set; }

        public List<BuildingUnit> Units { get; set; }
        [ForeignKey("Units")]
        public int BuildingUnitId { get; set; }
    }
}