using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;

namespace Could_System_dev_ops.Repo
{
    public class FakeStaffRepo : IStaffRepositry

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
            };// test Data


            _staffPermissonsList = new List<StaffPermissonsModel>()
            {
                new StaffPermissonsModel() {StaffId = 1, ViewStocklevel = true, CanDeleteUser = false, CanHideReview = true, PurchaseRequest = false, ViewOrderList = true, ViewPendingOrders = true, ViewSetReSale= false, ViewUsers = true, AddStaff = false, ApproveStaffPurchase = false, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false},
                new StaffPermissonsModel() {StaffId = 2, ViewStocklevel = false, CanDeleteUser = false, CanHideReview = true, PurchaseRequest = false, ViewOrderList = false, ViewPendingOrders = false, ViewSetReSale= false, ViewUsers = true, AddStaff = false, ApproveStaffPurchase = false, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false},
                new StaffPermissonsModel() {StaffId = 3, ViewStocklevel = true, CanDeleteUser = true, CanHideReview = true, PurchaseRequest = true, ViewOrderList = true, ViewPendingOrders = true, ViewSetReSale= true, ViewUsers = true, AddStaff = true, ApproveStaffPurchase = true, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false}
            };// test Data
        }
        
        

        public StaffModel CreateStaff(StaffModel staff)
        {
            _staffModelsList.Add(staff); // adds StaffMdole to test data
            return staff; // returns new Staff
        }
        public StaffModel DeleteStaff(StaffModel staff)
        {
            _staffModelsList.Remove(_staffModelsList.FirstOrDefault(x => staff.StaffId == x.StaffId)); // finds first staff with given id then removes them form the fake data
            return staff; // returns deleted data
        }

        public StaffModel GetStaff(int? id)
        {
            return _staffModelsList.FirstOrDefault(x => id  == x.StaffId);
            // returns first in the list with the id that matches the id pasded threw when its call
        }

        public StaffModel EditStaff(StaffModel staff)
        {
            return _staffModelsList[_staffModelsList.IndexOf(_staffModelsList.FirstOrDefault(x => x.StaffId == staff.StaffId))] = staff;
            // get the index form the data where the id matches and then replaces it with the new staffmodel that gets passed through
        }

        public IEnumerable<StaffModel> GetAllStaff()
        {
            return _staffModelsList.AsEnumerable<StaffModel>();// returns all staff as IEnumerable
        }

        public StaffPermissonsModel CreateStaffPermissons(StaffPermissonsModel newStaffPermissions)
        {
            _staffPermissonsList.Add(newStaffPermissions);// adds new permissons
            return newStaffPermissions;// returns new permissons 
        }

        public StaffPermissonsModel DeleteStaffPermissions(StaffPermissonsModel permissonsModel)
        {
            _staffPermissonsList.Remove(_staffPermissonsList.FirstOrDefault(x => permissonsModel.StaffId == x.StaffId)); // finds first staff with given id then removes them form the fake data
            return permissonsModel;
        
        }

        public StaffPermissonsModel GetStaffPermissions(int id)
        {
            return _staffPermissonsList.FirstOrDefault(x => x.StaffId == id);
            // returns the staff permissons where the first id mtaches the id sent in when it called
        }

        public IEnumerable<StaffPermissonsModel> GetAllStaffPermissions()
        {
            return _staffPermissonsList.AsEnumerable<StaffPermissonsModel>();// gets all the permissions of for all staff returns as IEnumarable
        }

        public StaffPermissonsModel EditPermissions(StaffPermissonsModel permissonsModel)
        {    
            return _staffPermissonsList[_staffPermissonsList.IndexOf(_staffPermissonsList.FirstOrDefault(x => x.StaffId == permissonsModel.StaffId))] = permissonsModel;
            //gets the index for the data with the staff id form the permissons passed through then replaeces the index with the new one 
        }

    
    }
}
