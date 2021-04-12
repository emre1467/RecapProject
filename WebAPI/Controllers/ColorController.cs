using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IColorService _colorservice;
        public ColorController(IColorService colorService)
        {
            _colorservice = colorService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            var result = _colorservice.GetAll();
            return Ok(result);
        }
        [HttpPost("add")]
        public IActionResult Post(Color color)
        {
            var result = _colorservice.Add(color);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
