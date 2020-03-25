using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Orchestrators;

namespace SchwammyStreams.Web.AspNet.Views.Home
{
    [Authorize]
    public class EpisodeHistoryController : Controller
    {
        private readonly IEpisodeHistoryOrchestrator _episodeHistoryOrchestrator;

        public EpisodeHistoryController(IEpisodeHistoryOrchestrator episodeHistoryOrchestrator)
        {
            _episodeHistoryOrchestrator = episodeHistoryOrchestrator;
        }

        // GET: EpisodeHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: EpisodeHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EpisodeHistory/Create
        public ActionResult Create()
        {
            AddEpisodeDto dto = new AddEpisodeDto();
            return View(dto);
        }

        // POST: EpisodeHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddEpisodeDto dto)
        {
            try
            {
                await _episodeHistoryOrchestrator.AddEpisodeAsync(dto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(dto);
            }
        }

        // GET: EpisodeHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EpisodeHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EpisodeHistory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}