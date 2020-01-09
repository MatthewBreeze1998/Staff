using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;

namespace Cloud_System_dev_ops.Repo
{
    public class FakeStaffRepo : IRepository<StaffModel>

    {

        private List<StaffModel> _staffModelsList;

        private List<StaffPermissionsModel> _staffPermissonsList;

  

        public FakeStaffRepo()
        {
            _staffModelsList = new List<StaffModel>()
            {
                new StaffModel() {StaffId = 1,FirstName = "cameron", LastName = "charlton", ContactNumber = "198237129", Email = "cam_puto@hotmail.co.uk", PayRoll = 23123123},
                new StaffModel() {StaffId = 2,FirstName = "sam", LastName = "el", ContactNumber = "192342123429", Email = "sma_fecal@hotmail.co.uk", PayRoll = 2325243},
                new StaffModel() {StaffId = 3,FirstName = "josh", LastName = "white", ContactNumber = "11212213129", Email = "josh_white@hotmail.co.uk", PayRoll =12533123}
            };// test Data


            _staffPermissonsList = new List<StaffPermissionsModel>()
            {
                new StaffPermissionsModel() {StaffPermissionsId = 1, StaffId = 1, Permission = "viewstocklevel" },
                new StaffPermissionsModel() {StaffPermissionsId = 2, StaffId = 1, Permission = "candeleteuser" },
                new StaffPermissionsModel() {StaffPermissionsId = 3,  StaffId = 2, Permission = "canhidereview"},
                new StaffPermissionsModel() {StaffPermissionsId = 4,  StaffId = 3, Permission = "purchaserequest"},
            };// ViewStocklevel = true, CanDeleteUser = true, CanHideReview = true, PurchaseRequest = true, ViewOrderList = true, ViewPendingOrders = true, ViewSetReSale= true, ViewUsers = true, AddStaff = true, ApproveStaffPurchase = true, authorisePermissons = false, RemoveStaff = false , SetPurchaseAbility = false
        }
        
        

        public StaffModel CreateObject(StaffModel staff)
        {
            staff.StaffId = GetNextId();
            _staffModelsList.Add(staff); // adds StaffMdole to test data
            return staff; // returns new Staff
        }
        
        
        public StaffModel DeleteObject(StaffModel staff)
        {
            _staffModelsList.Remove(_staffModelsList.FirstOrDefault(x => staff.StaffId == x.StaffId)); // finds first staff with given id then removes them form the fake data
            return staff; // returns deleted data
        }

        public StaffModel UpdateObject(StaffModel staff)
        {

            StaffModel inMemoryModel = _staffModelsList.FirstOrDefault(x => x.StaffId == staff.StaffId);

            if(inMemoryModel == null)
            {
                return null;
            }
            try
            {
                int index = _staffModelsList.IndexOf(inMemoryModel);
                _staffModelsList[index] = staff;
            }
            catch(Exception ex)
            {
                return null;
            }

            return _staffModelsList[_staffModelsList.IndexOf(_staffModelsList.FirstOrDefault(x => x.StaffId == staff.StaffId))] = staff;
            // get the index form the data where the id matches and then replaces it with the new staffmodel that gets passed through
        }

        public IEnumerable<StaffModel> GetObjects()
        {
            return _staffModelsList.AsEnumerable<StaffModel>();// returns all staff as IEnumerable
        }
        
        private int GetNextId()
        {
            return (_staffModelsList == null || _staffModelsList.Count() == 0) ? 1 : _staffModelsList.Max(x => x.StaffId) + 1;
        }
        public StaffPermissionsModel CreateStaffPermissons(StaffPermissionsModel newStaffPermissions)
        {
            _staffPermissonsList.Add(newStaffPermissions);// adds new permissons
            return newStaffPermissions;// returns new permissons 
        }

        public StaffPermissionsModel DeleteStaffPermissions(StaffPermissionsModel permissonsModel)
        {
            _staffPermissonsList.Remove(_staffPermissonsList.FirstOrDefault(x => permissonsModel.StaffId == x.StaffId)); // finds first staff with given id then removes them form the fake data
            return permissonsModel;
        
        }

        public StaffPermissionsModel GetStaffPermissions(int id)
        {
            return _staffPermissonsList.FirstOrDefault(x => x.StaffId == id);
            // returns the staff permissons where the first id mtaches the id sent in when it called
        }

        public IEnumerable<StaffPermissionsModel> GetAllStaffPermissions()
        {
            return _staffPermissonsList.AsEnumerable<StaffPermissionsModel>();// gets all the permissions of for all staff returns as IEnumarable
        }

        public StaffPermissionsModel EditPermissions(StaffPermissionsModel permissonsModel)
        {    
            return _staffPermissonsList[_staffPermissonsList.IndexOf(_staffPermissonsList.FirstOrDefault(x => x.StaffId == permissonsModel.StaffId))] = permissonsModel;
            //gets the index for the data with the staff id form the permissons passed through then replaeces the index with the new one 
        }

    
    }
}
