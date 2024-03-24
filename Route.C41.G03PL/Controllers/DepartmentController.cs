using Microsoft.AspNetCore.Mvc;
using Route.C41.G03.BLL.Interfaces;
using Route.C41.G03.Dal.Models;


namespace Route.C41.G03PL.Controllers
{
    //ingertiance : DepartnentController is a Controller 
    //Association : DepartnentController has a DepartmentRepository 
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }



        // /Department/Index
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }

        // /Department/Create
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server side Validation
            {
               var count = _departmentRepository.Add(department);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }

        //  Department/Details/10
        //  Department/Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest(); //400

            var department = _departmentRepository.Get(id.Value);

            if (department is null)
                return NotFound();//404

            return View(department);
        }


    }
}
