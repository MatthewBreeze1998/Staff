using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    [Table("Staff")]
    public class StaffModel
    {
        [Key]
        public int StaffId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        public double PayRoll { get; set; }

        public ICollection<StaffPermissionsModel> PermissionModels { get; set; }
    
    }

}
