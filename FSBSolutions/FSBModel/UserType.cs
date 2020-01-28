using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSBModel
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        public string UserTypeName { get; set; }

        public int PlantId { get; set; }

        public Plant Plant { get; set; }

        public IList<User> Users { get; set; }

        public bool Status { get; set; }
    }
}
