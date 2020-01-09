using Cloud_System_dev_ops.Controllers;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Cloud_System_dev_ops.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ControllerTest
{
    public class StaffControllerTest
    {
        private HttpClient _client;
        private IRepository<StaffModel> _staffRepo;
        private IUserService _userRepo;
        private StaffController _staffController;
        private List<StaffModel> _staffModelsList;
        private List<StaffPermissionsModel> _staffPermissonsList;

        public StaffControllerTest()
        {
            _client = new HttpClient();
        }

        [SetUp]
        public void Setup()
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
            };// test Data

            _staffRepo = new FakeStaffRepo();
            _userRepo = new FakeSuccessUserService();
            _staffController = new StaffController(_staffRepo, _userRepo);
            

        }

        [Test]
        public void CreateProduct_valid_object()
        {
            Assert.IsNotNull(_staffRepo);// not null repo
            Assert.IsNotNull(_staffController);// not null controller
            StaffModel Staff = new StaffModel() { StaffId = 4, FirstName = "josh", LastName = "white", ContactNumber = "11212213129", Email = "josh_white@hotmail.co.uk", PayRoll = 12533123 };// new valid staff model
            Assert.IsNotNull(Staff);// staff isnt null

            int currentMaxId = _staffController.GetStaffs().Max(x => x.StaffId); // get the max id 
            Assert.GreaterOrEqual(currentMaxId, 1);// adds 1 to max id 

            ActionResult<StaffModel> result = _staffController.CreateStaff(Staff);// result is the return of create staff function 
            Assert.IsNotNull(result);// checks is not null


            ActionResult staffResult = result.Result;// staff result is the result of result
            Assert.AreEqual(staffResult.GetType(), typeof(CreatedAtActionResult));// checks staff result us of type create at action

            CreatedAtActionResult createdStaffResult = (CreatedAtActionResult)staffResult;// makes a new creat at action called createdstaffresult
            Assert.IsNotNull(createdStaffResult);// chekcs nit null
            Assert.AreEqual(createdStaffResult.Value.GetType(), typeof(StaffModel));// checks createdStaffResult.Value is of type staff model

            StaffModel UserValue = (StaffModel)createdStaffResult.Value;// cretes new staff model and sets it ot createdStaffResult.Value
            Assert.IsNotNull(UserValue);// checks not null

            Assert.AreEqual(currentMaxId + 1, UserValue.StaffId);//checks are equal
            Assert.AreEqual(Staff.FirstName, UserValue.FirstName);//checks are equal
            Assert.AreEqual(Staff.LastName, UserValue.LastName);//checks are equal
            Assert.AreEqual(Staff.Email, UserValue.Email);//checks are equal
            Assert.AreEqual(Staff.PayRoll, UserValue.PayRoll);//checks are equal

        }
        [Test]
        public void CreateProduct_invalid_Shouldobject()
        {
            Assert.IsNotNull(_staffRepo);// not null repo
            Assert.IsNotNull(_staffController);// not null controller
            StaffModel Staff = null;// null staff model
            Assert.IsNull(Staff);// checks null

            int currentMaxId = _staffController.GetStaffs().Max(x => x.StaffId);// gets max id
            Assert.GreaterOrEqual(currentMaxId, 1);// adds one to max id 

            ActionResult<StaffModel> result = _staffController.CreateStaff(Staff);// calls create staff 
            Assert.IsNotNull(result);// checks result is not null


            ActionResult staffResult = result.Result;//staffResult is result.result
            Assert.AreEqual(staffResult.GetType(), typeof(BadRequestResult));// checks staffResult is of bad request
        }

        [Test]
        public void EditStaff_valid_Object()
        {
            Assert.IsNotNull(_staffRepo);// repo not null
            Assert.IsNotNull(_staffController);// controller nit null
            StaffModel UpdateStaff = new StaffModel() { StaffId = 2, FirstName = "sam", LastName = "el", ContactNumber = "192342123429", Email = "sma_fecal@hotmail.co.uk", PayRoll = 2325243 };// current staff model
            Assert.IsNotNull(UpdateStaff);// staff model not null

            UpdateStaff.LastName = "onopp";// eddit las name

            ActionResult<StaffModel> result = _staffController.EditStaff(UpdateStaff);// calls edit function
            Assert.IsNotNull(result);// result isnt null

            StaffModel updatedModel = result.Value;// updatedModel id the result of result
            Assert.IsNotNull(result.Value);// checks nit null

            Assert.AreEqual(updatedModel.LastName, UpdateStaff.LastName);// checks it has been eddit correctly
        }
        [Test]
        public void EditStaff_invalid_Object()
        {
            Assert.IsNotNull(_staffRepo);// repo not null
            Assert.IsNotNull(_staffController);// controller nit null
            StaffModel UpdateStaff = null;// null model 
            Assert.IsNull(UpdateStaff);// checks is null

            ActionResult<StaffModel> result = _staffController.EditStaff(UpdateStaff);// calls edit with null model passed through
            Assert.IsNotNull(result);// checks the result is not null

            ActionResult StaffResult = result.Result;// StaffResult is the result.result
            Assert.AreEqual(StaffResult.GetType(), typeof(BadRequestResult));// checks StaffResult is of type bad reqequest
        }
        [Test]
        public void DeleteStaff_valid_shouldObject()
        {
            Assert.IsNotNull(_staffRepo);// repo not null
            Assert.IsNotNull(_staffController);// controller nit null
            StaffModel DeleteStaff = new StaffModel() { StaffId = 2, FirstName = "sam", LastName = "el", ContactNumber = "192342123429", Email = "sma_fecal@hotmail.co.uk", PayRoll = 2325243 };// new staff model
            Assert.IsNotNull(DeleteStaff);// checks model is not null

            ActionResult<StaffModel> getproduct = _staffController.GetStaff(DeleteStaff.StaffId);
            Assert.IsNotNull(getproduct);// is nit null

            ActionResult<StaffModel> product = _staffController.DeleteStaff(DeleteStaff); // product is the return of DeleteProduct
            Assert.IsNotNull(product);// product is not null 

            ActionResult<StaffModel> result = _staffController.GetStaff(DeleteStaff.StaffId);// result is result of get product
            Assert.IsNotNull(result);// is nit null

            ActionResult StaffResult = result.Result;// staffresult is result.value
            Assert.AreEqual(StaffResult.GetType(), typeof(NotFoundResult));// StaffResult is of type bad request 
        }
        [Test]
        public void DeleteStaff_invalid_shouldObject()
        {
            Assert.IsNotNull(_staffRepo);// repo not null
            Assert.IsNotNull(_staffController);// controller nit null
            StaffModel DeleteStaff = null;// null users
            Assert.IsNull(DeleteStaff);// checks is null

            ActionResult<StaffModel> result = _staffController.DeleteStaff(DeleteStaff);// calls delete fuction with null model 
            Assert.IsNotNull(result);// result is not null

            ActionResult StaffResult = result.Result;// StaffResult is result of result
            Assert.AreEqual(StaffResult.GetType(), typeof(BadRequestResult));// StaffResult is of type bad request

        }
    }
}