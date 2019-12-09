using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeStaffRepo : StaffRepo

    {

        private List<StaffModel> _staffModelsList;

        private List<StaffPermissonsModel> _staffPermissonsList;

  

        public FakeStaffRepo()
        {
            _staffModelsList = new List<StaffModel>()
            {
                new StaffModel() {StaffId = 1,FirstName = "cameron", LastName = "charlton", ContactNumebr = 198237129, Email = "cam_puto@hotmail.co.uk", PayRoll = 23123123},
                new StaffModel() {StaffId = 2,FirstName = "sam", LastName = "el", ContactNumebr = 192342123429, Email = "sma_fecal@hotmail.co.uk", PayRoll = 2325243},
                new StaffModel() {StaffId = 3,FirstName = "josh", LastName = "white", ContactNumebr = 11212213129, Email = "josh_white@hotmail.co.uk", PayRoll =12533123}
            };


            _staffPermissonsList = new List<StaffPermissonsModel>()
            {
                new StaffPermissonsModel() {StaffId = 1, ViewStocklevel = true, CanDeleteUser = false, CanHideReview = true, PurchaseRequest = false, ViewOrderList = true, ViewPendingOrders = true, ViewSetReSale= false, ViewUsers = true, AddStaff = false, ApproveStaffPurchase = false, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false},
                new StaffPermissonsModel() {StaffId = 2, ViewStocklevel = false, CanDeleteUser = false, CanHideReview = true, PurchaseRequest = false, ViewOrderList = false, ViewPendingOrders = false, ViewSetReSale= false, ViewUsers = true, AddStaff = false, ApproveStaffPurchase = false, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false},
                new StaffPermissonsModel() {StaffId = 3, ViewStocklevel = true, CanDeleteUser = true, CanHideReview = true, PurchaseRequest = true, ViewOrderList = true, ViewPendingOrders = true, ViewSetReSale= true, ViewUsers = true, AddStaff = true, ApproveStaffPurchase = true, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false}
            };
        }
        
        

        public StaffModel CreateStaff(StaffModel staff)
        {
            _staffModelsList.Add(staff);
            return staff;
        }
        public StaffModel DeleteStaff(StaffModel staff)
        {
           
            _staffModelsList.Remove(_staffModelsList.FirstOrDefault(x => staff.StaffId == x.StaffId));
            return staff;

        }

        public StaffModel GetStaff(StaffModel staff)
        {
            
            return _staffModelsList.FirstOrDefault(x => staff.StaffId == x.StaffId);
        }

        public StaffModel EditStaff(StaffModel staff)
        {
            _staffModelsList[_staffModelsList.IndexOf(_staffModelsList.FirstOrDefault(x => x.StaffId == staff.StaffId))] = staff;
            return staff;
        }

        
        
    
        public IEnumerable<StaffModel> GetStaff()
        {
            return _staffModelsList.AsEnumerable<StaffModel>();
        }

        private List<UsersModel> _UserList;
        public UsersModel SetPurchaseAbility(int id)
        {    
            UsersModel activity = _UserList.FirstOrDefault(x => id == x.UserId);

            activity.PurchaseAbility = !activity.PurchaseAbility;
            _UserList.Insert(_UserList.IndexOf(_UserList.FirstOrDefault(x => id == x.UserId)), activity);
            return activity;
        }

        public StaffPermissonsModel GetStaffPermissions(StaffPermissonsModel permissons)
        {
            return _staffPermissonsList.FirstOrDefault(x => x.StaffId == permissons.StaffId);
        }

        public IEnumerable<StaffPermissonsModel> GetStaffPermissions(int? StaffId, Boolean CanDeleteUser, Boolean CanHideReview, Boolean SetPurchaseAbility, Boolean ViewUsers, Boolean ViewOrderList, Boolean ViewPendingOrders, Boolean ViewSetReSale, Boolean PurchaseRequest, Boolean ViewStocklevel, Boolean AddStaff, Boolean RemoveStaff, Boolean authorisePermissons, Boolean ApproveStaffPurchase)
        {
            return _staffPermissonsList.AsEnumerable<StaffPermissonsModel>();
        }
    }
}
