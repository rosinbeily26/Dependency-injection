using Dependency_injection.Interface;
using Dependency_injection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Dependency_injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;
        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("Post")]
        [HttpGet]
        public async Task<IActionResult> CreatePost(Post model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Validation", "Model is not vakid");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post model)
        {
            await _dataService.Create(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
