using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Could_System_dev_ops.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Could_System_dev_ops.Controllers
{
    [Route("api/Staff")]
    public class StaffController : Controller
    {

        private StaffRepo _StaffRepo;
        public StaffController(StaffRepo staff)
        {
            _StaffRepo = staff;
        }
        [HttpPost]
        public async Task<ActionResult<StaffModel>> CreateStaff(StaffModel staff)
        {
            _StaffRepo.CreateStaff(staff);

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);


        }
        [Route("GetAllStaff")]
        [HttpGet]
        public IEnumerable<StaffModel> GetStaff()
        {
           return _StaffRepo.GetStaff();
        }

        [Route("GetStaff/{id}")]
        [HttpGet]
        public ActionResult<StaffModel> GetStaff(StaffModel staff)
        {
           
            if(staff == null)
            {
                return GetStaff();
            }
            StaffModel createstaff = _StaffRepo.GetStaff(id);

            if (createstaff == null)
            {
                return NotFound();
            }
            return createstaff;
        }
        [Route("StaffPermissions/{permissons}")]
        [HttpPost]
        public ActionResult<StaffPermissonsModel> GetPermissons(StaffPermissonsModel permissons)
        {
            if (permissons == null)
            {
                return NotFound();
            }
            if(permissons.StaffId < 0 )
            {
                return NotFound();
            }                   
            StaffPermissonsModel staffPermissons = _StaffRepo.GetStaffPermissions(permissons);
            return staffPermissons;
        }


        [Route("purchaseAbility/{id}")]
        [HttpPost]
        public async Task<ActionResult<UsersModel>> SetPurchaseAbilty(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }
            UsersModel User = _StaffRepo.SetPurchaseAbility(id);
            return User;
        }
        [Route("DeleteStaff/{id}")]
        [HttpPost]
        public async Task<ActionResult<StaffModel>> DeleteStaff(StaffModel staff)
        {
            if (staff == null)
            {
                return NotFound();

            }
            if(staff.StaffId <= 0)
            {
                return NotFound();
            }

            StaffModel Remove = _StaffRepo.DeleteStaff(staff);
            return Remove;
        }

        [Route("editstaff/{id}")]
        [HttpPost]
        public async Task<ActionResult<StaffModel>> EditStaff(StaffModel staff)
        {
            if (staff == null)
            {
                return NotFound();
            }
            if(staff.StaffId <= 0)
            {
                return NotFound();
            }
            StaffModel EditiedStaff = _StaffRepo.EditStaff(staff);
           
            return EditiedStaff;
        }
        

    }
}