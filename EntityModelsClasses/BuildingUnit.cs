using IRRCMS.EntityModelsClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IRRCMS
{
    public class BuildingUnit
    {
        public int Id { get; set; }
        [Required,Display(Name ="مساحت")]
        public float Area { get; set; }
        [Display(Name = "شماره واحد")]
        public string UnitNo { get; set; }

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
        
        public int OwnerId { get; set; }
        public ICollection<Person> Owners { get; set; }

        public int ResidentId { get; set; }
        public ICollection<Resident> Residents { get; set; }
    }
}