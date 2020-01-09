using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud_System_dev_ops.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cloud_System_dev_ops.Repo
{
    public class EntityFrameWorkStaffRepositry : IRepository<StaffModel>
    {
        private readonly IServiceScope _scope;
        private readonly StaffDataBaseContext _context;

        public EntityFrameWorkStaffRepositry(IServiceProvider service)
        {
            _scope = service.CreateScope();
            _context = _scope.ServiceProvider.GetRequiredService<StaffDataBaseContext>();

        }
        public StaffModel CreateObject(StaffModel Object)
        {
            _context.Staff.Add(Object);
            _context.SaveChanges();

            return Object;
        }
        public IEnumerable<StaffModel> GetObjects()
        {
            return _context.Staff.Include(x => x.PermissionModels);
        }

        public StaffModel UpdateObject(StaffModel Object)
        {
            try
            {
                _context.Staff.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return Object;
        }
        public StaffModel DeleteObject(StaffModel Object)
        {
            try
            {
                _context.Staff.Remove(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Object;
            }

            return null;
        }



    }
}
