using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud_System_dev_ops.Models
{
    public class StaffPermissonsModel
    {
      
        public int StaffId { get; set; }
        
        public Boolean CanDeleteUser{ get; set; }

        public Boolean CanHideReview { get; set; }

        public Boolean SetPurchaseAbility{ get; set; }

        public Boolean ViewUsers { get; set; }

        public Boolean ViewOrderList { get; set; }

        public Boolean ViewPendingOrders { get; set; }

        public Boolean ViewSetReSale { get; set; }

        public Boolean PurchaseRequest { get; set; }

        public Boolean ViewStocklevel { get; set; }

        public Boolean AddStaff { get; set; }

        public Boolean RemoveStaff { get; set; }

        public Boolean authorisePermissons { get; set; }

        public Boolean ApproveStaffPurchase { get; set; }

    }
}
