using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task01.Models
{
    interface IUserDepartmentRepository
    {
        IEnumerable<User> ProductTypes { get; }
        IEnumerable<Department> StatusTypes { get; }
        IEnumerable<UserDepartmentTransaction> CustomerTypes { get; }

        void Save(UserDepartmentTransaction transaction);
        UserDepartmentTransaction Find(int id);
    }

}
