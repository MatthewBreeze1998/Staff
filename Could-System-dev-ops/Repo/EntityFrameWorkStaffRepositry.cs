using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Could_System_dev_ops.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Could_System_dev_ops.Repo
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
        public IEnumerable<StaffModel> GetObject()
        {
            return _context.Staff;
        }

        public bool UpdateObject(StaffModel Object, bool Return)
        {
            try
            {
                _context.Staff.Update(Object);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
