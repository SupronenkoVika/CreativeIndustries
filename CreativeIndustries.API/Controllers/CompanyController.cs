using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
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
        private readonly AppDBContext _db;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService,
            AppDBContext db,
            IMapper mapper)
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
            try
            {
                var comp = _mapper.Map<Company>(company);
                _companyService.Create(comp);
                return RedirectToAction("CompanyIndex", "Company");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult CreateNews(AddNewsViewModel news)
        {
            try
            {
                var compNews = _mapper.Map<CompanyNews>(news);
                _companyService.Create(compNews);
                return RedirectToAction("NewsIndex", "Company");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult CreateEvent(AddEventViewModel compEvent)
        {
            try
            {
                var compEv = _mapper.Map<CompanyEvent>(compEvent);
                _companyService.Create(compEv);
                return RedirectToAction("EventIndex", "Company");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteCompany(Company company)
        {
            try
            {
                _companyService.Delete(company);
                return RedirectToAction("CompanyIndex");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteNews(CompanyNews news)
        {
            try
            {
                _companyService.Delete(news);
                return RedirectToAction("NewsIndex");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult DeleteEvent(CompanyEvent compEvent)
        {
            try
            {
                _companyService.Delete(compEvent);
                return RedirectToAction("EventIndex");
            }
            catch (Exception e)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult EditCompany(int id)
        {
            try
            {
                Company comp = _db.Companies.Find(id);
                CompanyViewModel model = _mapper.Map<CompanyViewModel>(comp);
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult EditCompany(CompanyViewModel model)
        {
            try
            {
                var comp = _mapper.Map<Company>(model);
                if (ModelState.IsValid)
                {
                    _companyService.Update(comp);
                    return RedirectToAction("CompanyIndex");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult EditNews(int id)
        {
            try
            {
                CompanyNews news = _db.News.Find(id);
                AddNewsViewModel model = _mapper.Map<AddNewsViewModel>(news);
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult EditNews(AddNewsViewModel model)
        {
            try
            {
                var news = _mapper.Map<CompanyNews>(model);
                if (ModelState.IsValid)
                {
                    _companyService.Update(news);
                    return RedirectToAction("NewsIndex");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            try
            {
                CompanyEvent compEvent = _db.Events.Find(id);
                AddEventViewModel model = _mapper.Map<AddEventViewModel>(compEvent);
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult EditEvent(AddEventViewModel model)
        {
            try
            {
                var compEvent = _mapper.Map<CompanyEvent>(model);
                if (ModelState.IsValid)
                {
                    _companyService.Update(compEvent);
                    return RedirectToAction("EventIndex");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}

