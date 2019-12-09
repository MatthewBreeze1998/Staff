using Could_System_dev_ops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Could_System_dev_ops.Repo
{
    public interface StaffRepo

    {
        

        

        //  IEnumerable<Models.StaffPermissonsModel> GetStaffPermissions(int? StaffId, Boolean CanDeleteUser, Boolean CanHideReview, Boolean SetPurchaseAbility,Boolean ViewUsers, Boolean ViewOrderList, Boolean ViewPendingOrders, Boolean ViewSetReSale, Boolean PurchaseRequest, Boolean ViewStocklevel, Boolean AddStaff, Boolean RemoveStaff, Boolean authorisePermissons, Boolean ApproveStaffPurchase);

        //  StaffModel GetStaff(int? id);

        //   UsersModel SetPurchaseAbility(int id);

        //  IEnumerable<Models.StaffModel> GetStaffAll();

        ///StaffModel EditStaff(StaffModel staff);


        StaffModel DeleteStaff(StaffModel staff);
       
        StaffModel CreateStaff(StaffModel staff);
        
        StaffModel GetStaff(StaffModel staff);

        StaffModel EditStaff(StaffModel staff);

        IEnumerable<Models.StaffModel> GetStaff();

        StaffPermissonsModel GetStaffPermissions(StaffPermissonsModel permissons);
    }
}
