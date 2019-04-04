using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task01.Models
{
    public class UserDepartmentTransaction
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
    }
}
