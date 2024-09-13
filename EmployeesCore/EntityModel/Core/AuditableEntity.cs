using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesCore.EntityModel.Core
{
    public class AuditableEntity:Entity
    {
        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
        public Guid? CreatedBy { get; set; }

        public DateTime Created { get; set; }


        public AuditableEntity()
        {
            Created = DateTime.Now;
        }
    }
}
