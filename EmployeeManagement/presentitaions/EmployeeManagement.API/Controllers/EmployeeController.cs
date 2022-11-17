
using EmployeeManagement.API.Controllers.Base;
using EmployeeManagement.Businnes.Common;
using EmployeeManagement.Businnes.DTOs.EmployeeDTOs;
using EmployeeManagement.Businnes.Exceptions;
using EmployeeManagement.Businnes.Services.Abstracts;
using EmployeeManagement.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService employeeService)
        {
            _service = employeeService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] string id)
        {
            try
            {
                return Ok(new Response()
                {
                    Entity = await _service.GetAsync(id),
                    Message = "Succes"

                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new Response()
                {
                    Message = ex.Message,
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response()
                {
                    Message = ex.Message
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(new Response()
                {
                    Entities = await _service.GetAllAsync(),
                    Message = "Succes"
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new Response()
                {
                    Message = ex.Message,
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response()
                {
                    Message = ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new Response()
                {
                    Message = ex.Message
                });
            }
           
        }

        [HttpGet("{id}/delete")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok(new Response()
                {
                    Message= "Employee is deleted"
                });
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(new Response()
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response()
                {
                    Message = ex.Message
                });
            }
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody]EmployeeCreateDto dto)
        {
            try
            {
               await _service.UpdateAsync(id,dto);
                return NoContent();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound(new Response()
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response()
                {
                    Message = ex.Message
                });
            }
        }
    }
}
