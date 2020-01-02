using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    public class StaffModel
    { 
      
        public int StaffId { get; set; }
        
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Email { get; set; }

        public double ContactNumber { get; set; }

        public double PayRoll { get; set; }
    }
}
