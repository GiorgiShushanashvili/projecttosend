using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TheProjectToSend.DTOs;
using TheProjectToSend.Models;
using TheProjectToSend.Service;
using TheProjectToSend.Validators;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheProjectToSend.Controllers
{
    [Authorize]
    [Route("api/controller")]
    public class PersonController : Controller
    {
        private readonly TokenCredential _appsettings;
        private readonly IPersonService _service;
        public PersonController(IPersonService service,IOptions<TokenCredential> appsettings)
        {
            _appsettings = appsettings.Value;
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody]PersonCreateDTO person)
        {
            try
            {
                var validator = new PersonCreateValidator();
                var result = validator.Validate(person);
                List<string> errorlist = new();
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        errorlist.Add(item.ErrorMessage);
                    }
                    return BadRequest(errorlist);
                }

                var dbInsertionResult = await _service.AddPerson(person);
                if (dbInsertionResult == null)
                    return BadRequest("Person was not created succesfully");

                return Ok(dbInsertionResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async  Task<IActionResult> FindPerson(string input)
        {
            try
            {
                var person = await _service.FindPerson(input);
                if (person == null)
                    return NotFound($"There is no such person");

                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateperson")]
        public async Task<IActionResult> UpdatePerson([FromBody]PersonUpdateDTO person, int id)
        {
            try
            {
                var validator = new PersonUpdateValidator();
                var result = validator.Validate(person);
                List<string> errorlist = new();
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        errorlist.Add(item.ErrorMessage);
                    }
                    return BadRequest(errorlist);
                }

                await _service.Update(person, id);

                return Ok($"{person} is updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

