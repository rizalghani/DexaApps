using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DexaApps.Models
{
    public class Outlets
    {
        [Key]
        [Display(Name = "Outlet ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OutletID { get; set; }

        [Required]
        [Display(Name = "Outlet Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string OutletName { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
