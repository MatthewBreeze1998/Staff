using Cloud_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Repo
{
    public interface IStaffRepositry
    {
        StaffModel DeleteStaff(StaffModel staff);
       
        StaffModel CreateStaff(StaffModel staff);
        
        StaffModel GetStaff(int? id);

        StaffModel EditStaff(StaffModel staff);

        IEnumerable<StaffModel> GetAllStaff();

        StaffPermissionsModel CreateStaffPermissons(StaffPermissionsModel newStaffPermissions);

        StaffPermissionsModel EditPermissions(StaffPermissionsModel permissonsModel);

        StaffPermissionsModel DeleteStaffPermissions(StaffPermissionsModel permissonsModel);

        StaffPermissionsModel GetStaffPermissions(int id);

        IEnumerable<StaffPermissionsModel> GetAllStaffPermissions();
    }
}
