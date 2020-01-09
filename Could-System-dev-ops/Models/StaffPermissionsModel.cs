using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{ 
    [Table("StaffPermissions")]
    public class StaffPermissionsModel
    {
        [Key]
        public int StaffPermissionsId { get; set; }

        public int StaffId { get; set; }
        
        public string Permission { get; set; } 

    }
}
