using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using Otus.Teaching.PromoCodeFactory.Services.Models;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController(IPromoCodeService promoCodeService)
        : ControllerBase
    {
        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            //TODO: Получить все промокоды 
            //throw new NotImplementedException();

            var result = await promoCodeService.GetAsync();

            return Ok(result);
        }
        
        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            //TODO: Создать промокод и выдать его клиентам с указанным предпочтением
            //throw new NotImplementedException();

            var success = await promoCodeService.CreateAsync(request);

            return success ? Ok() : NotFound();
        }
    }
}