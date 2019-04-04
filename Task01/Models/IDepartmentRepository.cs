using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task01.Models
{
    interface IDepartmentRepository
    {
        IQueryable<Department> Products { get; }

        void SaveProduct(Department product);

        Department DeleteProduct(int productID);
    }

}
