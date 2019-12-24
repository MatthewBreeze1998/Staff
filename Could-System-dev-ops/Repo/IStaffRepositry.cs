using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface IStaffRepositry
    {
        StaffModel DeleteStaff(StaffModel staff);
       
        StaffModel CreateStaff(StaffModel staff);
        
        StaffModel GetStaff(int? id);

        StaffModel EditStaff(StaffModel staff);

        IEnumerable<StaffModel> GetAllStaff();

        StaffPermissonsModel CreateStaffPermissons(StaffPermissonsModel newStaffPermissions);

        StaffPermissonsModel EditPermissions(StaffPermissonsModel permissonsModel);

        StaffPermissonsModel DeleteStaffPermissions(StaffPermissonsModel permissonsModel);

        StaffPermissonsModel GetStaffPermissions(int id);

        IEnumerable<StaffPermissonsModel> GetAllStaffPermissions();
    }
}
