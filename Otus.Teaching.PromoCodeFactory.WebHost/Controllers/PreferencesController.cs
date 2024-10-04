using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Предпочтения
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PreferencesController(IPreferenceService preferenceService)
        : ControllerBase
    {
        /// <summary>
        /// Получить список всех предпочтений
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<PreferenceResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<PreferenceResponse>>> GetPreferencesAsync()
        {
            var result = await preferenceService.GetAsync();

            return result;
        }
    }
}
