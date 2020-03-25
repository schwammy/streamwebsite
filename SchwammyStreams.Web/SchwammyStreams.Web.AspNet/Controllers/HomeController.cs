using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Orchestrators;
using SchwammyStreams.Web.AspNet.Models;

namespace SchwammyStreams.Web.AspNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEpisodeHistoryOrchestrator _episodeHistoryOrchestrator;
        public HomeController(ILogger<HomeController> logger, IEpisodeHistoryOrchestrator episodeHistoryOrchestrator)
        {
            _logger = logger;
            _episodeHistoryOrchestrator = episodeHistoryOrchestrator;
        }

        public async Task<IActionResult> Index()
        {
            // Get list of old shows to display
            // ...
            // Use Repository Pattern
            // Use Unit Of Work Pattern
            // Set Up DbContext the .NET Core way - for DI

            //AddEpisodeDto dto = new AddEpisodeDto();
            //dto.Title = "First One";
            //await _episodeHistoryOrchestrator.AddEpisodeAsync(dto);

            var history = _episodeHistoryOrchestrator.GetHistory(new GetHistoryDto() { PageSize = 10, PageNumber = 1, SearchCriteria = string.Empty });

            return View(history.Results);
        }

        [Authorize(Roles = "6136e87e-bbb7-46b2-a13f-71df9ac7e5bb")]
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
