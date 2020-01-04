using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{    
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _dataContext.Values.ToListAsync();
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var values = await _dataContext.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(values);
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[]
        //     {
        //         "Value 1","Value 3"
        //     };
        // }

        // [HttpGet("{id}")]
        // public ActionResult<IEnumerable<string>> Get(int id)
        // {
        //     return new string[]
        //     {
        //         "Parameter you passed is " + id.ToString()
        //     };
        // }

    }
}