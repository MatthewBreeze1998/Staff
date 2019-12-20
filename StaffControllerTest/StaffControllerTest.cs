using Could_System_dev_ops.Controllers;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
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
        private IStaffRepositry _staffRepo;
        private IUserRepositry _userRepo;
        private StaffController _staffController;
        private List<StaffModel> _staffModelsList;
        private List<StaffPermissonsModel> _staffPermissonsList;

        public StaffControllerTest()
        {
            _client = new HttpClient();
        }

        [SetUp]
        public void Setup()
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

            _staffRepo = new FakeStaffRepo();
            _staffController = new StaffController(_staffRepo);
            _userRepo = new SuccessIUserService();

        }

        [Test]
        public void CreateProduct_valid_object()
        {

            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel Staff = new StaffModel() { StaffId = 4, FirstName = "josh", LastName = "white", ContactNumebr = 11212213129, Email = "josh_white@hotmail.co.uk", PayRoll = 12533123 };
            Assert.IsNotNull(Staff);

            int currentMaxId = _staffController.GetStaffs().Max(x => x.StaffId);
            Assert.GreaterOrEqual(currentMaxId, 1);

            ActionResult<StaffModel> result = _staffController.CreateStaff(Staff);
            Assert.IsNotNull(result);


            ActionResult staffResult = result.Result;
            Assert.AreEqual(staffResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult createdStaffResult = (CreatedAtActionResult)staffResult;
            Assert.IsNotNull(createdStaffResult);
            Assert.AreEqual(createdStaffResult.Value.GetType(), typeof(StaffModel));

            StaffModel UserValue = (StaffModel)createdStaffResult.Value;
            Assert.IsNotNull(UserValue);

            Assert.AreEqual(currentMaxId + 1, UserValue.StaffId);
            Assert.AreEqual(Staff.FirstName, UserValue.FirstName);
            Assert.AreEqual(Staff.LastName, UserValue.LastName);
            Assert.AreEqual(Staff.Email, UserValue.Email);
            Assert.AreEqual(Staff.PayRoll, UserValue.PayRoll);

        }
        [Test]
        public void CreateProduct_invalid_Shouldobject()
        {

            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel Staff = null;
            Assert.IsNotNull(Staff);

            int currentMaxId = _staffController.GetStaffs().Max(x => x.StaffId);
            Assert.GreaterOrEqual(currentMaxId, 1);

            ActionResult<StaffModel> result = _staffController.CreateStaff(Staff);
            Assert.IsNotNull(result);


            ActionResult staffResult = result.Result;
            Assert.AreEqual(staffResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult createdStaffResult = (CreatedAtActionResult)staffResult;
            Assert.IsNotNull(createdStaffResult);
            Assert.AreEqual(createdStaffResult.Value.GetType(), typeof(StaffModel));

            StaffModel StaffValue = (StaffModel)createdStaffResult.Value;
            Assert.IsNotNull(StaffValue);

            Assert.AreNotEqual(currentMaxId + 1, StaffValue.StaffId);
            Assert.AreNotEqual(Staff.FirstName, StaffValue.FirstName);
            Assert.AreNotEqual(Staff.LastName, StaffValue.LastName);
            Assert.AreNotEqual(Staff.Email, StaffValue.Email);
            Assert.AreNotEqual(Staff.PayRoll, StaffValue.PayRoll);

        }

        [Test]
        public void EditStaff_valid_Object()
        {

            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel UpdateStaff = _staffController.GetStaff(2).Value;
            Assert.IsNotNull(UpdateStaff);

            UpdateStaff.LastName = "fgt";

            ActionResult<StaffModel> result = _staffController.EditStaff(UpdateStaff);
            Assert.IsNotNull(result);

            ActionResult StaffResult = result.Result;
            Assert.AreEqual(StaffResult.GetType(), typeof(CreatedAtActionResult));

            CreatedAtActionResult UpdatedStaffResult = (CreatedAtActionResult)StaffResult;
            Assert.IsNotNull(UpdatedStaffResult);
            Assert.AreEqual(UpdatedStaffResult.Value.GetType(), typeof(StaffModel));

            StaffModel StaffValue = (StaffModel)UpdatedStaffResult.Value;
            Assert.IsNotNull(StaffValue);

            Assert.AreEqual(UpdateStaff.FirstName, StaffValue.FirstName);

        }
        [Test]
        public void EditStaff_invalid_Object()
        {
            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel UpdateStaff = null;
            Assert.IsNotNull(UpdateStaff);

            ActionResult<StaffModel> result = _staffController.EditStaff(UpdateStaff);
            Assert.IsNotNull(result);

            ActionResult StaffResult = result.Result;
            Assert.AreEqual(StaffResult.GetType(), typeof(BadRequestResult));
        }
        [Test]
        public void DeleteStaff_valid_shouldObject()
        {
            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel DeleteStaff = _staffController.GetStaff(1).Value;
            Assert.IsNotNull(DeleteStaff);

            _staffController.DeleteStaff(DeleteStaff);

            ActionResult<StaffModel> result = _staffController.GetStaff(1);
            Assert.IsNotNull(result);

            ActionResult StaffResult = result.Result;
            Assert.AreEqual(StaffResult.GetType(), typeof(NotFoundResult));

        }
        [Test]
        public void DeleteStaff_invalid_shouldObject()
        {
            Assert.IsNotNull(_staffRepo);
            Assert.IsNotNull(_staffController);
            StaffModel DeleteStaff = null;
            Assert.IsNotNull(DeleteStaff);

            _staffController.DeleteStaff(DeleteStaff);

            ActionResult<StaffModel> result = _staffController.GetStaff(1);
            Assert.IsNotNull(result);

            ActionResult StaffResult = result.Result;
            Assert.AreEqual(StaffResult.GetType(), typeof(NotFoundResult));

        }


    }


}