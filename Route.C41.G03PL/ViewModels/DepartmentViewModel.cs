using Route.C41.G03.Dal.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace Route.C41.G03PL.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }

        // Navigational property => (Many) 
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
