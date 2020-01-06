using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Cloud_System_dev_ops.Controllers
{
    [Route("api/Staff")]// contoller Route
    [ApiController]
    public class StaffController : Controller
    {

        private IStaffRepositry _StaffRepo; // Staff Interface
        private IUserRepositry _userRepositry; // User Interface
        public StaffController(IStaffRepositry staff, IUserRepositry user)
        {
            _StaffRepo = staff;
            _userRepositry = user;
        }
        [Authorize(Policy = "Manager")]
        [Route("CreateStaff")]//Route
        [HttpPost]
        public  ActionResult<StaffModel> CreateStaff(StaffModel staff)
        {
            if(staff == null)
            {
                return BadRequest();
            }

            int newId = _StaffRepo.GetAllStaff().Max(x => x.StaffId + 1);// gats max id and adds one
            staff.StaffId = newId; // sets new id
           
            _StaffRepo.CreateStaff(staff);

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
                
               // return created staff
        }
        [Authorize(Policy = "Manager")]
        [Route("DeleteStaff")]//rotute
        [HttpPost]
        public ActionResult<StaffModel> DeleteStaff(StaffModel staff)
        {
            if (staff == null)// checks staff is not null 
            {
                return BadRequest();// return not found if null 

            }
            if (staff.StaffId <= 0)// checks user id
            {
                return BadRequest();// return not found if null 
            }
            // calls api and returns deleted data
            return _StaffRepo.DeleteStaff(staff);

        }
        [Authorize(Policy = "Manager")]
        [Route("editstaff")]
        [HttpPost]
        public ActionResult<StaffModel> EditStaff(StaffModel staff)
        {
            if (staff == null)// checks staff is not null 
            {
                return BadRequest();// return not found if null 
            }
            if (staff.StaffId <= 0)// checks user id
            {
                return BadRequest();// return not found if null 
            }
            _StaffRepo.EditStaff(staff);// returns edited user

            return staff;// returns edited user
        }
        
        [Route("GetAllStaff")]// Route
        [HttpGet]
        [Authorize(Policy = "Staffpol")]
        public IEnumerable<StaffModel> GetStaffs()
        {
            return _StaffRepo.GetAllStaff();// calls and return all staff as IEnumerbale
        }// Get All staff method
        [Authorize(Policy = "Staffpol")]
        [Route("GetStaff/{id}")]//Route
        [HttpGet]
        public ActionResult<StaffModel> GetStaff(int? id)
        {

            if (id == null)// check to valid id
            {
                return BadRequest(); // not found if invalid
            }    
           
            StaffModel staff = _StaffRepo.GetStaff(id);// creates new model staff from the found result of getstaff
       
            if(staff == null)
            {
                return NotFound();
            }// checks staff is valid staff
            return staff;  // retuns staff
        }
        [Authorize(Policy = "Manager")]
        [Route("createstaffpermissions")]
        [HttpPost]
        public ActionResult<StaffPermissonsModel> CreateStaffPermissions(StaffPermissonsModel staffPermissons)
        {
            if (staffPermissons == null)// checks staffPermissons is not null 
            {
                return BadRequest();// return not found if null 
            }
            if (staffPermissons.StaffId <= 0)// checks user id
            {
                return BadRequest();// return not found if null 
            }
            return _StaffRepo.CreateStaffPermissons(staffPermissons);// returns new staffpermissons
        }
        [Authorize(Policy = "Manager")]
        [Route("DeleteStaffStaffPermissons")]//rotute
        [HttpPost]
        public ActionResult<StaffPermissonsModel> DeleteStaffPermissons(StaffPermissonsModel staffPermissons)
        {
            if (staffPermissons == null)// checks staffPermissons is not null 
            {
                return BadRequest();// return not found if null 

            }
            if (staffPermissons.StaffId <= 0)// checks user id
            {
                return BadRequest();// return not found if null 
            }
            return _StaffRepo.DeleteStaffPermissions(staffPermissons); // calls api and returns deleted data
        }
        [Authorize(Policy = "Staffpol")]
        [Route("StaffPermissions/{id}")] // route
        [HttpGet]
        public ActionResult<StaffPermissonsModel> GetPermissons(int id)
        {
            if (id <= 0) // checks valid id 
            {
                return BadRequest();// not found if invalid
            }
            return _StaffRepo.GetStaffPermissions(id); // retruns staff permissons
        }//end
        [Authorize(Policy = "Manager")]
        [Route("EditPermissons")]
        [HttpPost]
        public ActionResult<StaffPermissonsModel> EditPermissons(StaffPermissonsModel Permissons)
        {
            if (Permissons == null)// checks permissons isnt null
            {
                return BadRequest();
            }
            if (Permissons.StaffId <= 0)// checks valid id
            {
                return BadRequest();
            }
            return _StaffRepo.EditPermissions(Permissons); // returns edited data
        }
        
        [Route("purchaseAbility")]//route
        [HttpPost]
        [Authorize(Policy = "Staffpol")]
        public async Task<ActionResult<UserMetaData>> SetPurchaseAbilty(UserMetaData user)
        {

            if (user == null) // checks data is not null
            {
                return BadRequest();// not found if user is null
            }
            user.PurchaseAbility = !user.PurchaseAbility;
            await _userRepositry.Edituser(user);// calls user
            return user; // returns ediited data
        }
    }
}