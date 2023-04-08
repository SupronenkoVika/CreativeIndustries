using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreativeIndustries.API.Controllers
{
    //[Authorize(Roles = "CompanyAdmin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, AppDBContext db, IMapper mapper)
        {
            _companyService = companyService;
            _db = db;
            _mapper = mapper;
        }

        public IActionResult CompanyIndex() => View(_db.Companies.ToList());
        public IActionResult NewsIndex() => View(_db.News.ToList());
        public IActionResult EventIndex() => View(_db.Events.ToList());

        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyViewModel company)
        {
            var comp = _mapper.Map<Company>(company);
            _companyService.Create(comp);
            return RedirectToAction("CompanyIndex", "Company");
        }

        [HttpPost]
        public IActionResult CreateNews(AddNewsViewModel news)
        {
            var compNews = _mapper.Map<CompanyNews>(news);
            _companyService.Create(compNews);
            return RedirectToAction("NewsIndex", "Company");
        }

        [HttpPost]
        public IActionResult CreateEvent(AddEventViewModel compEvent)
        {
            var compEv = _mapper.Map<CompanyEvent>(compEvent);
            _companyService.Create(compEv);
            return RedirectToAction("EventIndex", "Company");
        }

        [HttpPost]
        public IActionResult DeleteCompany(Company company)
        {
            _companyService.Delete(company);
            return RedirectToAction("CompanyIndex");
        }

        [HttpPost]
        public IActionResult DeleteNews(CompanyNews news)
        {
            _companyService.Delete(news);
            return RedirectToAction("NewsIndex");
        }

        [HttpPost]
        public IActionResult DeleteEvent(CompanyEvent compEvent)
        {
            _companyService.Delete(compEvent);
            return RedirectToAction("EventIndex");
        }

        [HttpGet]
        public IActionResult EditCompany(int id)
        {
            Company comp = _db.Companies.Find(id);
            CompanyViewModel model = _mapper.Map<CompanyViewModel>(comp);
            return View(model);

        }

        [HttpPost]
        public IActionResult EditCompany(CompanyViewModel model)
        {
            var comp = _mapper.Map<Company>(model);
            if (ModelState.IsValid)
            {
                _db.Entry(comp).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("CompanyIndex");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditNews(int id)
        {
            CompanyNews news = _db.News.Find(id);
            AddNewsViewModel model = _mapper.Map<AddNewsViewModel>(news);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditNews(AddNewsViewModel model)
        {
            var news = _mapper.Map<CompanyNews>(model);
            if (ModelState.IsValid)
            {
                _db.Entry(news).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("NewsIndex");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            CompanyEvent compEvent = _db.Events.Find(id);
            AddEventViewModel model = _mapper.Map<AddEventViewModel>(compEvent);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditEvent(AddEventViewModel model)
        {
            var compEvent = _mapper.Map<CompanyEvent>(model);
            if (ModelState.IsValid)
            {
                _db.Entry(compEvent).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("EventIndex");
            }
            return View(model);
        }

    }
}

