using IRRCMS.EntityModelsClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCMS
{
    public class BuildingUnit
    {
        public int Id { get; set; }
        [Required]
        public float Area { get; set; }

        private int monthlyCharge;
        [Display(Name ="شارژ ماهیانه")]
        public int MonthlyCharge
        {
            get { return monthlyCharge; }
            private set
            {
                var x = 1000;
                monthlyCharge = x*Convert.ToInt32(Area);
            }
        }
        private int payment;
        [Display(Name ="پرداختی")]        
        public int Payment
        {
            get
            {
                if (payment ==null)
                {
                    return 0;
                }
                return payment;
            }
            set { payment = value; }
        }


        private bool paymentStatus;
                            
        public bool PaymentStatus
        {
            get { return paymentStatus; }
            private set
            {
                if (MonthlyCharge-Payment<=0)
                {
                    paymentStatus = true;
                }
                else
                {
                    paymentStatus = false;
                }                
            }
        }
        public ICollection<Person> Owners { get; set; }
        public Resident Resident { get; set; }
    }
}