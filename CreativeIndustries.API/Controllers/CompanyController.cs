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
            catch (Exception e)
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
                Company model = _companyService.FindCompById(id);
                var comp = _mapper.Map<CompanyViewModel>(model);
                return View(comp);
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
                CompanyNews model = _companyService.FindNewsById(id);
                var news = _mapper.Map<AddNewsViewModel>(model);
                return View(news);
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
                CompanyEvent model = _companyService.FindEventById(id);
                var compEvent = _mapper.Map<AddEventViewModel>(model);
                return View(compEvent);
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

