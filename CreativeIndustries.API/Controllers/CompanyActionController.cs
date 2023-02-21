using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CreativeIndustries.API.Controllers
{
    [Authorize(Roles = "CompanyAdmin")]
    public class CompanyActionController : Controller
    {

    }
}

