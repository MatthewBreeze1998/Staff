﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Could_System_dev_ops.Controllers
{
    [Route("api/Staff")]// contoller Route
    [ApiController]
    [Authorize]
    public class StaffController : Controller
    {

        private IStaffRepositry _StaffRepo; // Staff Interface
        private IUserRepositry _userRepositry; // User Interface
        public StaffController(IStaffRepositry staff)
        {
            _StaffRepo = staff;
        }
        [Route("CreateStaff")]//Route
        [HttpPost]
        public  ActionResult<StaffModel> CreateStaff(StaffModel staff)
        {
            if(staff == null)
            {
                return NotFound();
            }
            // call interface create function with Staff model 
            return _StaffRepo.CreateStaff(staff);// return created staff
        }
        [Route("DeleteStaff/{id}")]//rotute
        [HttpPost]
        public ActionResult<StaffModel> DeleteStaff(StaffModel staff)
        {
            if (staff == null)// checks staff is not null 
            {
                return NotFound();// return not found if null 

            }
            if (staff.StaffId <= 0)// checks user id
            {
                return NotFound();// return not found if null 
            }
            return _StaffRepo.DeleteStaff(staff); // calls api and returns deleted data
        }

        [Route("editstaff/{id}")]
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
            return _StaffRepo.EditStaff(staff);// returns edited user
        }

        [Route("GetAllStaff")]// Route
        [HttpGet]
        public IEnumerable<StaffModel> GetStaffs()
        {
            return _StaffRepo.GetAllStaff();// calls and return all staff as IEnumerbale
        }// Get All staff method

        [Route("GetStaff/{id}")]//Route
        [HttpGet]
        public ActionResult<StaffModel> GetStaff(int id)
        {

            if (id <= 0)// check to valid id
            {
                return NotFound(); // not found if invalid
            };
            return _StaffRepo.GetStaff(id);  // retuns staff
       
        }

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

       


        [Route("StaffPermissions")] // route
        [HttpPost]
        public ActionResult<StaffPermissonsModel> GetPermissons(int id)
        {
            if (id <= 0) // checks valid id 
            {
                return NotFound();// not found if invalid
            }
            return _StaffRepo.GetStaffPermissions(id); // retruns staff permissons
        }//end

        [Route("EditPermissons")]
        [HttpPost]
        public async Task<ActionResult<StaffPermissonsModel>> EditPermissons(StaffPermissonsModel Permissons)
        {
            if(Permissons == null)// checks permissons isnt null
            {
                return NotFound();
            }
            if(Permissons.StaffId <= 0)// checks valid id
            {
                return NotFound();
            }
            return _StaffRepo.EditPermissions(Permissons); // returns edited data
        }

        [Route("purchaseAbility/{id}")]//route
        [HttpPost]
        public async Task<ActionResult<UserMetaData>> SetPurchaseAbilty(UserMetaData user)
        {

            if (user == null) // checks data is not null
            {
                return NotFound();// not found if user is null
            }
            await _userRepositry.Edituser(user);// calls user
            return user; // returns ediited data
        }
        
        

    }
}