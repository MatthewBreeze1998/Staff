using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Cloud_System_dev_ops.Repo;
using Cloud_System_dev_ops.Services;
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

        private IRepository<StaffModel> _StaffRepo; // Staff Interface
        private IUserService _userRepositry; // User Interface
        public StaffController(IRepository<StaffModel> staff, IUserService user)
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
           
            _StaffRepo.CreateObject(staff);
            
            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
                
               
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

            StaffModel liveModel = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == staff.StaffId);

            if(liveModel == null)
            {
                return BadRequest();
            }

            liveModel = _StaffRepo.DeleteObject(liveModel);

            if(liveModel != null)
            {
                return Conflict();
            }
            return liveModel;

        }
        [Authorize(Policy = "Manager")]
        [Route("Editstaff")]
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
            StaffModel liveModel = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == staff.StaffId);

            if(liveModel == null)
            {
                return BadRequest();
            }

            liveModel.FirstName = staff.FirstName;
            liveModel.LastName = staff.LastName;
            liveModel.PayRoll = staff.PayRoll;
            liveModel.Email = staff.Email;
            liveModel.ContactNumber = staff.ContactNumber;

            liveModel = _StaffRepo.UpdateObject(liveModel);// returns edited user

            if(liveModel == null)
            {
                return Conflict();
            }
            return liveModel;// returns edited user
        }
        
        [Route("GetAllStaff")]// Route
        [HttpGet]
        [Authorize(Policy = "Staffpol")]
        public IEnumerable<StaffModel> GetStaffs()
        {
            return _StaffRepo.GetObjects();// calls and return all staff as IEnumerbale
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
           
            StaffModel staff = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == id);// creates new model staff from the found result of getstaff
       
            if(staff == null)
            {
                return NotFound();
            }// checks staff is valid staff
            return staff;  // retuns staff
        }
        
        [Authorize(Policy = "Staffpol")]
        [Route("StaffPermissions/{id}")] // route
        [HttpGet]
        public ActionResult<IEnumerable<StaffPermissionsModel>> GetPermissons(int id)
        {
            if (id <= 0) // checks valid id 
            {
                return BadRequest();// not found if invalid
            }
            
            StaffModel liveModel = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == id); 
            
            if(liveModel == null)
            {
                return NotFound();
            }
            
            return liveModel.PermissionModels.ToList(); 
        }//end
        [Authorize(Policy = "Manager")]
        [Route("AddPermissons")]
        [HttpPost]
        public ActionResult<StaffPermissionsModel> AddPermissons(StaffPermissionsModel Permission)
        {
            if (Permission == null ||string.IsNullOrWhiteSpace(Permission.Permission) || Permission.StaffId <= 0 )// checks permissons isnt null
            {
                return BadRequest();
            }

            StaffModel staff = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == Permission.StaffId);

            if(staff == null)
            {
                return NotFound();
            }
            
            staff.PermissionModels.Add(Permission);
            
            StaffModel UpdatedStaff  = _StaffRepo.UpdateObject(staff);

            if(UpdatedStaff == null)
            {

                return Conflict(); 
                
            }
            
            return  Permission; // returns edited data
        }

        [Authorize(Policy = "Manager")]
        [Route("RemovePermissons")]
        [HttpPost]
        public ActionResult<StaffPermissionsModel> RemovePermissons(StaffPermissionsModel Permission)
        {
            if (Permission == null || string.IsNullOrWhiteSpace(Permission.Permission) || Permission.StaffId <= 0 || Permission.StaffPermissionsId <= 0)// checks permissons isnt null
            {
                return BadRequest();
            }

            StaffModel staff = _StaffRepo.GetObjects().FirstOrDefault(x => x.StaffId == Permission.StaffId);

            if (staff == null)
            {
                return NotFound();
            }

            staff.PermissionModels.Remove(x => x.Permission = Permission.Permission);
            StaffModel UpdatedStaf = _StaffRepo.UpdateObject(staff);


            if (UpdatedStaf != null)
            {
                return Conflict();
            }


            return Permission; // returns edited data
        }

        [Route("purchaseAbility")]//route
        [HttpPost]
        [Authorize(Policy = "Staffpol")]
        public async Task<ActionResult<UserMetaData>> SetPurchaseAbilty(UserMetaData user)
        {

            if(user == null) // checks data is not null
            {
                return BadRequest();// not found if user is null
            }
            if(user.UserId <= 0)
            {
                return BadRequest();
            }

            user.PurchaseAbility = !user.PurchaseAbility;
            await _userRepositry.Edituser(user);// calls user
            return user; // returns ediited data
        }
    }
}