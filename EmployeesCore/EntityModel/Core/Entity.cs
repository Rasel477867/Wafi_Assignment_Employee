using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesCore.EntityModel.Core
{
    public class Entity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.IsDeleted = false;
            this.IsActive = true;
        }

    }
}
