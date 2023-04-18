using AutoMapper;
using CreativeIndustries.API.DXS.CompanyViewModels;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.DB.EF;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreativeIndustries.API.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService,
            AppDBContext db,
            IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public IActionResult CompanyIndex()
        {
            var model = _companyService.GetList<Company>();
            return View(model);
        }

        public IActionResult NewsIndex()
        {
            var model = _companyService.GetList<CompanyNews>();
            return View(model);
        }

        public IActionResult EventIndex()
        {
            var model = _companyService.GetList<CompanyEvent>();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateCompany()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCompany(CompanyViewModel company)
        {
            var comp = _mapper.Map<Company>(company);
            _companyService.Create(comp);
            return RedirectToAction("CompanyIndex", "Company");
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult CreateNews(AddNewsViewModel news)
        {
            var compNews = _mapper.Map<CompanyNews>(news);
            _companyService.Create(compNews);
            return RedirectToAction("NewsIndex", "Company");
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public IActionResult CreateEvent(AddEventViewModel compEvent)
        {
            var compEv = _mapper.Map<CompanyEvent>(compEvent);
            _companyService.Create(compEv);
            return RedirectToAction("EventIndex", "Company");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteCompany(Company company)
        {
            _companyService.Delete(company);
            return RedirectToAction("CompanyIndex");
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult DeleteNews(CompanyNews news)
        {
            _companyService.Delete(news);
            return RedirectToAction("NewsIndex");
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult DeleteEvent(CompanyEvent compEvent)
        {
            _companyService.Delete(compEvent);
            return RedirectToAction("EventIndex");
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public IActionResult EditCompany(int id)
        {
            Company model = _companyService.FindCompById(id);
            var comp = _mapper.Map<CompanyViewModel>(model);
            return View(comp);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult EditCompany(CompanyViewModel model)
        {
            var comp = _mapper.Map<Company>(model);
            if (ModelState.IsValid)
            {
                _companyService.Update(comp);
                return RedirectToAction("CompanyIndex");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public IActionResult EditNews(int id)
        {
            CompanyNews model = _companyService.FindNewsById(id);
            var news = _mapper.Map<AddNewsViewModel>(model);
            return View(news);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult EditNews(AddNewsViewModel model)
        {
            var news = _mapper.Map<CompanyNews>(model);
            if (ModelState.IsValid)
            {
                _companyService.Update(news);
                return RedirectToAction("NewsIndex");
            }
            return View(model);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet]
        public IActionResult EditEvent(int id)
        {
            CompanyEvent model = _companyService.FindEventById(id);
            var compEvent = _mapper.Map<AddEventViewModel>(model);
            return View(compEvent);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult EditEvent(AddEventViewModel model)
        {
            var compEvent = _mapper.Map<CompanyEvent>(model);
            if (ModelState.IsValid)
            {
                _companyService.Update(compEvent);
                return RedirectToAction("EventIndex");
            }
            return View(model);
        }
    }
}

