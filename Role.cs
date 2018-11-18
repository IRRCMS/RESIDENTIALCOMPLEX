using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IRRCMS
{
    public class Role
    {
        [ MaxLength(50), Display(Name = "مدیر")]
        public string Admin { get; set; }
        [MaxLength(50), Display(Name = "کاربر")]
        public string User { get; set; }
    }
}