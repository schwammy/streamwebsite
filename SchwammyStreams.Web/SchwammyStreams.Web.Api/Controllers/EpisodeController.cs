using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Orchestrators;

namespace SchwammyStreams.Web.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeHistoryOrchestrator _episodeHistoryOrchestrator;

        public EpisodeController(IEpisodeHistoryOrchestrator episodeHistoryOrchestrator)
        {
            _episodeHistoryOrchestrator = episodeHistoryOrchestrator;
        }

        // GET: api/Episode
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var history = await _episodeHistoryOrchestrator.GetHistoryAsync(new GetHistoryDto() { PageSize = 10, PageNumber = 1, SearchCriteria = string.Empty });

            return Ok(history.Results);
        }

        // GET: api/Episode/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _episodeHistoryOrchestrator.GetEpisodeDetailAsync(id);

            return Ok(result.Item);
        }

        // POST: api/Episode
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEpisodeDto dto)
        {
            var result = await _episodeHistoryOrchestrator.AddEpisodeAsync(dto);

            return Ok(result.Item);

        }

        // PUT: api/Episode/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
