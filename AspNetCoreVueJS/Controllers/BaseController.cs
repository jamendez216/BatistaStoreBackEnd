using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetCoreVueJS.Controllers
{
    public class BaseController : Controller
    {

        protected IActionResult HandleException(Exception e)
        {
            if (e.Message.Contains("Not Found"))
            {
                return NotFound();
            }
            return BadRequest();
        }
    }
}
