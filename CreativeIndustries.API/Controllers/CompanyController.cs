using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CreativeIndustries.API.Controllers
{
    //[Authorize(Roles = "CompanyAdmin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly CompanyDBContext _db;

        public CompanyController(ICompanyService companyService, CompanyDBContext db)
        {
            _companyService = companyService;
            _db = db;
        }

        public IActionResult Index() => View(_db.Companies.ToList());

        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
            _companyService.CreateCompany(company);
            return View();
        }


        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNews(CompanyNews news)
        {
            _companyService.CreateNews(news);
            return View();
        }


        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEvent(CompanyEvent compEvent)
        {
            _companyService.CreateEvent(compEvent);
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCompany(Company company)
        {
            _companyService.DeleteCompany(company);
            return RedirectToAction("Index");
        }
    }
}

