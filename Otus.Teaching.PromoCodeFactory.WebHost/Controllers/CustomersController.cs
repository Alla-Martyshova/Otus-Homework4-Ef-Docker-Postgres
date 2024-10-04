using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Otus.Teaching.PromoCodeFactory.Services.Models;
using Otus.Teaching.PromoCodeFactory.Services.Abstractions;
using System.Net;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController(ICustomerService customerService)
        : ControllerBase
    {
        /// <summary>
        /// Получение списка всех клиентов
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerShortResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CustomerShortResponse>>> GetCustomersAsync()
        {
            //TODO: Добавить получение списка клиентов
            //throw new NotImplementedException();
            
            var result = await customerService.GetAsync();

            return Ok(result);
        }

        /// <summary>
        /// Получение клиента по Id вместе с выданными ему промокодами
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="204">Нет данных</response>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            //TODO: Добавить получение клиента вместе с выданными ему промомкодами
            //throw new NotImplementedException();

            var result = await customerService.GetByIdAsync(id);

            return result != null ? Ok(result) : NoContent();
        }

        /// <summary>
        /// Добавление нового клиента вместе с его предпочтениями
        /// </summary>
        /// <returns></returns>
        /// <response code="201">Успешное выполнение</response>
        /// <response header="Location">Расположение объекта</response>
        [HttpPost]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            //TODO: Добавить создание нового клиента вместе с его предпочтениями
            //throw new NotImplementedException();

            var id = await customerService.CreateAsync(request);

            return Created($"api/v1/Customers/{id}", null);
        }

        /// <summary>
        /// Изменение данных клиента по Id вместе с его предпочтениями
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        /// <response code="400">Объект не найден</response>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> EditCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            //TODO: Обновить данные клиента вместе с его предпочтениями
            //throw new NotImplementedException();

            var success = await customerService.UpdateByIdAsync(id, request);

            return success ? Ok() : BadRequest();
        }

        /// <summary>
        /// Удаление данных клиента по Id
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Успешное выполнение</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            //TODO: Удаление клиента вместе с выданными ему промокодами
            //throw new NotImplementedException();

            await customerService.DeleteByIdAsync(id);

            return Ok();
        }
    }
}